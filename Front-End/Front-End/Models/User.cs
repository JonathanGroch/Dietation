using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Front_End.Objects
{
    public class User
    {
        private string emailAddress;
        private string firstName;
        private string lastName;
        private string pass;

        public User(string emailAddress, string firstName, string pass, string lastName)
        {
            this.emailAddress = emailAddress;
            this.firstName = firstName;
            this.lastName = lastName;
            this.pass = Encrypt.EncryptString("Laziness Granite Praetor", pass);
        }

        public string sqlString()
        {
            return "INSERT INTO TABLE Users VALUES(" + firstName + ", " + lastName + ", " + pass + ", " + emailAddress +  ");";
        }
    }
}