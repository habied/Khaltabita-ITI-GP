using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PostRepo : IPostRepo
    {   
        private readonly FoodyContext _foodyContext;
        public PostRepo(FoodyContext foodyContext) { 
        
            _foodyContext= foodyContext;
        }

        public void AddAcceptedOrder(PostAcceptedOrder NewAcceptedPost)
        {
            NewAcceptedPost.Id = _foodyContext.Set<PostAcceptedOrder>()
                                      .OrderByDescending(x => x.Id)
                                      .Select(x => x.Id)
                                      .FirstOrDefault() + 1;
            Cart NewCart = new Cart();
            NewCart.PostAcceptedOrderId = NewAcceptedPost.Id;
            NewCart.OrderDate = DateTime.Now;
            NewCart.DeliveryDate = DateTime.Now;
            NewCart.UserMobile = NewAcceptedPost.UserId;
            NewCart.TotalPrice = NewAcceptedPost.FinalPrice;
            NewCart.ChefId = NewAcceptedPost.ChefId;
            NewCart.Id = _foodyContext.Set<Cart>()
                                      .OrderByDescending(x => x.Id)
                                      .Select(x => x.Id)
                                      .FirstOrDefault() + 1;
            string Location = _foodyContext.Set<User>().Where(x => x.Id == NewAcceptedPost.UserId)
                                    .Select(x => x.Address)
                                    .FirstOrDefault();
            NewCart.Location = Location;
            _foodyContext.Set<Cart>().Add(NewCart);
            _foodyContext.Set<PostAcceptedOrder>().Add(NewAcceptedPost);

        }

        public void AddPost(Post NewPost)
        {
            NewPost.Id = _foodyContext.Set<Post>()
                                      .OrderByDescending(x => x.Id)
                                      .Select(x => x.Id)
                                      .FirstOrDefault() + 1;
            _foodyContext.Set<Post>().Add(NewPost);
        }

        public List<Post> GetAllPosts()
        {
            return _foodyContext.Set<Post>().Include(d => d.User).Where(x => x.PostState == "Open").ToList();
        }

        public List<Post> GetAllUserPosts(string UserId)
        {
            return _foodyContext.Set<Post>().Include(d => d.User).Where(x => x.PostState == "Open" && x.User.Id==UserId).ToList();
        }

        public PostAcceptedOrder GetPostAcceptedOrder(int OrderId)
        {
            return _foodyContext.Set<PostAcceptedOrder>().Where(x => x.Id == OrderId).FirstOrDefault();
        }

        public Post GetPostById(int id)
        {
            return _foodyContext.Set<Post>().Where(x => x.Id == id).FirstOrDefault();
        }

        public Post GetPostDetails(int id)
        {
            return _foodyContext.Set<Post>().Include(x => x.User).Include(d => d.Proposals).ThenInclude(x=>x.Chef).Where(x => x.Id == id).Where(x => x.PostState == "Open").FirstOrDefault();
        }

        public void UpdatePost(Post post)
        {
        }

        public int SaveChanges()
        {
           return _foodyContext.SaveChanges();
        }
    }
}
