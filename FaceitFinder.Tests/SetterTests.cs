using ApiLibrary.Models;
using Autofac.Extras.Moq;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FaceitFinder.Tests
{
   public class SetterTests
    {
        [Theory]
        [InlineData("Kapi@test.pl","test1234","benekx")]
     public  async void  SetUser_ShouldSetUserProperly(string mail, string password, string username)
        {
            UserModel user = new UserModel();
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IApiHelper>()
                    .Setup(api => api.GetPlayerInfo(username))
                    .Returns( ReturnFaceitUser());

                var cls = mock.Create<SetterHelper>();
                await cls.SetUser(mail, password, username, new byte[7], user);
                Assert.True(user.Email != null);
                Assert.NotNull(user.Playerid );
            }

           
            
            

        }
        public async Task<FaceitPlayerModel> ReturnFaceitUser()
        {
            return new FaceitPlayerModel { player_id = "1441414" };
        }

    }

}
