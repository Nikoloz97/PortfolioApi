﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("api/forum")]
    public class ProfileCardController : Controller
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ProfileCardController(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileCardDtoWithoutInterestsDto>>> GetAllProfileCards()
        {
            // TODO: Create bool expression for interests (like getting singular PC)

            var profileCardEntities = await _forumRepository.GetAllProfileCardsAsync();
            return Ok(_mapper.Map<IEnumerable<ProfileCardDtoWithoutInterestsDto>>(profileCardEntities));
        }

        [HttpGet("{profileCardId}")]
        public async Task<ActionResult<IEnumerable<ProfileCardDtoWithoutInterestsDto>>> GetProfileCard(int profileCardId, bool areInterestsIncluded)
        {
 
            var profileCardEntity = await _forumRepository.GetProfileCardAsync(profileCardId, areInterestsIncluded);
            if (areInterestsIncluded)
            {
                var result = new ProfileCardDto()
                {
                    Id = profileCardEntity.Id,
                    Age = profileCardEntity.Age,
                    FirstName = profileCardEntity.FirstName,
                    LastName = profileCardEntity.LastName,
                    Interests = profileCardEntity.Interests,
                };
                return Ok(result);
            }
            else
            {
                var result = new ProfileCardDtoWithoutInterestsDto()
                {
                    Id = profileCardEntity.Id,
                    Age = profileCardEntity.Age,
                    FirstName = profileCardEntity.FirstName,
                    LastName = profileCardEntity.LastName,
                };
                return Ok(result);
            }


        }
    }
}
