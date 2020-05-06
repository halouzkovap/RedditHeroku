using Microsoft.EntityFrameworkCore;
using Reddit.DBServis;
using Reddit.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Reddit.Servises
{
    public class PostService : IPostService
    {
        private readonly RedditDbContext db;

        public PostService(RedditDbContext db)
        {
            this.db = db;
        }
        public void CreatePost(Post post)
        {
            db.Add(post);
            db.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var post = GetPost(id);
            db.Posts.Remove(post);
            db.SaveChanges();
        }

        public IEnumerable<Post> FindPost(string searching)
        {
            return db.Posts.Where(p => p.Titel.Contains(searching) || p.PostUrl.Contains(searching));
        }

        public IEnumerable<Post> Gell10BestPost()
        {
            return db.Posts.OrderByDescending(p => p.Like).Take(10);
        }

        public IEnumerable<Post> GetAllPost()
        {
            return db.Posts.OrderBy(p => p.Like);

        }

        public Post GetPost(int id)
        {
            return db.Posts.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetPostByUsername(string username)
        {
            return db.Posts.Where(u => u.UserReddit.UserName == username);

        }

        public void UpdatePost(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdatePost(int id, string titel, string postUrl, UserReddit currentUser)
        {
            var post = db.Posts.FirstOrDefault(p => p.Id == id);
            post.Titel = titel;
            post.PostUrl = postUrl;
            db.SaveChanges();

        }

        public void Voting(int number, int id)
        {
            var post = db.Posts.FirstOrDefault(p => p.Id == id);
            post.Like += number;
            if (post.Like < 0)
            {
                post.Like = 0;

            }
            db.Update(post);
            db.SaveChanges();
        }
    }
}
