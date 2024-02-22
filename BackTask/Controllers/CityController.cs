using AutoMapper;
using BackTask.Database.Entities;
using BackTask.Dto;
using BackTask.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BackTask.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;


        public CityController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllCities()
        {
            try
            {
                var cities = await _cityRepository.GetAllCities();
                var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);
                return Ok(cityDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/city/{id}
        [HttpGet("cities/{id}")]
        public async Task<ActionResult<CityDto>> GetCityById(int id)
        {
            try
            {
                var city = await _cityRepository.GetCityById(id);
                if (city == null)
                {
                    return NotFound();
                }
                var cityDto = _mapper.Map<CityDto>(city);
                return Ok(cityDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("cities/GetAllCitiesByCountryId/{countryId}")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllCitiesByCountryId(int countryId)
        {
            try
            {
                var cities = await _cityRepository.GetAllCitiesByCountryId(countryId);
                var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);
                return Ok(cityDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/city
        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCity(CreateCityDto cityDto)
        {
            try
            {
                var city = _mapper.Map<City>(cityDto);
                await _cityRepository.AddCity(city);
                var createdCityDto = _mapper.Map<CityDto>(city);
                return Ok(createdCityDto);
            }
            catch (InvalidOperationException)
            {
                return Conflict($"A City with the same name '{cityDto.Name}' already exists.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
