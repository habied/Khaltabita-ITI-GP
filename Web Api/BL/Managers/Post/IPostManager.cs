using BL.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public interface IPostManager
    {
        public int AddPost(PostAddDto NewPost);
        public List<PostReadDto> GetAllPosts();
        public List<PostReadDto> GetPostsForUser(string id);
        public PostWithProposalsDto GetPostDetails(int id);
        public AcceptedOrderReadDto GetAcceptedPostOrder(int OrderId);
        public int AddAcceptedOrder(AcceptedOrderAddDto AcceptedOrder);

    }
}
