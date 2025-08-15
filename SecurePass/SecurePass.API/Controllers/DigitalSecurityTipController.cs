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
    public class DigitalSecurityTipController : ControllerBase
    {
        private readonly SecurePassApplicationContext dbContext;

        public DigitalSecurityTipController(SecurePassApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllDigitalSecurityTips()
        {
            var alldigitalSecurityTips = dbContext.DigitalSecurityTips.ToList();

            return Ok(alldigitalSecurityTips);
        }

        [HttpGet]
        [Route("id{id:int}")]

        public IActionResult GetDigitalSecurityTiptById(int id)
        {
            var digitalSecurityTip = dbContext.DigitalSecurityTips.Find(id);

            if (digitalSecurityTip is null)
            {
                return NotFound();
            }

            return Ok(digitalSecurityTip);

        }

        [HttpPost]
        public IActionResult AddDigitalSecurityTip(AddDigitalSecurityTipDto addDigitalSecurityTipDto)
        {
            var digitalSecurityTipEntity = new DigitalSecurityTip
            {
                Id = addDigitalSecurityTipDto.Id,
                GoodPractice = addDigitalSecurityTipDto.GoodPractice,
            };

            dbContext.DigitalSecurityTips.Add(digitalSecurityTipEntity);
            dbContext.SaveChanges();

            return Ok(digitalSecurityTipEntity);

        }

        [HttpPut]
        [Route("id{id:int}")]

        public IActionResult UpdateDigitalSecurityTip(UpdateDigitalSecurityTipDto updateDigitalSecurityTipDto, int id)
        {
            var digitalSecurityTip = dbContext.DigitalSecurityTips.Find(id);

            if (digitalSecurityTip is null)
            {
                return NotFound();
            }


            digitalSecurityTip.Id = updateDigitalSecurityTipDto.Id;
            digitalSecurityTip.GoodPractice = updateDigitalSecurityTipDto.GoodPractice;


            dbContext.SaveChanges();

            return Ok(digitalSecurityTip);
        }


        [HttpDelete]
        [Route("id{id:int}")]
        public IActionResult DeleteDigitalSecurityTip(int id)
        {
            var digitalSecurityTip = dbContext.DigitalSecurityTips.Find(id);

            if (digitalSecurityTip is null)
            {
                NotFound();
            }

            dbContext.DigitalSecurityTips.Remove(digitalSecurityTip);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}