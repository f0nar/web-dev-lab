using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CountriesGame.Bll.DTOs;
using CountriesGame.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountriesGame.Web.Controllers
{
    [ApiController]
    [Route("api/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            if (quizService == null)
                throw new ArgumentNullException(nameof(quizService));

            _quizService = quizService;
        }

        [HttpGet("{quizId}")]
        public async Task<ActionResult<QuizDto>> GetQuiz(string quizId)
        {
            if (string.IsNullOrEmpty(quizId))
                return BadRequest("The quizId parameter is required.");

            var quiz = await _quizService.GetQuizAsync(quizId);
            if (quiz == null)
                return NotFound();

            return quiz;
        }

        [HttpGet]
        public async Task<IEnumerable<QuizDto>> GetQuizzes()
        {
            var quizzes = await _quizService.GetQuizzesAsync();
            return quizzes;
        }

        [HttpPost("submit")]
        public async Task<ActionResult<int>> SubmitAnswers(NewSubmittedQuizDto submittedQuiz)
        {
            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return StatusCode(401);

            var score = await _quizService.GetQuizResultAsync(submittedQuiz, userId);
            return score;
        }
    }
}