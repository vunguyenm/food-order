﻿using FoodOrder.Core;
using FoodOrder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodOrder.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}