using System;
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

        public List<String> getGlutenFree()
        {
            return glutenFree;
        }
        public List<String> getDairyFree()
        {
            return dairyFree;
        }
        public List<String> getNutFree()
        {
            return nutFree;
        }
        public List<String> getCornFree()
        {
            return cornFree;
        }
        public List<String> getVegan()
        {
            return vegan;
        }
        public List<String> getVegetarian()
        {
            return vegetarian;
        }
        public List<String> getPescatarian()
        {
            return pescatarian;
        }
    }
}