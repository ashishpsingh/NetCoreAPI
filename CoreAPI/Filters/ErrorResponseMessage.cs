namespace CoreAPI.Filters
{
    public class ErrorResponseMessage
    {
        public ErrorResponseMessage()
        {
        }

        public string Message { get; set; }
        public string FriendlyMessage { get; set; }
        public string StackTrace { get; internal set; }
    }
}