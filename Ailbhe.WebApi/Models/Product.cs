﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Ailbhe.WebApi.Models
{
    public class Product
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Code is required", AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "Product Code min length is 8 characters")]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required", AllowEmptyStrings = false)]
        [MinLength(4, ErrorMessage = "Product Name min length is 4 characters")]
        [MaxLength(12, ErrorMessage = "Product Name max length is 12 characters")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}