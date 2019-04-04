using System.Collections.Generic;

namespace Northwind.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        // Navigation property linking Category to Products table
        public ICollection<Product> Products { get; set; }
    }
}
