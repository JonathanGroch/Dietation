using System.Collections.Generic;

namespace APICaller
{
    class FDAFoodInfo
    {
        public string foodName { get; set; }
        public int foodID { get; set; }
        public List<string> foodIngredients { get; set; }

        public FDAFoodInfo()
        {
            foodName = string.Empty;
            foodIngredients = new List<string>();
        }

        public FDAFoodInfo(string userFoodName, int userFoodID)
        {
            foodName = userFoodName;
            foodIngredients = new List<string>();
            foodID = userFoodID;
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
