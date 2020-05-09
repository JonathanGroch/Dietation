using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Front_End.Models
{
    public class CustomFilter
    {
        private string CustomFilterTitle;
        private List<String> CustomFilterBannedIngredients;

        public CustomFilter(string Title, List<String> filter)
        {
            CustomFilterTitle = Title;
            CustomFilterBannedIngredients = filter;
        }

        public string Title
        {
            get { return CustomFilterTitle;  }
        }

        public List<String> Ingredients
        {
            get { return CustomFilterBannedIngredients;  }
        }
    }
}