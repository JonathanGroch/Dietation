using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Front_End.Objects
{
    public class User
    {
        private string emailAddress;
        private string username;
        private string firstName;
        private string lastName;
        private string pass;

        public User(string emailAddress, string firstName, string username, string pass, string lastName)
        {
            this.emailAddress = emailAddress;
            this.firstName = firstName;
            this.username = username;
            this.lastName = lastName;
            this.pass = Encrypt.EncryptString("Laziness Granite Praetor", pass);
        }

        public string sqlInsertInto()
        {
            return "insert into users(FirstName, LastName, LoginID, userPassword, EmailAddress)" +
                "values('" + firstName + "', '" + lastName + "', '" + username + "', '" + pass + "', '" + emailAddress + "')";
        }

        public string
    }
}