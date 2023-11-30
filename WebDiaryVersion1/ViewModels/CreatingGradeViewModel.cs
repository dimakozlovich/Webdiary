using System.ComponentModel.DataAnnotations;

namespace WebDiaryVersion1.ViewModels
{
    public class CreatingGradeViewModel
    {
        [Required]
        public string? GradeName { get; set; }
    }
}
