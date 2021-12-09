using System;
using System.Threading.Tasks;
using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Exceptions;
using CountriesGame.Bll.Services.Interfaces;
using CountriesGame.Dal.Entities;
using CountriesGame.Dal.FileReaders.Interfaces;
using CountriesGame.Dal.UnitOfWorks.Interfaces;

namespace CountriesGame.Bll.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _db;

        private readonly IFileReader _reader;

        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IFileReader fileReader,
            IMapper mapper)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (fileReader == null)
                throw new ArgumentNullException(nameof(fileReader));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _db = unitOfWork;
            _reader = fileReader;
            _mapper = mapper;
        }

        public async Task<CountryDto> GetCountryAsync(string countryName)
        {
            if (countryName == null)
                throw new ArgumentNullException(nameof(countryName));

            var country = await _db.Countries.GetByNameAsync(countryName);
            
            return country != null ? _mapper.Map<CountryDto>(country) : null;
        }

        public async Task<byte[]> GetFlagAsync(string countryName)
        {
            if (countryName == null)
                throw new ArgumentNullException(nameof(countryName));
            
            var country = await _db.Countries.GetByNameAsync(countryName);
            if (country == null)
                throw new EntityNotFoundException(nameof(Country));

            var bytes = await _reader.ReadBytes(country.FlagPath);
            return bytes;
        }

        public async Task<byte[]> GetCoatAsync(string countryName)
        {
            if (countryName == null)
                throw new ArgumentNullException(nameof(countryName));
            
            var country = await _db.Countries.GetByNameAsync(countryName);
            if (country == null)
                throw new EntityNotFoundException(nameof(Country));

            var bytes = await _reader.ReadBytes(country.CoatPath);
            return bytes;
        }

        public async Task<byte[]> GetAnthemAsync(string countryName)
        {
            if (countryName == null)
                throw new ArgumentNullException(nameof(countryName));
            
            var country = await _db.Countries.GetByNameAsync(countryName);
            if (country == null)
                throw new EntityNotFoundException(nameof(Country));

            var bytes = await _reader.ReadBytes(country.AnthemPath);
            return bytes;
        }
    }
}