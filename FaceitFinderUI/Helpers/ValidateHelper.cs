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
    public class ValidateHelper : IValidateHelper
    {
        ISqlHelper _sqlHelper;
        public ValidateHelper(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public Errors IsDataValid(string username, string email, string password)
        {



            if (!CheckUsername(username))
            {
                return Errors.Nickname;
            }
            if (!CheckEmail(email))
            {
                return Errors.Email;


            }


            if (!CheckPassword(password))
            {
                return Errors.Password;
            }
            else
            {
                return Errors.Valid;
            }

        }
        public bool CheckUsername(string username)
        {
            for (int i = 0; i < username.Length; i++)
            {
                if (username.Length > 20)
                {
                    return false;
                }
                else if (username[i] == ' ')
                {
                    return false;
                }

            }
            return true;
        }
        public bool CheckPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            return true;
        }
        public bool CheckEmail(string email)
        {
            bool isAt = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@') isAt = true;
            }
            if (email.Length > 6 && isAt)
            {
                return true;
            }


            else
            {
                return false;
            }

        }

        //private bool IsUsernameAndEmailFree(string username)
        //{
        //TODO Sprawdzic czy podany uzytkwnik istnieje w bazie danych 

        //}

    }
}
