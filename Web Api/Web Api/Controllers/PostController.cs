using BL;
using BL.Dtos.Post;
using BL.Managers;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly IPostManager _PostManager;
        public PostController(IPostManager postManager) {
            _PostManager = postManager;
        }

        [HttpGet]
        public ActionResult GetAllPosts()
        {
            List<PostReadDto> AllPosts = _PostManager.GetAllPosts();
            if (AllPosts == null)
            {
                return NotFound();
            }
            return Ok(AllPosts);
        }

        [HttpGet("UserPosts/{UserId}")]
        public ActionResult GetPostsForUser(string UserId)
        {
            List<PostReadDto> AllUserPosts = _PostManager.GetPostsForUser(UserId);
            if (AllUserPosts == null)
            {
                return NotFound();
            }
            return Ok(AllUserPosts);
        }

        [HttpGet("AcceptedOrder/{OrderId}")]
        public ActionResult GetPostAcceptedOrder(int OrderId)
        {
            AcceptedOrderReadDto AcceptedPostOrder = _PostManager.GetAcceptedPostOrder(OrderId);
            if (AcceptedPostOrder == null)
            {
                return NotFound();
            }
            return Ok(AcceptedPostOrder);
        }

        [HttpGet("{id}")]
        public ActionResult GetPostWithProposals(int id)
        {
            PostWithProposalsDto PostDetails = _PostManager.GetPostDetails(id);
            if (PostDetails == null)
            {
                return NotFound();
            }
            return Ok(PostDetails);
        }

        [HttpPost]
        public ActionResult AddPost(PostAddDto NewPost)
        {
            int NewID=_PostManager.AddPost(NewPost);
            return Ok(NewID);
        }

        [HttpPost("AcceptedOrder")]
        public ActionResult AddAcceptedPost(AcceptedOrderAddDto AcceptedOrder)
        {
            int NewID = _PostManager.AddAcceptedOrder(AcceptedOrder);
            return Ok(NewID);
        }
    }
}
