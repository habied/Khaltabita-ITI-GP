using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using BL.Managers.Chefs;
using BL.Dtos.Chefs;
using Microsoft.AspNetCore.Authorization;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IChefManager _chefManager;

        public ChefsController(IChefManager chefManager)
        {
            this._chefManager= chefManager;
        }

        // GET: api/Chefs
        [HttpGet]
        public async Task<ActionResult<List<ChefReadDto>>> GetChefs()
        {          
            return await _chefManager.GetAllChefs();
        }
        // GET: api/TopChefs

        [HttpGet]
        [Route("TopChefs")]
        public async Task<ActionResult<List<ChefReadDto>>> GetTopChefs()
        {
            return await _chefManager.GetTopChefs();
        }

        // GET: api/Chefs/5
        [HttpGet("{id}")]
        public ActionResult<ChefReadDto> GetChef(string id)
        {
            ChefReadDto? chef = _chefManager.GetChef(id);

            if (chef == null)
            {
                return NotFound();
            }

            return chef;
        }
        
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut("{id}")]
        public ActionResult<Chef> PostChef(string id,ChefUpdateDto chef)
        {

            if (id != chef.ChefId)
            {
                return BadRequest();
            }
            _chefManager.UpdateChef(chef);

            return NoContent();
        }

        // DELETE: api/Chefs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteChef(string id)
        {
            ChefReadDto? chef = _chefManager.GetChef(id);
            if (chef == null)
            {
                return NotFound();
            }
            _chefManager.DeleteChef(id);
            return NoContent();
        }

        // Get: api/Chefs/feedback
        [HttpGet]
        [Route("feedback")]
        public ActionResult<List<FeedbackDto>> getAllchefFeedbacks(string id)
        {
            List<FeedbackDto> feedbacks = _chefManager.getAllchefFeedbacks(id);

            if (feedbacks == null)
            {
                return NotFound();
            }

            return feedbacks;
        }

        // post: api/Chefs/feedback
        [HttpPost]
        [Authorize(Policy = "NormalUser")]
        [Route("feedback")]
        public ActionResult<FeedbackDto> AddFeedback(FeedbackDto feedback)
        {
            bool CanWeAddReview= _chefManager.AddFeedback(feedback);
            if (!CanWeAddReview) { return BadRequest("Can't add review today wait for 24hrs"); }

            return NoContent();
        }

    }
}
