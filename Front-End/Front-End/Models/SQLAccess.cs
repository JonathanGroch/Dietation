using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI.WebControls;

namespace Front_End.Models
{
    public class FoodNameMissing: Exception
    {
        public FoodNameMissing(string message): base(message)
        {

        }
    }

    public class IngredientsEmpty: Exception
    {
        public IngredientsEmpty(string message): base(message)
        {

        }
    }
    public class SQLAccess
    {
        public void GetIngredients(string foodName, List<String> result)
        {
            MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
            try
            {
                mysqlConnection.Open();
                string sqlString = "select ingredient from ingredients where foodName='" + foodName + "';";
                MySqlCommand cmd1 = new MySqlCommand(sqlString, mysqlConnection);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                if(rdr.HasRows)
                {
                    while(rdr.Read())
                    {
                        result.Add(rdr.GetValue(0).ToString());
                    }
               
                }
                else
                {
                    throw (new FoodNameMissing("FoodName is not found or has no rows"));
                }
            }
            catch(FoodNameMissing e)
            {
                Console.WriteLine("An exception has occured on SQL Access: {0}", e.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
            
        }

        public void FillIngredients(string foodName, List<String> ingredients)
        {
            
            MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
            try
            {
                mysqlConnection.Open();
                foreach(string ingredient in ingredients)
                {
                    string sqlString = "insert into ingredients (foodName, ingredient) values('" + foodName + "', '" + ingredient + "'); ";
                    MySqlCommand cmd1 = new MySqlCommand(sqlString, mysqlConnection);
                    cmd1.ExecuteNonQuery();
                }
                
            }
            catch (FoodNameMissing e)
            {
                Console.WriteLine("An exception has occured on SQL Access: {0}", e.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
        }

        public void FillPrefilters(String foodName, String foodBrand,  List<String> ingredients)
        {
            MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
            try
            {
                mysqlConnection.Open();
                PredefinedFilters filters = new PredefinedFilters();
                String sqlString = "insert into foodfilter (FoodName, FoodBrand, GlutenFree, DairyFree, NutFree, CornFree, Vegan, Vegetarian, Pescatarian)" +
                    "values('" + foodName + "', '" + foodBrand + "', " + filters.addPredefinedFilters(ingredients) + ");";
                MySqlCommand cmd1 = new MySqlCommand(sqlString, mysqlConnection);
                cmd1.ExecuteNonQuery();

            }
            catch (FoodNameMissing e)
            {
                Console.WriteLine("An exception has occured on SQL Access: {0}", e.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
        }

        
    }
}