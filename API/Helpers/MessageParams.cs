namespace API.Helpers
{
    public class MessageParams : PaginationParamas
    {
        public string Username { get; set; }

        public string Container { get; set; } = "Unread";
    }
}