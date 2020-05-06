namespace Reddit.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        public UserReddit UserReddit { get; set; }
        public bool Direction { get; set; } // true = like, false = dislike
        public int Like { get; set; }
        public int DisLike { get; set; }
    }
}
