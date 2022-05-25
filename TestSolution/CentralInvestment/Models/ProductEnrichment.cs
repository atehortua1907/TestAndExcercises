using System;

namespace CentralInvestmentUploadProductDescription.Models
{
    public class ProductEnrichment
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string WebsiteId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Url { get; set; }
        public ProductEnrichmentData ProductEnrichmentData { get; set; }
    }
}
