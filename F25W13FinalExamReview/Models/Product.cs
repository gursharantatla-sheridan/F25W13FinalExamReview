namespace F25W13FinalExamReview.Models
{
    public class Product
    {
        // scalar
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public bool? IsDiscontinued { get; set; }
        public int? CategoryId { get; set; }

        // navigation
        public Category? Category { get; set; }
    }
}
