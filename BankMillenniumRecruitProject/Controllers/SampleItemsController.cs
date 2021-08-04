using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankMillenniumRecruitProject.Data;
using BankMillenniumRecruitProject.Data.Dto;
using BankMillenniumRecruitProject.Services;
using Microsoft.Extensions.Logging;

namespace BankMillenniumRecruitProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleItemsController : ControllerBase
    {
        private readonly ISampleItemService _sampleItemService;
        private readonly ILogger<SampleItemsController> _logger;

        public SampleItemsController(ISampleItemService sampleItemService, ILogger<SampleItemsController> logger)
        {
            _sampleItemService = sampleItemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleItemInfo>>> GetSampleItems()
        {
            _logger.LogInformation("GetSampleItems");
            return (await _sampleItemService.GetAllSampleItems()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SampleItemInfo>> GetSampleItem(long id)
        {
            _logger.LogInformation("GetSampleItem");
            var sampleItem = await _sampleItemService.GetSampleItem(id);

            if (sampleItem == null)
            {
                return NotFound();
            }

            return sampleItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleItem(long id, SampleItemInfo sampleItem)
        {
            _logger.LogInformation("PutSampleItem");
            if (id != sampleItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _sampleItemService.UpdateSampleItem(sampleItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _sampleItemService.IsSampleItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SampleItemInfo>> PostSampleItem(SampleItemInfo sampleItem)
        {
            _logger.LogInformation("PostSampleItem");
            var item = await _sampleItemService.AddSampleItem(sampleItem);

            return CreatedAtAction("GetSampleItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleItem(long id)
        {
            _logger.LogInformation("DeleteSampleItem");

            if (!await _sampleItemService.IsSampleItemExists(id))
            {
                return NotFound();
            }

            await _sampleItemService.RemoveSampleItem(id);
            
            return NoContent();
        }
    }
}
