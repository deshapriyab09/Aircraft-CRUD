using AircraftAPI.Services.Aircrafts;
using AircraftAPI.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AircraftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAiacraftService _aircraftService;
        private readonly IMapper _mapper;

        public AircraftController(IAiacraftService aircraftService , IMapper mapper)
        {
            _aircraftService = aircraftService;
            _mapper = mapper;
        }

        [HttpPost("AddAircraftPhoto")]
        [DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("GetAllAircraft")]
        public async Task<ActionResult<List<AircraftDto>>> GetAllAiacraftAsync()
        {
            var aircraftsdto = await _aircraftService.GetAllAiacraftAsync();
            return aircraftsdto;
        }

        [HttpPost("AddAircraft")]
        public async Task<ActionResult<AircraftDto>> Add ([FromBody]AircraftDto aircraftDto)
        {
            var aircraftsdto = await _aircraftService.AddAircraftAsync(aircraftDto);
            return aircraftsdto;
        }

        [HttpPost("UpdateAircraft")]
        public async Task<ActionResult<AircraftDto>> Update(AircraftDto aircraftDto)
        {
            var aircraftsdto = await _aircraftService.UpdateAircraftAsync(aircraftDto);
            return aircraftsdto;
        }

        [HttpDelete("DeleteAircraft")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _aircraftService.Delete(id);
        }

        [HttpGet]
        [Route("GetAircraftDetailsById")]
        public async Task<ActionResult<AircraftDto>> GetAircraftAsync(int id)
        {
            var aircraftsDto = await _aircraftService.GetAircraftAsync(id);
            if (aircraftsDto is null)
            {
                return NotFound();
            }
            return aircraftsDto;
        }

        [HttpGet("AircraftSearch")]
        public async Task<ActionResult<List<AircraftDto>>> GetAllAircraft(string search)
        {
            var aircrafts = await _aircraftService.AircraftSearch(search);

            return (aircrafts);
        }
    }
}
