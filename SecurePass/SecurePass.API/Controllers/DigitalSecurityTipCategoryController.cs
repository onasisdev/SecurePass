using System;
using SecurePass.Infraestructure.Data;
using SecurePass.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurePass.Domain.Entities;

namespace SecurePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitalSecurityTipCategoryController : ControllerBase
    {
        private readonly SecurePassApplicationContext dbContext;

        public DigitalSecurityTipCategoryController(SecurePassApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllDigitalSecurityTipCategorys()
        {
            var alldigitalSecurityTipCategories = dbContext.DigitalSecurityTipCategories.ToList();

            return Ok(alldigitalSecurityTipCategories);
        }

        [HttpGet]
        [Route("id{id:int}")]

        public IActionResult GetDigitalSecurityTipCategorytById(int id)
        {
            var digitalSecurityTipCategory = dbContext.DigitalSecurityTipCategories.Find(id);

            if (digitalSecurityTipCategory is null)
            {
                return NotFound();
            }

            return Ok(digitalSecurityTipCategory);

        }

        [HttpPost]
        public IActionResult AddDigitalSecurityTipCategory(AddDigitalSecurityTipCategoryDto addDigitalSecurityTipCategoryDto)
        {
            var digitalSecurityTipCategoryEntity = new DigitalSecurityTipCategory
            {
                Id = addDigitalSecurityTipCategoryDto.Id,
                Name = addDigitalSecurityTipCategoryDto.Name,
                Description = addDigitalSecurityTipCategoryDto.Description,
            };

            dbContext.DigitalSecurityTipCategories.Add(digitalSecurityTipCategoryEntity);
            dbContext.SaveChanges();

            return Ok(digitalSecurityTipCategoryEntity);

        }

        [HttpPut]
        [Route("id{id:int}")]

        public IActionResult UpdateDigitalSecurityTipCategory(UpdateDigitalSecurityTipCategoryDto updateDigitalSecurityTipCategoryDto, int id)
        {
            var digitalSecurityTipCategory = dbContext.DigitalSecurityTipCategories.Find(id);

            if (digitalSecurityTipCategory is null)
            {
                return NotFound();
            }


            digitalSecurityTipCategory.Id = updateDigitalSecurityTipCategoryDto.Id;
            digitalSecurityTipCategory.Name = updateDigitalSecurityTipCategoryDto.Name;
            digitalSecurityTipCategory.Description = updateDigitalSecurityTipCategoryDto.Description;



            dbContext.SaveChanges();

            return Ok(digitalSecurityTipCategory);
        }


        [HttpDelete]
        [Route("id{id:int}")]
        public IActionResult DeleteDigitalSecurityTipCategory(int id)
        {
            var digitalSecurityTipCategory = dbContext.DigitalSecurityTipCategories.Find(id);

            if (digitalSecurityTipCategory is null)
            {
                NotFound();
            }

            dbContext.DigitalSecurityTipCategories.Remove(digitalSecurityTipCategory);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}