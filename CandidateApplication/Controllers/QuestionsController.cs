using CandidateApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionDTO questionDto)
        {
            if (questionDto == null)
            {
                return BadRequest("Question data is missing.");
            }

            var question = new Question
            {
                QuestionID = questionDto.QuestionID ?? Guid.NewGuid().ToString(),
                Type = questionDto.Type,
                QuestionText = questionDto.QuestionText,
                Choices = questionDto.Choices,
                EnableOtherOption = questionDto.EnableOtherOption,
                MaxChoicesAllowed = questionDto.MaxChoicesAllowed
            };

            try
            {
                await _questionService.CreateQuestionAsync(question);
                return CreatedAtAction(nameof(GetQuestionsByType), new { type = question.Type }, question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Questions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, [FromBody] QuestionDTO questionDto)
        {
            if (questionDto == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("Question data or ID is missing.");
            }

            var question = new Question
            {
                QuestionID = id,
                Type = questionDto.Type,
                QuestionText = questionDto.QuestionText,
                Choices = questionDto.Choices,
                EnableOtherOption = questionDto.EnableOtherOption,
                MaxChoicesAllowed = questionDto.MaxChoicesAllowed
            };

            try
            {
                await _questionService.UpdateQuestionAsync(id, question);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Questions/type/{type}
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetQuestionsByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Question type is missing.");
            }

            try
            {
                var questions = await _questionService.GetQuestionsByTypeAsync(type);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
