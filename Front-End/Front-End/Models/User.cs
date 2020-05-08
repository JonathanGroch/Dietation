using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Front_End.Objects
{
    public class User
    {
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private String emailAddress;
        private String loginId;
        private String firstName;
        private String lastName;
        private String pass;
        private static Random random = new Random();


        public User(String emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public User(String emailAddress, String firstName, String pass, String lastName)
        {
            this.emailAddress = emailAddress;
            this.firstName = firstName;
            this.lastName = lastName;
            this.loginId = RandomString(16);
            this.pass = Encrypt.EncryptString(loginId, pass);
        }

        public String sqlInsertInto()
        {
            return "insert into users(FirstName, LastName, LoginID, userPassword, EmailAddress)" +
                "values('" + firstName + "', '" + lastName + "', '" + loginId + "', '" + pass + "', '" + emailAddress + "')";
        }

        public bool comparatorPassword(String encryptedPass, String enteredPass, string logid)
        {
            string temp = Encrypt.DecryptString(encryptedPass, enteredPass);
            if(logid == temp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getLoginId()
        {
            return loginId;
        }

    }
}