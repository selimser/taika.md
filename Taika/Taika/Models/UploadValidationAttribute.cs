using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Taika.Models
{
    public class UploadValidationAttribute : ValidationAttribute
    {
        private string[] AllowedExtensions { get; }

        public UploadValidationAttribute(string[] allowedExtensions)
        {
            AllowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = (IBrowserFile)value;

            var extension = Path.GetExtension(file.Name);

            if (!AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult($"File must have one of the following extensions: {string.Join(", ", AllowedExtensions)}.", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
