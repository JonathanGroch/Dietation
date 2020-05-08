using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Front_End.Objects
{
    public class User
    {
        private string emailAddress;
        private string loginId;
        private string firstName;
        private string lastName;
        private string pass;
        private string plaintext = "Laziness Granite Praetor";

        public User(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public User(string emailAddress, string firstName, string loginId, string pass, string lastName)
        {
            this.emailAddress = emailAddress;
            this.firstName = firstName;
            this.loginId = loginId;
            this.lastName = lastName;
            this.pass = Encrypt.EncryptString(plaintext, pass);
        }

        public string sqlInsertInto()
        {
            return "insert into users(FirstName, LastName, LoginID, userPassword, EmailAddress)" +
                "values('" + firstName + "', '" + lastName + "', '" + loginId + "', '" + pass + "', '" + emailAddress + "')";
        }

        public bool comparatorPassword(string enteredPass, string encryptedPass)
        {
            string temp = Encrypt.DecryptString(plaintext, encryptedPass);
            if(enteredPass == temp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}