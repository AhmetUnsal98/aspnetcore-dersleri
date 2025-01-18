using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stok_takip_app.Models
{
    public class ProductViewModel
    {
        public List<Product>? Products { get; set; } = null!;

        public List<Category>? Categories { get; set; }= null!;

        public string? SelectedCategory { get; set; }

        public string? SearchString {get;set;}
    }
}