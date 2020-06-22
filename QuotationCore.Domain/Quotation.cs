using System;
using System.Collections.Generic;

namespace QuotationCore.Domain
{
    public class Quotation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Item> Items { get; set; }
        public List<Validation> Validations { get; set; }
    }
}