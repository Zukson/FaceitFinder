using ApiLibrary.Models;
using FaceitFinderUI.Models;
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
        NicknameReserved,
        EmailReserverd,
        Valid
    }
    public class ValidateHelper : IValidateHelper
    {
        ISqlHelper _sqlHelper;
        public ValidateHelper(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public Errors IsDataValid(string username, string email, string password,List<UserModel> users)
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
                if(!IsUsernameFree(username,users))
                {
                    return Errors.NicknameReserved;
                }
                if(!IsEmailFree(email,users))
                {
                    return Errors.EmailReserverd;
                }
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

        public bool IsUsernameFree(string username , List<UserModel> users)
        {
            bool output = true;
            if (users == null || users.Count == 0) return output;
            foreach (var user in users)
            {
                if (user.Nickname == username)
                {
                    output = false;
                }

            }
            return output;

        }

      public  bool IsEmailFree(string email, List<UserModel>users)
        {
            bool output = true;

            foreach(var user in users)
            {
                if (user.Email == email)
                {
                    output = false;
                }
              
            }
            return output;
        }

    }
}
