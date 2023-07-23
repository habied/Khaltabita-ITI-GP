using BL.Dtos.Post;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BL.Managers
{
    public class PostManager : IPostManager
    {
        public readonly IPostRepo _postRepo;
        public PostManager(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public int AddAcceptedOrder(AcceptedOrderAddDto AcceptedOrder)
        {
            PostAcceptedOrder NewAcceptedPost = new PostAcceptedOrder
            {
                Description = AcceptedOrder.Description,
                FinalPrice = AcceptedOrder.FinalPrice,
                QuantityUnit = AcceptedOrder.QuantityUnit,
                Quantity = AcceptedOrder.Quantity,
                DeliveryDate = AcceptedOrder.PrepTime,
                AdditionalInfo = AcceptedOrder.AdditionalInfo,
                PostId = AcceptedOrder.PostId,
                ProposalId = AcceptedOrder.ProposalId,
                ChefId = AcceptedOrder.ChefId,
                UserId = AcceptedOrder.UserId,
            };
            _postRepo.AddAcceptedOrder(NewAcceptedPost);
            Post ClosedPost = _postRepo.GetPostById(AcceptedOrder.PostId);
            ClosedPost.PostState = "Closed";
            _postRepo.UpdatePost(ClosedPost);
            _postRepo.SaveChanges();
            return NewAcceptedPost.Id;
        }

        public int AddPost(PostAddDto NewPostDto)
        {
            Post NewPost = new Post
            {
                UserId = NewPostDto.UserId,
                Description = NewPostDto.Description,
                FromPrice = NewPostDto.FromPrice,
                ToPrice = NewPostDto.ToPrice,
                DeliveryDate=NewPostDto.PrepTime,
                Quantity = NewPostDto.Quantity,
                QuantityUnit = NewPostDto.QuantityUnit,
            };
            _postRepo.AddPost(NewPost);
            _postRepo.SaveChanges();
            return NewPost.Id;
        }

        public AcceptedOrderReadDto GetAcceptedPostOrder(int OrderId)
        {
            PostAcceptedOrder PostAcceptedOrder = _postRepo.GetPostAcceptedOrder(OrderId);
            AcceptedOrderReadDto AcceptedOrderReadDto=new AcceptedOrderReadDto();
            if (PostAcceptedOrder != null)
            {
                AcceptedOrderReadDto = new AcceptedOrderReadDto
                {
                    Id = PostAcceptedOrder.Id,
                    Description = PostAcceptedOrder.Description,
                    FinalPrice = PostAcceptedOrder.FinalPrice,
                    QuantityUnit = PostAcceptedOrder.QuantityUnit,
                    Quantity = PostAcceptedOrder.Quantity,
                    PreparationTime_min = PostAcceptedOrder.DeliveryDate,
                    Date = PostAcceptedOrder.Date,
                    AdditionalInfo = PostAcceptedOrder.AdditionalInfo,
                    ChefId = PostAcceptedOrder.ChefId,
                    UserId = PostAcceptedOrder.UserId,
                };
                
                return AcceptedOrderReadDto;
            }
            return null;

        }

        public List<PostReadDto> GetAllPosts()
        {
            List<Post> AllPosts = _postRepo.GetAllPosts();
            List<PostReadDto> AllPostsDto = new List<PostReadDto>();
            if (AllPosts.Count > 0)
            {
                foreach (Post post in AllPosts)
                {
                    AllPostsDto.Add(new PostReadDto
                    {
                        PostID=post.Id,
                        Description = post.Description,
                        FromPrice = post.FromPrice,
                        ToPrice = post.ToPrice,
                        PrepTime=post.DeliveryDate,
                        QuantityUnit = post.QuantityUnit,
                        Quantity = post.Quantity,
                        Date = post.Date,
                        Username = post.User.Name,
                        UserAddress = post.User.Address
                    });
                }
                return AllPostsDto;
            }
            return null;
        }

        public PostWithProposalsDto GetPostDetails(int id)
        {
            Post PostDetails = _postRepo.GetPostDetails(id);
            if (PostDetails != null)
            {
                return new PostWithProposalsDto
                {
                    postReadDto = new PostReadDto
                    {
                        Description = PostDetails.Description,
                        FromPrice = PostDetails.FromPrice,
                        ToPrice = PostDetails.ToPrice,
                        QuantityUnit = PostDetails.QuantityUnit,
                        Quantity = PostDetails.Quantity,
                        PrepTime=PostDetails.DeliveryDate,
                        Date = PostDetails.Date,
                        UserId=PostDetails.User.Id,
                        Username = PostDetails.User.Name,
                        UserAddress = PostDetails.User.Address
                    },
                    ProposalsDto = PostDetails.Proposals.Select(p => new ProposalReadDto
                    {   Id=p.Id,
                        Price = p.Price,
                        Description = p.Description,
                        DatePosted = p.Date,
                        ChefId=p.ChefId,
                        ChefName = p.Chef.Name,
                        ChefRating = p.Chef.Rating,
                        ChefPhoto = p.Chef.Media
                    }).ToList()
                };
            }
            return null;
        }

        public List<PostReadDto> GetPostsForUser(string UserId)
        {
            List<Post> AllUserPosts = _postRepo.GetAllUserPosts(UserId);
            List<PostReadDto> AllUserPostsDto = new List<PostReadDto>();
            if (AllUserPosts.Count > 0)
            {
                foreach (Post post in AllUserPosts)
                {
                    AllUserPostsDto.Add(new PostReadDto
                    {
                        PostID = post.Id,
                        Description = post.Description,
                        FromPrice = post.FromPrice,
                        ToPrice = post.ToPrice,
                        QuantityUnit = post.QuantityUnit,
                        Quantity = post.Quantity,
                        PrepTime=post.DeliveryDate,
                        Date = post.Date,
                        Username = post.User.Name,
                        UserAddress = post.User.Address
                    });
                }
                return AllUserPostsDto;
            }
            return null;
        }
    }
}
