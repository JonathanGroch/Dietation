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
            glutenFree = new List<string>() { "Barley", "Barley Flakes", "Barley Flour", "Barley Pearl", "Breading", "Bread Stuffing", "Breading", 
                "Brewer's Yeast", "Bulgur", "Durum", "Farro", "Faro", "Spelt", "Spelt Flour", "Dinkel", "Dinkel Flour", "Graham Flour", "Kumut", "Malt", "Malt Extract", "Malt Syrup",
                "Malt Flavoring", "Malt Vinegar", "Malted Milk", "Matzo", "Matzo Meal", "Modified Wheat Starch", "Oatmeal", "Oat bran", "Oat flour",
                "Whole oats", "Rye", "Rye Flour", "Seitan", "Semolina", "Triticale", "Wheat Bran", "Wheat flour", "Wheat Flour", "Wheat germ", "Wheat Starch", 
                "Atta", "Chapati Flour", "Einkorn", "Emmer", "Farina", "Fu"};
            glutenFree = glutenFree.ConvertAll(d => d.ToUpper());
            dairyFree = new List<string>() { "Acidophilus Milk", "Ammonium Caseinate", "Butter", "Butter Fat", "Butter Oil", "Butter Solids", "Buttermilk",
                "Buttermilk Powder", "Calcium Caseinate", "Casein", "Caseinate", "Cheese", "Condensed Milk", "Cottage Cheese", "Cream", "Curds", "Custard",
                "Delactosed Whey", "Demineralized Whey", "Dry Milk Powder", "Dry Milk Solids", "Evaporated Milk", "Ghee", "Goat Cheese", "Goat Milk", "Half & Half",
                "Hydrolyzed Casein", "Hydrolyzed Milk Protein", "Iron Caseinate", "Lactalbumin", "Lactoferrin", "Lactoglobulin", "Lactose", "Lactulose", "Low-Fat Milk",
                "Magnesium Caseinate", "Malted Milk", "Milk", "Milk Derivative", "Milk Fat", "Milk Powder", "Milk Protein", "Milk Solids", "Natural Butter Flavor",
                "Nonfat Milk", "Nougat", "Paneer", "Potassium Caseinate", "Pudding", "Recaldent", "Rennet Casein", "Sheep Milk", "Sheep Milk Cheese", "Skim Milk",
                "Sodium Caseinate", "Sour Cream", "Sour Milk Solids", "Sweetened Condensed Milk", "Sweet Whey", "Whey", "Whey Powder", "Whey Protein Concentrate",
                "Whey Protein Hydrolysate", "Whipped Cream", "Whipped Topping", "Whole Milk", "Yogurt", "Zinc Caseinate"};
            dairyFree = dairyFree.ConvertAll(d => d.ToUpper());
            nutFree = new List<String>() { "Almond", "Almond paste", "Anacardium nuts", "Anacardium occidentale",
                "Artificial nuts", "Beechnut", "Brazil nut", "Bertholletia excelsa", "Bush nut", "Butternut", "Butyrospermum Parkii",
                "Canarium ovatum", "Burseraceae", "Pili nut", "Pili nut", "Caponata", "Carya illinoensis", "Juglandaceae", "Pecan",
                "Carya spp.", "Hickory nut" ,"Cashew", "Castanea pumila", "Fagaceae", "Chinquapin", "Chestnut", "Castanea spp.", "Chinese Chestnut",
                "American Chestnut", "European Chestnut", "Seguin Chestnut", "Chinquapin","Coconut", "Cocos nucifera L", "Arecaceae", "Palmae",
                "Corylus spp.", "Betulaceae", "Filbert", "Fagus spp.", "Fagaceae", "Gianduja", "Ginko nut", "Ginkgo biloba L.", "Ginkgoaceae",
                "Hazelnut", "Heartnut", "Hickory nut", "Indian nut", "Juglans cinerea", "Juglandaceae", "Juglans spp.", "Karite", "Lichee nut",
                "Litchi chinensis Sonn. Sapindaceae", "Lychee nut", "Macadamia nut", "Macadamia spp.", "Proteaceae", "Macadamia nut", "Mandelonas", "Marzipan",
                "Mashuga nuts", "Nangai nuts", "Natural nut extract", "Nougat", "Nu-Nuts®", "Almond butter", "Hazelnut butter", "Brazil nut butter",
                "Macadamia nut butter", "Pistachio nut butter", "Shea nut butter", "Karike butter", "Nut meal", "Nutella ®", "Nutmeat", "Nut Oil", "Walnut Oil",
                "Nut paste", "Nut pieces", "Pecan", "Pigñolia", "Pili nut", "Pine nut", "Pine nut", "Indian Nut", "piñon", "pinyon", "pigndi",
                "pigñolia", "pignon nuts", "Pinon nut", "Piñon nut", "Pinus spp.", "Pineaceae", "Pistachio", "Pistacia vera L.", "Anacardiaceae",
                "Pralines", "Prunus dulcis", "Rosaceae", "Shea nut", "Sheanut", "Vitellaria paradoxa C.F. Gaertn.", "Sapotaceae", "Walnut", "English Walnut",
                "Persian Walnut", "Black Walnut", "Japanese Walnut", "California Walnut"};
            nutFree = nutFree.ConvertAll(d => d.ToUpper());
            cornFree = new List<String> { "Corn alcohol", "Corn chips", "Corn gluten", "Corn extract", "Corn flakes", "Corn flour", "Corn fritters", "Corn oil", 
                "corn oil margarine", "Corn meal", "Corn puffs cereal", "Corn starch", "Corn sweetener", "Corn sugar", "Dextrose", "Dyno", "Cerelose",
                "Puretose", "Sweetose", "Corn Glocuse", "Corn Syrup", "Corn Syrup Solid", "Corn", "Popcorn", "Corn Meal", "Cornstarch", "Corn Flour",
                "Corn tortillas", "Grits", "High fructose corn syrup", "Hominy", "Hydrolyzed corn", "Hydrolyzed corn protein", "Maize", "Modified corn starch",
                "Polenta", "Tamales", "Taco Shells", "Vegetable Oil", "Zea mays", "Zein"};
            cornFree = cornFree.ConvertAll(d => d.ToUpper());
            pescatarian = new List<String> {"Chicken", "Turkey", "Duck", "Goose", "Beaf", "Pork", "Mutton", "Goat Meat", "Venison", "Rabbit Meat"}; //Not Done Every except Meats
            pescatarian = pescatarian.ConvertAll(d => d.ToUpper());

            List<String> shellfish = new List<String> { "Abalone", "Barnacle", "Clams", "Cockle", "Crab", "Crawfish", "crawdad", " crayfish", "ecrevisse",
                "krill", "Cuttlefish", "Limpet", "Lobster", "langouste", "langoustine", "Moreton bay bugs", "scampi", " coral", "tomalley", "Mollusks",
                "Octopus", "squid", "calamari", "Oyster", "Periwinkle", "Prawns", "Scallops", "Sea cucumbe", "Sea urchin", "Shrimp", "prawns", "crevette", "scampi",
                "Snail", "escargot", "Squid", "calamari", "Whelk", "turban shell", "Bouillabaisse", "Cuttlefish ink", "Fish stock", "Glucosamine", "Crab Extract",
                "Clam extract", "Surimi"};
            vegetarian = new List<String> { "Branzino", "tilapia", "halibut", "cod", "sole", "perch", "walleye", "catfish", "Yellowtail", "kampachi",
                "snapper", "swordfish", "grouper", "trout", "Salmon", "tuna", "bluefish", "mackerel", "sardines", "anchovies", "herring"}; //Not Done Everything but shellfish, fish and meats
            vegetarian.AddRange(pescatarian);
            vegetarian.AddRange(shellfish);
            vegetarian = vegetarian.ConvertAll(d => d.ToUpper());

            vegan = new List<String> { "Egg", "Eggs", "Egg Whites", "Egg Yolks", "Albumin", "Globulin", "Livetin", "Ovalbumin", "Ovomucin", "Ovomucoid",
                "Ovovitellin", "Silico albuminate", "Vitellin", "Honey"}; //Not Done, Everything but shellfish, fish, meats, eggs, honey, dairy
            vegan.AddRange(pescatarian);
            vegan.AddRange(vegetarian);
            vegan.AddRange(dairyFree);
            vegan = vegan.ConvertAll(d => d.ToUpper());




            listOfFilters = new List<List<String>>();
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

        public List<String> getFilters(int para)
        {
            if (para == 0)
            {
                return glutenFree;
            }
            else if (para == 1)
            {
                return dairyFree;
            }
            else if(para == 2)
            {
                return nutFree;
            }
            else if(para == 3)
            {
                return cornFree;
            }
            else if(para == 4)
            {
                return vegan;
            }
            else if(para == 5)
            {
                return vegetarian;
            }
            else if(para == 6)
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
            string resultant = result.Substring(0, result.Length - 2);
            return resultant;
        }
    }
}