namespace BooksApi.Models
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid)
        {
            IsValid = isValid;
        }

        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
