using System.ComponentModel.DataAnnotations;

namespace PhotosAPI.Attributes
{
    public class AllowedFileExtentionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtentions;

        public AllowedFileExtentionsAttribute(string[] allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extention = Path.GetExtension(file.FileName);

                if (!_allowedExtentions.Contains(extention))
                {
                    return new ValidationResult($"Allowed extentions are {string.Join(" ", _allowedExtentions)}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
