using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Yoon.Models
{
    public class AddingMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be after 1888.")]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string? Lent_To { get; set; }
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
