using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using CountriesGame.Dal.UnitOfWorks.Interfaces;

namespace CountriesGame.Bll.Services
{
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _db;
        
        private readonly IMapper _mapper;

        public LinkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));
                
            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LinkDto>> GetLinksByCountryIdAsync(string countryId)
        {
            if (countryId == null)
                throw new ArgumentNullException(nameof(countryId));

            var links = await _db.Links.GetByCountryIdAsync(countryId);
            var linkDtos = _mapper.Map<IEnumerable<LinkDto>>(links);
            
            return linkDtos;
        }
    }
}