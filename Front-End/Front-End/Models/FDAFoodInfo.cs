using System.Collections.Generic;

namespace APICaller
{
    class FDAFoodInfo
    {
        public string foodName { get; set; }
        public int foodID { get; set; }
		public string foodBrand { get; set; }
        public List<string> foodIngredients { get; set; }

        public FDAFoodInfo()
        {
            foodName = string.Empty;
            foodIngredients = new List<string>();
        }

        public FDAFoodInfo(string userFoodName, int userFoodID, string userFoodBrand)
        {
            foodName = userFoodName;
            foodIngredients = new List<string>();
            foodID = userFoodID;
            foodBrand = userFoodBrand;
        }

        public FDAFoodInfo(List<string> userFoodIngredients)
        {
            foodName = string.Empty;
            foodIngredients = userFoodIngredients;
        }

        public FDAFoodInfo(string userFoodName, int userFoodID, List<string> userFoodIngredients)
        {
            foodName = userFoodName;
            foodID = userFoodID;
            foodIngredients = userFoodIngredients;
        }
    }
}
