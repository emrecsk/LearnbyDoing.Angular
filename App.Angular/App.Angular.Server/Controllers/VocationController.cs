using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Application.Interfaces;
using TaskApp.Application.Models;

namespace App.Angular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocationController : ControllerBase
    {
        private readonly IVocationService _vocationService;

        public VocationController(IVocationService vocationService)
        {
            _vocationService = vocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVocations()
        {
            var vocations = await _vocationService.GetVocationsAsync();
            return Ok(vocations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVocationById(int id)
        {
            var vocation = await _vocationService.GetVocationByIdAsync(id);
            return Ok(vocation);
        }

        [HttpPost]
        public async Task<IActionResult> AddVocation([FromBody] VocationDto vocationDto)
        {
            var addedVocation = await _vocationService.AddVocationAsync(vocationDto);
            return Ok(addedVocation);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVocation([FromBody] VocationDto vocationDto)
        {
            var updated = await _vocationService.UpdateVocationAsync(vocationDto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVocation(int id)
        {
            var deleted = await _vocationService.DeleteVocationAsync(id);
            return Ok(deleted);
        }
    }
}
