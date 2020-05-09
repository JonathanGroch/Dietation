using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_End.Models
{
    public class PredefinedFilters
    {
        private List<String> glutenFree;
        private List<String> dairyFree;
        private List<String> nutFree;
        private List<String> cornFree;
        private List<String> vegan;
        private List<String> vegetarian;
        private List<String> pescatarian;

        public PredefinedFilters()
        {

        }

        public List<String> getFilters(string para)
        {
            if(para == "GlutenFree")
            {
                return glutenFree;
            }
            else if(para == "DairyFree")
            {
                return dairyFree;
            }
            else if(para == "NutFree")
            {
                return nutFree;
            }
            else if(para == "CornFree")
            {
                return cornFree;
            }
            else if(para == "Vegan")
            {
                return vegan;
            }
            else if(para == "Vegetarian")
            {
                return vegetarian;
            }
            else if(para == "Pescetarian")
            {
                return pescatarian;
            }
            else
            {
                List<String> empty = new List<String>;
                return empty;
            }
        }
    }
}