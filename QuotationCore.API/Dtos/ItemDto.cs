using System.ComponentModel.DataAnnotations;

namespace QuotationCore.API.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        public string Detailing { get; set; }
        [Required]
        public decimal quantity { get; set; }
        [Required]
        public string UnitOfMeasure { get; set; }
        public int NCM { get; set; }
        public string PartNumber { get; set; }
    }
}