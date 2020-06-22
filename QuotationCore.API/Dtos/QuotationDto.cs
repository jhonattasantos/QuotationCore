using System.Collections.Generic;

namespace QuotationCore.API.Dtos
{
    public class QuotationDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public List<ItemDto> Items { get; set; }
        public List<ValidationDto> Validations { get; set; }
    }
}