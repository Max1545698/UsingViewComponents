using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Models
{
   public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City city);
    }

    public class MemoryCityRepository : ICityRepository
    {
        private UsingViewComponentsDbContext context;

        //private List<City> cities = new List<City>
        //{
        //    new City{Name = "London", Country = "UK", Population = 8539000},
        //    new City{Name = "New Yourk", Country = "USA", Population = 8406000},
        //    new City{Name = "San Jose", Country = "USA", Population = 998537},
        //    new City{Name = "Paris", Country = "France", Population = 2244000}
        //};

        public MemoryCityRepository(UsingViewComponentsDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<City> Cities => context.Cities;

        public void AddCity(City city)
        {
            if (city.Id == 0)
            {
                context.Cities.Add(city);
            }
            else
            {
                City dbEntry = context.Cities
                    .FirstOrDefault(c => c.Id == city.Id);
                if(dbEntry != null)
                {
                    dbEntry.Name = city.Name;
                    dbEntry.Population = city.Population;
                    dbEntry.Country = city.Country;
                }
            }
            context.SaveChanges();
        }
    }
}
