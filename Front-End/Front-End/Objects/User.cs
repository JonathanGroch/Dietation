using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Front_End.Objects
{
    public class User
    {
        private string emailAddress; 
        private string fullName;
        private string pass;

        public User(string emailAddress, string fullName, string pass)
        {
            this.emailAddress = emailAddress;
            this.fullName = fullName;
            this.pass = Encrypt.EncryptString("Laziness Granite Praetor", pass);
        }

        public string sqlString()
        {
            return "INSERT INTO TABLE ____ VALUES(" + emailAddress + ", " + fullName + ", " + pass + ");";
        }
    }
}