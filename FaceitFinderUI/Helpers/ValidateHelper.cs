using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Helpers
{
    public enum Errors
    {
        Email,
        Nickname,
        Password,
        Valid
    }
    public  class ValidateHelper
    {
        ISqlHelper _sqlHelper;
        public ValidateHelper(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public Errors IsDataValid(string username,string email,string password)
        {
            if(password.Length<8)
            {
                return Errors.Password;
            }
            if (!CheckEmail(email)) return Errors.Email;
           
            if (username.Length < 4)
            {
                return Errors.Password;
            }
            else
            {
                return Errors.Valid;
            }
           
        }

       public   bool CheckEmail(string Email)
        {
            bool isAt = false;
            for(int i=0;i<Email.Length;i++)
            {
                if (Email[i] == '@') isAt = true;
            }
            if (Email.Length > 6 && isAt)
            {
                return true;
            }


            else { 
                return false;
            }
            
        }

        //private bool IsUsernameFree(string username)
        //{
           //TODO Sprawdzic czy podany uzytkwnik istnieje w bazie danych 

        //}

    }
}
