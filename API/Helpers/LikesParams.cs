namespace API.Helpers
{
    public class LikesParams : PaginationParamas
    {
        public int UserID { get; set; }
        public string Predicate { get; set; }
    }
}