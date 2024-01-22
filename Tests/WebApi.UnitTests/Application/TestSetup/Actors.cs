using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
                new Actor {
                    
                }
            );
                    
        }
    }
}