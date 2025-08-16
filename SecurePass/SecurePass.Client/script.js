
      // ======================================
      // ⚙️ CONFIGURACIÓN
      // Cambia al puerto que te muestra tu API: https://localhost:7112 o http://localhost:5077
      // ======================================
      const API_BASE = "https://localhost:7112";

      // ======================================
      // 🧰 HELPERS DE API
      // Wrapper de fetch + gestión de errores simples
      // ======================================
      async function api(path, options = {}) {
        const resp = await fetch(`${API_BASE}${path}`, {
          headers: { "Content-Type": "application/json" },
          ...options,
        });
        if (!resp.ok) {
          const t = await resp.text();
          throw new Error(`HTTP ${resp.status}: ${t}`);
        }
        return resp.json();
      }

      // ======================================
      // 🧪 EVALUACIÓN (usa tu API /password/evaluate)
      // Devuelve { strength, score, checks, suggestions }
      // ======================================
      async function evaluate(password) {
  const body = {
    passwordGenerationDtoForController: {
      id: 0,
      passwordLength: password.length,
      includeUpperCaseLetter: /[A-Z]/.test(password),
      includeLowerCaseLetter: /[a-z]/.test(password),
      includeNumber: /\d/.test(password),
      includeSpecialCharacter: /[^A-Za-z0-9]/.test(password),
      userId: 0
    },
    passwordStrengthEvaluationDtoForController: {
      id: 0,
      strengthLevel: "",
      suggestionMessage: [],
      passwordGenerationId: 0,
      userId: 0
    }
  };
  const resp = await fetch(`${API_BASE}/api/Password/GenerateAndEvaluate`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(body)
  });
  return await resp.json();
}
      

      function strengthBadge(str) {
        const cls =
          str === "Fuerte" ? "strong" : str === "Media" ? "medium" : "weak";
        return `<span class="badge ${cls}">${str}</span>`;
      }

      function suggestionsList(sugs) {
        return (sugs || [])
          .slice(0, 3)
          .map((s) => `<span class="chip">${s}</span>`)
          .join(" ");
      }

      // ======================================
      // 🔐 GENERAR
      // Llama a /password/generate y pinta el resultado
      // ======================================
      const $length = document.getElementById("length");
      const $optUpper = document.getElementById("optUpper");
      const $optLower = document.getElementById("optLower");
      const $optNums = document.getElementById("optNums");
      const $optSpec = document.getElementById("optSpec");
      const $btnGenerate = document.getElementById("btnGenerate");
      const $generated = document.getElementById("generated");
      const $btnCopy = document.getElementById("btnCopy");
      const $btnSaveGenerated = document.getElementById("btnSaveGenerated");

      $btnGenerate.addEventListener("click", async () => {
        try {
          // ...existing code...
const body = {
  passwordGenerationDtoForController: {
    id: 0,
    passwordLength: parseInt($length.value || "12", 10),
    includeUpperCaseLetter: $optUpper.checked,
    includeLowerCaseLetter: $optLower.checked,
    includeNumber: $optNums.checked,
    includeSpecialCharacter: $optSpec.checked,
    userId: 0 // o el id real si tienes login
  },
  passwordStrengthEvaluationDtoForController: {
    id: 0,
    strengthLevel: "",
    suggestionMessage: [],
    passwordGenerationId: 0,
    userId: 0
  }
};
// ...existing code...

          const response = await fetch(
            `${API_BASE}/api/Password/GenerateAndEvaluate`,
            {
              method: "POST",
              headers: { "Content-Type": "application/json" },
              body: JSON.stringify(body),
            }
          );

          const data = await response.json();

          // 🔹 Extraer la fortaleza correcta
          // Dependiendo de tu API, puede venir en data.strength o data.evaluation.strengthLevel
          const password = data.password;

          const rawStrength =
            data.evaluation?.strengthLevel || data.strength || "";
          const strengthText = rawStrength.includes(":")
            ? rawStrength.split(":")[1].trim()
            : rawStrength;

          // Mostrar la contraseña con el badge de fortaleza
          $generated.innerHTML = `${password} ${strengthBadge(
            strengthText || "—"
          )}`;
        } catch (err) {
          console.error(err);
          $generated.innerHTML =
            '<span style="color:#ff9b9b">No se pudo generar (revisa API_BASE/CORS)</span>';
        }
      });

      $btnCopy.addEventListener("click", async () => {
        const text = ($generated.textContent || "").trim();
        if (!text || text === "—") return;
        try {
          await navigator.clipboard.writeText(text);
          $btnCopy.textContent = "¡Copiado!";
          setTimeout(() => ($btnCopy.textContent = "Copiar"), 1200);
        } catch {
          alert("Copia manual: " + text);
        }
      });

      $btnSaveGenerated.addEventListener("click", () =>
        openModal({
          id: null,
          label: "",
          password: $generated.textContent.trim(),
        })
      );

      // ======================================
      // 📦 CRUD (Listado de contraseñas)
      // Endpoints propuestos:
      //   GET    /user/passwords                → lista
      //   POST   /user/passwords                → crear { label, password }
      //   PUT    /user/passwords/{id}           → actualizar { label, password }
      //   DELETE /user/passwords/{id}           → eliminar
      // En esta UI mostraremos la contraseña con máscara y opción de ver/ocultar.
      // ======================================
      const $rows = document.getElementById("rows");
      const $search = document.getElementById("search");

      let state = { passwords: [], filter: "" };

      async function fetchPasswords() {
        try {
          const resp = await fetch(`${API_BASE}/api/UserPassword`, { method: "GET" });
          const list = await resp.json();
          state.passwords = list || [];
          renderRows();
        } catch (err) {
          console.warn(
            "Fallo obteniendo contraseñas. ¿No tienes este endpoint aún?",
            err
          );
          state.passwords = [];
          renderRows();
        }
      }

      function filtered() {
        const f = (state.filter || "").toLowerCase();
        return state.passwords.filter((x) =>
          (x.label || "").toLowerCase().includes(f)
        );
      }

      function mask(s) {
        return "•".repeat(Math.min(12, (s || "").length || 12));
      }

      function renderRows() {
  const rows = filtered()
    .map((x) => {
      const badge = strengthBadge(x.strength || "—");
      const sug = suggestionsList(x.suggestions);
      const pid = x.id;
      return `<tr data-id="${pid}">
        <td class="mono">${escapeHtml(x.label || "")}</td>
        <td class="mono">
          <span class="pw" data-shown="0" data-raw="${escapeAttr(
            x.password || ""
          )}">${mask(x.password || "")}</span>
          <button class="btn ghost btn-eye" title="Mostrar/Ocultar" style="margin-left:6px">👁️</button>
          <button class="btn ghost btn-copy" title="Copiar">📋</button>
        </td>
        <td>
          ${badge}
          <div class="muted" style="margin-top:4px">
            ${sug || '<span class="chip warn">Sin sugerencias</span>'}
          </div>
        </td>
        <td class="actions">
          <button class="btn" data-act="edit">Editar</button>
          <button class="btn danger" data-act="del">Eliminar</button>
        </td>
      </tr>`;
    })
    .join("");
  $rows.innerHTML =
    rows ||
    `<tr><td colspan="4" class="muted">No hay registros.</td></tr>`;
}
      

      $rows.addEventListener("click", async (e) => {
        const tr = e.target.closest("tr");
        if (!tr) return;
        const id = tr.getAttribute("data-id");
        const row = state.passwords.find((x) => String(x.id) === String(id));
        if (!row) return;

        if (e.target.classList.contains("btn-eye")) {
          const span = tr.querySelector(".pw");
          const shown = span.getAttribute("data-shown") === "1";
          if (shown) {
            span.textContent = mask(span.getAttribute("data-raw"));
            span.setAttribute("data-shown", "0");
          } else {
            span.textContent = span.getAttribute("data-raw");
            span.setAttribute("data-shown", "1");
          }
        }

        if (e.target.classList.contains("btn-copy")) {
          const raw = tr.querySelector(".pw").getAttribute("data-raw");
          try {
            await navigator.clipboard.writeText(raw);
            e.target.textContent = "✅";
            setTimeout(() => (e.target.textContent = "📋"), 800);
          } catch {}
        }

        const act = e.target.getAttribute("data-act");
        if (act === "edit") openModal(row);
        if (act === "del") confirmDelete(row);
      });

      $search.addEventListener("input", () => {
        state.filter = $search.value;
        renderRows();
      });

      // ======================================
      // 🪟 MODAL CREAR/EDITAR
      // ======================================
      const $modal = document.getElementById("modalEdit");
      const $modalTitle = document.getElementById("modalTitle");
      const $fLabel = document.getElementById("fLabel");
      const $fPassword = document.getElementById("fPassword");
      const $btnModalSave = document.getElementById("btnModalSave");
      const $modalEval = document.getElementById("modalEval");

      let currentEditing = null; // { id, label, password }

      function openModal(row) {
        currentEditing = row || { id: null, label: "", password: "" };
        $modalTitle.textContent = currentEditing.id
          ? "Editar contraseña"
          : "Nueva contraseña";
        $fLabel.value = currentEditing.label || "";
        $fPassword.value = currentEditing.password || "";
        $modal.classList.add("show");
        // Evaluación en caliente en el modal
        updateModalEval();
      }
      function closeModal() {
        $modal.classList.remove("show");
      }
      document
        .querySelectorAll("[data-close]")
        .forEach((el) => el.addEventListener("click", closeModal));

      $fPassword.addEventListener("input", updateModalEval);
      async function updateModalEval() {
        const pwd = $fPassword.value || "";
        if (!pwd) {
          $modalEval.textContent = "";
          return;
        }
        try {
          const ev = await evaluate(pwd);
          $modalEval.innerHTML =
            `${strengthBadge(ev.strength)} · score ${ev.score}/5 · ` +
            suggestionsList(ev.suggestions);
        } catch {
          $modalEval.textContent = "";
        }
      }

      document
        .getElementById("btnNew")
        .addEventListener("click", () => openModal(null));

      $btnModalSave.addEventListener("click", async () => {
        const label = $fLabel.value.trim();
        const password = $fPassword.value.trim();
        if (!label || !password) {
          alert("Etiqueta y contraseña son requeridas");
          return;
        }

        try {
          if (currentEditing && currentEditing.id) {
            // UPDATE
            const updated = await api(`/api/UserPassword/${currentEditing.id}`, {
              method: "PUT",
              body: JSON.stringify({ label, password }),
            });
            // Reemplazar en memoria
            const idx = state.passwords.findIndex(
              (x) => String(x.id) === String(currentEditing.id)
            );
            if (idx > -1) {
              state.passwords[idx] = updated;
            }
          } else {
            // CREATE
           const createdResp = await fetch(`${API_BASE}/api/UserPassword`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ label, password }),
          });
          const created = await createdResp.json();
          state.passwords.unshift(created);
          }
          renderRows();
          closeModal();
        } catch (err) {
          console.error(err);
          alert(
            "No se pudo guardar. Verifica que el endpoint /user/passwords exista."
          );
        }
      });

      async function confirmDelete(row) {
        if (!confirm(`¿Eliminar "${row.label}"?`)) return;
        try {
          await fetch(`${API_BASE}/api/UserPassword/${row.id}`, { method: "DELETE" });
          state.passwords = state.passwords.filter(
            (x) => String(x.id) !== String(row.id)
          );
          renderRows();
        } catch (err) {
          console.error(err);
          alert("No se pudo eliminar. Verifica tu endpoint DELETE.");
        }
      }

      // ======================================
      // 🔍 EVALUAR (panel rápido)
      // ======================================
      const $toEvaluate = document.getElementById("toEvaluate");
      const $btnEvaluate = document.getElementById("btnEvaluate");
      const $evalBox = document.getElementById("evalBox");

$btnEvaluate.addEventListener("click", async () => {
  $evalBox.textContent = "Evaluando...";
  try {
    const data = await evaluate($toEvaluate.value || "");
    const evalData = data.evaluation || {};
    const strength = evalData.strengthLevel || "—";
    const suggestions = evalData.suggestionMessage || [];

    $evalBox.innerHTML = `
      <div style="margin-bottom:6px">${strengthBadge(strength)}</div>
      <div class="muted">${suggestionsList(suggestions)}</div>
    `;
  } catch (err) {
    console.error(err);
    $evalBox.innerHTML =
      '<span style="color:#ff9b9b">No se pudo evaluar (revisa API_BASE/CORS)</span>';
  }
});

      // ======================================
      // 🚀 INICIO: Cargar lista
      // ======================================
      fetchPasswords();

      // ======================================
      // 🛡️ UTILIDADES
      // ======================================
      function escapeHtml(s) {
        return (s || "").replace(
          /[&<>"']/g,
          (m) =>
            ({
              "&": "&amp;",
              "<": "&lt;",
              ">": "&gt;",
              '"': "&quot;",
              "'": "&#39;",
            }[m])
        );
      }
      function escapeAttr(s) {
        return (s || "").replace(/"/g, "&quot;");
      }
  