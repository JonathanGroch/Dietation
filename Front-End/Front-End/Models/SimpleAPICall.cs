using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using JSONParser;


namespace APICaller
{
    class SimpleAPIClass
    {
        //Function that takes in a string for the food to be searched from FDA Database
        //Returns a list of FDAFoodInfo that has a food item's Name, fdcID and list of ingredients as strings
        public static List<FDAFoodInfo> SearchFDADatabase(string foodSearchName)
        {

            HttpClient http = new HttpClient();
            string Url = "https://api.nal.usda.gov/fdc/v1/foods/search?api_key=cvL8bjuRaD1XBClk9THXae22G4zWcfC55qdGprSl&query=";

            //Replaces blank spaces with %20 for querying
            foodSearchName = foodSearchName.Replace(" ", "%20");
            Url = Url + foodSearchName;

            HttpResponseMessage response = http.GetAsync(new Uri(Url)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            //Deserializes the string using the jsonFoodList template to break it into parts
            var FoodResults = JsonConvert.DeserializeObject<jsonFoodList>(responseBody);

            if (FoodResults.totalHits == 0)
            {
                //Can redirect to another webpage here and say no items found if necessary
                return null;
            }
            else
            {
                List<FDAFoodInfo> FoodList = new List<FDAFoodInfo>();

                //Goes through each food item in the results list and adds a new FDAFoodInfo to the list
                //Containing the food's name and fdcID
                foreach (var foodItem in FoodResults.foods)
                {
                    FoodList.Add(new FDAFoodInfo(foodItem.description, foodItem.fdcId));

                    //Goes through each nutrient in the nutrient list and adds that to the current FDAFoodInfo's ingredient list
                    foreach (var nutrientItem in foodItem.foodNutrients)
                    {
                        FoodList[FoodList.Count - 1].foodIngredients.Add(nutrientItem.nutrientName);
                    }
                }
                return FoodList;
            }
        }
        /*Main function to test the SearchFDADatabase function by printing to a console based on a foodSearch term
         * 
         * 
        //Prints to console each food found based on the search term 
        static void Main(string[] args)
        {
            //String to search
            string foodSearch = "Cheddar Cheese";

            List<FDAFoodInfo> FoodList = SearchFDADatabase(foodSearch);

            //Example how to handle if no food item is found. SearchFDADatabase will return null.
            if (FoodList == null)
            {
                Console.WriteLine("No items found");
            }
            else
            {
                int count;

                //Goes through and prints out the information for each food item
                foreach (var foodItem in FoodList)
                {
                    count = 0;
                    Console.WriteLine("ID: " + foodItem.foodID);
                    Console.WriteLine("Name: " + foodItem.foodName + "\n");
                    Console.WriteLine("Ingredients List: ");

                    //Prints out information for each nutrient in the ingredients list
                    foreach (var nutrientItem in foodItem.foodIngredients)
                    {
                        Console.WriteLine(foodItem.foodIngredients[count]);
                        count++;
                    }

                    Console.WriteLine();
                }
            }
        }*/
    }
}
