using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_End.Models
{
    public class CustomFilter
    {
        private string CustomFilterTitle { get; }
        private List<String> CustomFilterBannedIngredients { get; }

        public CustomFilter(string Title, List<String> filter)
        {
            CustomFilterTitle = Title;
            CustomFilterBannedIngredients = filter;
        }
    }
}