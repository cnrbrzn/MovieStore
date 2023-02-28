using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<Movie> Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float TotalPrice { get; set; }
    }
}