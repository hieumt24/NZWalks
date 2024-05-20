using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Request
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minumun of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximun of 3 chacracters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximun of 100 chacreacters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}