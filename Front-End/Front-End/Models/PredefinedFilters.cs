using Dietation_Test;
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
        private List<List<String>> listOfFilters;
        public PredefinedFilters()
        {
            listOfFilters.Add(glutenFree);
            listOfFilters.Add(dairyFree);
            listOfFilters.Add(nutFree);
            listOfFilters.Add(cornFree);
            listOfFilters.Add(vegan);
            listOfFilters.Add(vegetarian);
            listOfFilters.Add(pescatarian);
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
                List<String> empty = new List<String>();
                return empty;
            }
        }

        public string addPredefinedFilters(List<String> ingredients)
        {
            string result = "";
            CompareListsSearching cls = new CompareListsSearching();
            foreach(List<string> ls in listOfFilters)
            {
                if(cls.Compare(ls, ingredients))
                {
                    result += "1, ";
                }
                else
                {
                    result += "0, ";
                }
            }
            return result.Substring(0, result.Length - 2);
        }
    }
}