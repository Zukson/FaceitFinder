using AutoMapper;
using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
   public class SearchViewModel : Screen
    {
        SearchedFaceitUserModel _searchedFaceitUser;
        IApiHelper _api;
        IMapperHelper _mapperHelper;
        SearchEvent _searchEvent;
       
        SearchedUserModel _searchedUser;
        public SearchViewModel(SearchedFaceitUserModel faceitUser,IApiHelper api,IMapperHelper mapperHelper,SearchEvent searchEvent, SearchedUserModel searchedUser)
        {

            _searchedFaceitUser = faceitUser;
            _api = api;
            _mapperHelper = mapperHelper;
            _searchEvent = searchEvent;
            _searchedUser = searchedUser;
        }

        public bool IsErrorVisible
        {

            get
            {
                return true;
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { 
                _errorMessage = value;
                NotifyOfPropertyChange(()=>ErrorMessage);
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
                ErrorMessage = "";
                var user = await _api.GetPlayerInfo(Nick);

                var faceitUser = await _api.GetUserStats(user.player_id);
                _mapperHelper.MapToSingletonSearchedUserModel(user, _searchedUser);
                _mapperHelper.MapToSingletonSearchedFaceitModel(faceitUser, _searchedFaceitUser);
                _searchEvent.OnSearched();
            }
           catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }


    }
}
