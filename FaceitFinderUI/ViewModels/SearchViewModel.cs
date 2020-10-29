using AutoMapper;
using Caliburn.Micro;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
   public class SearchViewModel : Screen
    {
        FaceitUserModel _faceitUser;
        IApiHelper _api;
        IMapperHelper _mapperHelper;
        public SearchViewModel(FaceitUserModel faceitUser,IApiHelper api,IMapperHelper mapperHelper)
        {

            _faceitUser = faceitUser;
            _api = api;
            _mapperHelper = mapperHelper;
        }



        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { 
                _errorMessage = value;
                NotifyOfPropertyChange(ErrorMessage);
            }
        }

        private string  _nick;

        public string Nick
        {
            get { return _nick; }
            set { _nick = value; }
        }


        public async void Search()
        {
            try
            {
                var user = await _api.GetPlayerInfo(Nick);

                var faceitUser = await _api.GetUserStats(user.player_id);
                _mapperHelper.MapToSingletonFaceitModel(faceitUser, _faceitUser);
            }
           catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }


    }
}
