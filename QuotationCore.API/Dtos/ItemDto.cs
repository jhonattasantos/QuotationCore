namespace QuotationCore.API.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Detailing { get; set; }
        public decimal quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public int NCM { get; set; }
        public string PartNumber { get; set; }
    }
}