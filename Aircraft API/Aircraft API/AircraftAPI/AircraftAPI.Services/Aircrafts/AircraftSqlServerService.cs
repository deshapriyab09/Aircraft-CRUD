using AircraftAPI.DataAccess.Repositories;
using AircraftAPI.Services.Models;
using ArcraftAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.Services.Aircrafts
{
    public class AircraftSqlServerService : IAiacraftService
    {
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IMapper _mapper;

        public AircraftSqlServerService(IAircraftRepository aircraftRepository , IMapper mapper)
        {
            _aircraftRepository = aircraftRepository;
            _mapper = mapper;
        }

        public async Task<List<AircraftDto>> GetAllAiacraftAsync()
        {
            var result = await _aircraftRepository.GetAllAsync();
            var aircraftDto = _mapper.Map<List<Aircraft>, List<AircraftDto>>(result.ToList());
            return aircraftDto;
        }

        public async Task<AircraftDto> AddAircraftAsync (AircraftDto aircraftDto)
        {
            var aircraft = _mapper.Map<AircraftDto, Aircraft>(aircraftDto);
            await _aircraftRepository.AddAsync(aircraft);
            var aircraftdto = _mapper.Map<Aircraft, AircraftDto>(aircraft);
            return aircraftdto;
        }

        public async Task<AircraftDto> UpdateAircraftAsync(AircraftDto aircraftDto)
        {
            var aircraft = _mapper.Map<AircraftDto, Aircraft>(aircraftDto);
            await _aircraftRepository.UpdateAsync(aircraft,aircraft.Id);
            var aircraftdto = _mapper.Map<Aircraft, AircraftDto>(aircraft);
            return aircraftdto;
        }

        public async Task<int> Delete(int id)
        {
            var ac = await _aircraftRepository.GetAsync(id);
            return await _aircraftRepository.DeleteAsync(ac);
        }

        public async Task<AircraftDto> GetAircraftAsync(int aircraftId)
        {
            var result = await _aircraftRepository.GetAsync(aircraftId);
            var aircraftdto = _mapper.Map<Aircraft, AircraftDto>(result);
            return aircraftdto;
        }

        public async Task<List<AircraftDto>> AircraftSearch(string search)
        {
            var result = await _aircraftRepository.FindByAsync(ac => ac.Make.Contains(search) || ac.Model.Contains(search) || ac.Location.Contains(search) || ac.Registration.Contains(search));

            var aircraftdto = _mapper.Map<List<Aircraft>, List<AircraftDto>>(result.ToList());
            return aircraftdto;
        }
    }
}
