using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLibrary.Models
{
  public  class UserSqlModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
        public string PlayerId { get; set; }
        //public BitMap Id { get; set; }
    }
}
