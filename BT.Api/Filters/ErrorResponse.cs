using System;

namespace BT.Api.Filters
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }

        public ErrorResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            Source = ex.Source;
            StackTrace = ex.ToString();
        }
    }
}
