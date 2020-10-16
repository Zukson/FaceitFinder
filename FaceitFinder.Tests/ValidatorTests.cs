using FaceitFinderUI.Helpers;
using Xunit;

using FaceitFinderUI.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FaceitFinder.Tests
{
  public  class ValidatorTests
    {
        
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
      
    }
}
