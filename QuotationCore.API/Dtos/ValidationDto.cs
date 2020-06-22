using System.ComponentModel.DataAnnotations;

namespace QuotationCore.API.Dtos
{
    public class ValidationDto
    {
        public int Id { get; set; }
        [Required]
        public string ResponseTime { get; set; }
        public string Description { get; set; }
    }
}