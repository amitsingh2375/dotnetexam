using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMvc.Models
{
    public class Product
    {
        [Display(AutoGenerateField =true)]
        public int ProductId { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage =" enter correct product name")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

         [Display(Name = "Rate ")]
        [Required(ErrorMessage =" enter correct rate ")]
        [DataType(DataType.Text)]
        public Decimal Rate { get; set; }

        [Display(Name = "Description Name")]
        [Required(ErrorMessage = " enter correct description name")]
        [DataType(DataType.Text)]
        public string Description { get; set; }


        [Display(Name = "Category Name")]
        [Required(ErrorMessage = " enter correct cateogry name")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }





    }
}