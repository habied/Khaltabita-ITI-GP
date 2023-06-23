using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;


namespace DAL
{
    public interface IPostRepo
    {
        void AddPost(Post NewPost);
        List<Post> GetAllPosts();
        List<Post> GetAllUserPosts(string UserId);
        Post GetPostDetails(int id);
        PostAcceptedOrder GetPostAcceptedOrder(int OrderId);
        void AddAcceptedOrder(PostAcceptedOrder NewAcceptedPost);
        int SaveChanges();
        Post GetPostById(int id);
        void UpdatePost(Post NewPost);
    }
}
