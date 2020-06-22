using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotationCore.API.Dtos
{
    public class QuotationDto
    {
         public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        public List<ItemDto> Items { get; set; }
        [Required]
        public List<ValidationDto> Validations { get; set; }
    }
}