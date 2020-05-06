using Reddit.Entities;
using System.Collections.Generic;

namespace Reddit.ViewModel
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts { get; internal set; }
    }
}
