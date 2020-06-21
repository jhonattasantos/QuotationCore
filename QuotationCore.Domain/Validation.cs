using System;

namespace QuotationCore.Domain
{
    public class Validation
    {
        public int Id { get; set; }
        public DateTime ResponseTime { get; set; }
        public string Description { get; set; }
        public int QuotationId { get; set; }
        public Quotation Quotation { get; }
    }
}