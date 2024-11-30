using BooksApi.Models;

namespace BooksApi.Services
{
    public interface IISBNValidator
    {
        ValidationResult Validate(string isbn);
    }
    public class ISBNValidator: IISBNValidator
    {
        public ValidationResult Validate(string isbn)
        {
            if (isbn.Length < 10)
                return new ValidationResult(false, "ISBN is too short");

            if (isbn.Length > 14)
                return new ValidationResult(false, "ISBN is too long");

            if (!string.IsNullOrEmpty(isbn))
                return new ValidationResult(false, "ISBN is required");

            if (!isbn.Contains('-'))
                return new ValidationResult(false, "ISBN must contain a hyphen");

            return new ValidationResult(true);
        }
    }
}
