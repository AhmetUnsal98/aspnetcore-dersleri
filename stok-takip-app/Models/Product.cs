using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace stok_takip_app.Models
{
    public class Product
    {
        [Display(Name="Ürün ID")]
        [BindNever]
        public int ProductId { get; set; }
        [Display(Name="Ürün Adi")]
        [Required]
        public string? Name { get; set; }
        [Display(Name="Ürün Fiyati")]
        public decimal Price { get; set; }
         [Display(Name="Ürün Resmi")]
        public string? Image { get; set; }
        [Display(Name="Ürün Durumu")]
        public bool IsActive { get; set; }  

        public int CategoryId { get; set; }


        
    }

}