using API.Models.Question;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    /// <summary>
    /// Controller for managing questions and answers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionController"/> class.
        /// </summary>
        /// <param name="questionService">The question service for handling business logic.</param>
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// Creates a new question with its answers.
        /// </summary>
        /// <param name="request">The question creation request.</param>
        /// <returns>The created question response.</returns>
        [HttpPost]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult<QuestionResponse>> CreateQuestion(CreateQuestionRequest request)
        {
            var schoolIdClaim = User.FindFirst("SchoolId");
            if (schoolIdClaim == null)
                return BadRequest(new { message = "SchoolId not found in token" });

            request.SchoolId = int.Parse(schoolIdClaim.Value);
            var question = await _questionService.CreateQuestionAsync(request);
            return Ok(question);
        }

        /// <summary>
        /// Updates an existing question with its answers.
        /// </summary>
        /// <param name="request">The question update request.</param>
        /// <returns>The updated question response.</returns>
        [HttpPut]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult<QuestionResponse>> UpdateQuestion(CreateQuestionRequest request)
        {
            var schoolIdClaim = User.FindFirst("SchoolId");
            if (schoolIdClaim == null)
                return BadRequest(new { message = "SchoolId not found in token" });

            request.SchoolId = int.Parse(schoolIdClaim.Value);
            var question = await _questionService.UpdateQuestionAsync(request);
            return Ok(question);
        }

        /// <summary>
        /// Creates or updates multiple questions.
        /// </summary>
        /// <param name="requests">The list of questions to create or update.</param>
        /// <param name="lessonId">The id of the lesson</param>
        /// <returns>A collection of created/updated question responses.</returns>
        [HttpPost("list/{lessonId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult<IEnumerable<QuestionResponse>>> CreateOrUpdateQuestions(List<CreateQuestionRequest> requests, double lessonId)
        {
            var schoolIdClaim = User.FindFirst("SchoolId");
            if (schoolIdClaim == null)
                return BadRequest(new { message = "SchoolId not found in token" });

            var schoolId = int.Parse(schoolIdClaim.Value);

            // Delete all existing questions for this lesson and school
            await _questionService.DeleteQuestionsByLessonAndSchoolIdAsync(lessonId, schoolId);

            if (!requests.Any())
                return Ok();

            // Create new questions
            var results = new List<QuestionResponse>();
            foreach (var request in requests)
            {
                request.SchoolId = schoolId;
                var result = await _questionService.CreateQuestionAsync(request);
                results.Add(result);
            }

            return Ok(results);
        }

        /// <summary>
        /// Retrieves all questions for a specific lesson and school.
        /// </summary>
        /// <param name="lessonId">The ID of the lesson.</param>
        /// <returns>A collection of questions with their answers (without correct answer information).</returns>
        [HttpGet("lesson/{lessonId}")]
        public async Task<ActionResult<IEnumerable<QuestionResponse>>> GetQuestionsByLessonId(double lessonId)
        {
            var schoolIdClaim = User.FindFirst("SchoolId");
            if (schoolIdClaim == null)
                return BadRequest(new { message = "SchoolId not found in token" });

            var schoolId = int.Parse(schoolIdClaim.Value);
            
            var standardQuestions = await _questionService.GetQuestionsByLessonAndSchoolIdAsync(lessonId, 0);
            var schoolQuestions = await _questionService.GetQuestionsByLessonAndSchoolIdAsync(lessonId, schoolId);
            
            var allQuestions = standardQuestions.Concat(schoolQuestions);
            
            return Ok(allQuestions);
        }

        /// <summary>
        /// Retrieves questions for a specific lesson and school without standart questions.
        /// </summary>
        /// <param name="lessonId">The ID of the lesson.</param>
        /// <returns>A collection of questions with their answers (without correct answer information).</returns>
        [HttpGet("lesson/edit/{lessonId}")]
        public async Task<ActionResult<IEnumerable<QuestionResponse>>> GetQuestionsByLessonIdForEdit(double lessonId)
        {
            var schoolIdClaim = User.FindFirst("SchoolId");
            if (schoolIdClaim == null)
                return BadRequest(new { message = "SchoolId not found in token" });

            var schoolId = int.Parse(schoolIdClaim.Value);

            var schoolQuestions = await _questionService.GetQuestionsByLessonAndSchoolIdAsync(lessonId, schoolId);

            return Ok(schoolQuestions);
        }

        /// <summary>
        /// Checks student's answers and returns the score.
        /// </summary>
        /// <param name="request">The request containing answers to check.</param>
        /// <returns>The number of correct answers.</returns>
        [HttpPost("check")]
        public async Task<ActionResult<int>> CheckAnswers(CheckAnswersRequest request)
        {
            var score = await _questionService.CheckAnswersAsync(request);
            return Ok(score);
        }
    }
} 