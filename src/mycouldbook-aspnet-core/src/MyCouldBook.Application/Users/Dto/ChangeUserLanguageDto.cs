using System.ComponentModel.DataAnnotations;

namespace MyCouldBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}