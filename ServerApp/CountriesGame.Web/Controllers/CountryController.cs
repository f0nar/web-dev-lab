using System;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountriesGame.Web.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            if (countryService == null)
                throw new ArgumentNullException(nameof(countryService));

            _countryService = countryService;
        }

        [HttpGet("info/{countryName}")]
        public async Task<ActionResult<CountryDto>> GetInfo(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return BadRequest("The countryName parameter is required.");

            var country = await _countryService.GetCountryAsync(countryName);
            if (countryName == null)
                return NotFound();

            return country;
        }

        [HttpGet("flag/{countryName}")]
        public async Task<IActionResult> GetFlag(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return BadRequest("The countryName parameter is required.");

            var bytes = await _countryService.GetFlagAsync(countryName);
            string fileType = "image/svg+xml";
            string fileName = $"{countryName}-flag.jpg";

            return File(bytes, fileType, fileName);
        }

        [HttpGet("coat/{countryName}")]
        public async Task<IActionResult> GetCoat(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return BadRequest("The countryName parameter is required.");

            var bytes = await _countryService.GetCoatAsync(countryName);
            string fileType = "image/svg+xml";
            string fileName = $"{countryName}-coat.jpg";

            return File(bytes, fileType, fileName);
        }

        [HttpGet("anthem/{countryName}")]
        public async Task<IActionResult> GetAnthem(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return BadRequest("The countryName parameter is required.");

            var bytes = await _countryService.GetAnthemAsync(countryName);
            string fileType = "audio/mpeg";
            string fileName = $"{countryName}-anthem.mp3";

            return File(bytes, fileType, fileName);
        }
    }
}