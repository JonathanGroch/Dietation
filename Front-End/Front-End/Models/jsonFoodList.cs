using System.Collections.Generic;

namespace JSONParser
{
    class jsonFoodList
    {
        public foodSearch foodSearchCriteria { get; set; }
        public List<foodList> foods { get; set; }

        public class foodSearch
        {
            public string query { get; set; }
            public string generalSearchInput { get; set; }
            public int pageNumber { get; set; }
            public bool requireAllWords { get; set; }
        }

        public int totalHits { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }

        public class foodList
        {
            public List<foodNutrientsList> foodNutrients { get; set; }
            public int fdcId { get; set; }
            public string description { get; set; }
            public string dataType { get; set; }
            public string publishedDate { get; set; }
            public string gtinUpc { get; set; }
            public string brandOwner { get; set; }
            public string ingredients { get; set; }
            public string allHighlightFields { get; set; }
            public string score { get; set; }

            public class foodNutrientsList
            {
                public int nutrientId { get; set; }
                public string nutrientName { get; set; }
                public int nutrientNumber { get; set; }
                public string unitName { get; set; }
                public double value { get; set; }
                public string derivationCode { get; set; }
                public string derivationDescription { get; set; }
            }
        }
    }
}
