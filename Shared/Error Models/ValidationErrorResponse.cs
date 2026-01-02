namespace Shared.Error_Models
{
    public class ValidationErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMesssage { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
