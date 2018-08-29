using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponents.Models;
using UsingViewComponents.Models.ViewModels;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }


        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }
            else
            {
                return View(new CityViewModel()
                {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(c => c.Population)
                });
                #region
                //string target = RouteData.Values["id"] as string;
                //var cities = repository.Cities
                //    .Where(city => city.Country == null ||
                //         string.Compare(city.Country, target, true) == 0);
                //return View(new CityViewModel()
                //{
                //    Cities = cities.Count(),
                //    Population = cities.Sum(c => c.Population)
                //});
                #endregion
            }


        }
    }
}
