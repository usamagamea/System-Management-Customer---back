using AutoMapper;
using BackTask.Database.Entities;
using BackTask.Dto;
using BackTask.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTask.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;


        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAllCountries()
        {
            try
            {
                var countries = await _countryRepository.GetAllCountries();
                var countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
                return Ok(countryDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/country/{id}
        [HttpGet("countries/{id}")]
        public async Task<ActionResult<CountryDto>> GetCountryById(int id)
        {
            try
            {
                var country = await _countryRepository.GetCountryById(id);
                if (country == null)
                {
                    return NotFound();
                }
                var countryDto = _mapper.Map<CountryDto>(country);
                return Ok(countryDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/country
        [HttpPost]
        public async Task<ActionResult<CountryDto>> CreateCountry(CreateCountryDto countryDto)
        {
            
            try
            {
                var country = _mapper.Map<Country>(countryDto);
                await _countryRepository.AddCountry(country);
                var createdCountryDto = _mapper.Map<CountryDto>(country);
                return Ok(createdCountryDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
