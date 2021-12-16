using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CountriesGame.Web.Controllers
{
    [ApiController]
    [Route("api/statistic")]
    [Authorize(Roles = "Lecturer")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            if (statisticService == null)
                throw new ArgumentNullException(nameof(statisticService));

            _statisticService = statisticService;
        }

        [HttpGet("{quizId}")]
        public async Task<ActionResult<StatisticDto>> GetStatistic(string quizId)
        {
            if (quizId == null)
                return BadRequest("The quizId parameter is required");

            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return StatusCode(401);

            var statistic = await _statisticService.GetStatisticByHeadId(quizId, userId);
            return statistic;
        }
    }
}