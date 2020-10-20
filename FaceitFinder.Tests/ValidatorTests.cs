using FaceitFinderUI.Helpers;
using Xunit;

using FaceitFinderUI.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit.Sdk;

namespace FaceitFinder.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("exo", "exon@wp.pl", "exon1999")]

        public void IsDataValid_ShouldBeTrue(string username,string email,string password)
        {
            ValidateHelper validate = new ValidateHelper(null);
            var expected = Errors.Valid;
            var actual = validate.IsDataValid(username, email, password);

        }
        [Theory]
        [InlineData("exo", "exon@wp.pl", "exon")]

        public void IsDataValid_ShouldBePasswordError(string username, string email, string password)
        {
            ValidateHelper validate = new ValidateHelper(null);
            var expected = Errors.Password;
            var actual = validate.IsDataValid(username, email, password);
            Assert.Equal(expected, actual);


        }

        [Theory]
        [InlineData("Korczyk@Wp.pl")]
        
       
     public void   CheckEmail_ShouldWork(string email)
        {
            ValidateHelper validateHelper = new ValidateHelper(null);
            //var expected = true;

            var actual = validateHelper.CheckEmail(email);

            Assert.True(actual);


        }
        [Theory]
        [InlineData("dadadadWp.pl")]
        [InlineData("W@p.pl")]
        public void CheckEmail_ShouldNotWork(string email)
        {
            ValidateHelper validateHelper = new ValidateHelper(null);
            //var expected = true;

            var actual = validateHelper.CheckEmail(email);

            Assert.False(actual);

        }


        [Theory]
        [InlineData("Witam")]

        public void CheckUsername_ShouldWork(string username)
        {
            ValidateHelper validateHelper = new ValidateHelper(null);
            //var expected = true;

            var actual = validateHelper.CheckUsername(username);

            Assert.True(actual);


        }

        [Theory]
        [InlineData("Witam beczka")]

        public void CheckUsername_ShouldNotWork(string username)
        {
            ValidateHelper validateHelper = new ValidateHelper(null);
            //var expected = true;

            var actual = validateHelper.CheckUsername(username);

            Assert.False(actual);


        }


                 [Theory]
        [InlineData("w")]

        public void CheckPassword_ShouldNotWork(string username)
        {
            ValidateHelper validateHelper = new ValidateHelper(null);
            //var expected = true;

            var actual = validateHelper.CheckPassword(username);

            Assert.False(actual);


        }


    }
}
