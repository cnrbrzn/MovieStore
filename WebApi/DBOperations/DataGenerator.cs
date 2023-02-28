using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(
                    new Movie{
                        Name = "Operation Fortune",
                        ReleaseDate = new DateTime(2023,01,13),
                        GenreID = 1,
                        DirectorID=1,
                        Price = 50
                    }
                );
                context.Genres.AddRange(
                    new Genre{
                        Name = "Action"
                    },
                    new Genre{
                        Name = "Adventure"
                    },
                    new Genre{
                        Name = "Comedy"
                    }
                );
                context.Directors.AddRange(
                    new Director{
                        FirstName = "Guy",
                        LastName = "Richie"
                    },
                    new Director{
                        FirstName = "Peyton",
                        LastName = "Reed"
                    }
                );
                context.Actors.AddRange(
                    new Actor{
                        FirstName = "Jason",
                        LastName = "Statham"
                    },
                    new Actor{
                        FirstName = "Aubrey",
                        LastName = "Plaza"
                    },
                    new Actor{
                        FirstName = "Hugh",
                        LastName = "Grant"
                    }
                );
                context.AddRange(
                    new ActorMovieJoint { ActorId = 1, MovieId = 1 },
                    new ActorMovieJoint { ActorId = 2, MovieId = 1 },
                    new ActorMovieJoint { ActorId = 3, MovieId = 1 }
                    );
                context.Customers.AddRange(
                    new Customer{
                        FirstName = "Caner",
                        LastName = "Borazan",
                        Email = "canerborazan@gmail.com",
                        Password = "12345",
                        Order = new List<Order>(),
                        FavoriteGenres = new List<Genre>()
                    }
                );
                context.Orders.AddRange(
                    new Order
                    {
                        CustomerId=1,
                        Movie=new List<Movie>(),
                        TotalPrice=50,
                        PurchaseDate=DateTime.Now
                    });

                context.SaveChanges();
            }
        }
    }
}