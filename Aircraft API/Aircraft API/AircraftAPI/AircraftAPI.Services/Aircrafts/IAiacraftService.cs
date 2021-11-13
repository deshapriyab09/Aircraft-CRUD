using AircraftAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.Services.Aircrafts
{
    public interface IAiacraftService
    {
        public Task<List<AircraftDto>> GetAllAiacraftAsync();
        public Task<AircraftDto> AddAircraftAsync(AircraftDto aircraftDto);
        public Task<AircraftDto> UpdateAircraftAsync(AircraftDto aircraftDto);
        public Task<int> Delete(int id);
        public Task<AircraftDto> GetAircraftAsync(int aircraftId);
        public Task<List<AircraftDto>> AircraftSearch(string search);
    }
}
