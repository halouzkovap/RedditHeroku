using System;
using System.Collections.Generic;

namespace Reddit.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string PostUrl { get; set; }
        public DateTime PostingDate { get; set; }
        public UserReddit UserReddit { get; set; }
        public int Like { get; set; } // possibility how coutn likes
        public List<Opinion> Opinions { get; set; }
    }
}
