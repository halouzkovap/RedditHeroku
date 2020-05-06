using Reddit.Entities;
using System.Collections.Generic;

namespace Reddit.Servises
{
    public interface IPostService
    {
        IEnumerable<Post> Gell10BestPost();
        IEnumerable<Post> GetAllPost();
        IEnumerable<Post> FindPost(string searching);

        IEnumerable<Post> GetPostByUsername(string username);
        void CreatePost(Post post);
        Post GetPost(int id);
        void DeletePost(int id);
        void UpdatePost(Post post);

        public void Voting(int number, int id);
        void UpdatePost(int id, string titel, string postUrl, UserReddit currentUser);
    }
}
