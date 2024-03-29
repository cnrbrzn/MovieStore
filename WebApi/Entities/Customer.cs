using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public List<Order> Order { get; set; }
        // public List<Genre> FavoriteGenres { get; set; } 
        public virtual ICollection<Genre> FavouriteGenres { get; set; }
        public virtual ICollection<Order> Orders { get; set; }       
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}