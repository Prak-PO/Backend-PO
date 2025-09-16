using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_PO.DTOs.Requests;
using Backend_PO.Interfaces;
using Backend_PO.Models;

namespace Backend_PO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetAllFeedback()
        {
            var feedbackList = await _feedbackService.GetAllFeedbackAsync();
            return Ok(feedbackList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);

            if (feedback == null)
                return NotFound();

            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            var createdFeedback = await _feedbackService.CreateFeedbackAsync(request);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = createdFeedback.Id }, createdFeedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] UpdateFeedbackRequest request)
        {
            var success = await _feedbackService.UpdateFeedbackAsync(id, request);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var success = await _feedbackService.DeleteFeedbackAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}