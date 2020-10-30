using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.ViewModels
{
  public   class SearchedUserViewModel : Screen
    {
        SearchedFaceitUserModel _faceitUser;
        SearchedUserModel _userModel;
        IConverter _converter;
        SearchEvent _searchEvent;


        public SearchedUserViewModel(FaceitUserModel faceituser, UserModel userModel, IConverter converter, LogOnEvent logOn,SearchEvent searchEvent)
        {
            _faceitUser = faceituser;
            _userModel = userModel;
            _converter = converter;
            _searchEvent = searchEvent;
            _searchEvent.Searched += Searched;


        }

        public async Task SetUserStatsToProperties()
        {
            Nick = _userModel.Nickname;
            Avatar = _converter.ConvertBytesToBitmapImage(_userModel.Avatar);
            Matches = _faceitUser.lifetime.Matches;
            WinStreak = _faceitUser.lifetime.Longest_Win_Streak;
            WinRate = _faceitUser.lifetime.WR;
            Wins = _faceitUser.lifetime.Wins;
            Kd = _faceitUser.lifetime.Kd;
            FavoriteMap = _faceitUser.FavoriteMap;
            MapImg = _converter.ConvertBytesToBitmapImage(_converter.GetImgByUrl(_faceitUser.MapImg));
            Hs = _faceitUser.lifetime.AverageHeadshots;



        }
        private string _nick;

        public string Nick
        {
            get
            {
                return _nick;
            }
            set
            {
                _nick = value;
                NotifyOfPropertyChange(() => _nick);
            }
        }
        private string _matches;
        public string Matches
        {
            get
            {
                return _matches;
            }
            set
            {
                _matches = value;
                NotifyOfPropertyChange(() => Matches);
            }
        }
        private string _winStreak;
        public string WinStreak
        {
            get
            {
                return _winStreak;
            }
            set
            {
                _winStreak = value;
                NotifyOfPropertyChange(() => WinStreak);
            }
        }
        private string _winRate;
        public string WinRate
        {
            get
            {
                return $"{_winRate}%";
            }
            set
            {
                _winRate = value;
                NotifyOfPropertyChange(() => WinRate);
            }
        }
        private string _wins;
        public string Wins
        {
            get
            {
                return _wins;
            }
            set
            {
                _wins = value;
                NotifyOfPropertyChange(() => Wins);
            }
        }
        private string _kd;
        public string Kd
        {
            get
            {
                return _kd;
            }
            set
            {
                _kd = value;
                NotifyOfPropertyChange(() => Kd);
            }
        }
        private string _favoriteMap;
        private string _hs;
        public string Hs
        {
            get
            {
                return $"{_hs}%";
            }
            set
            {
                _hs = value;
                NotifyOfPropertyChange(() => Hs);
            }
        }
        public string FavoriteMap
        {
            get
            {
                return _favoriteMap;
            }
            set
            {
                _favoriteMap = value;
                NotifyOfPropertyChange(() => FavoriteMap);
            }
        }
        public BitmapImage _avatar;


        public BitmapImage Avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                _avatar = value;
                NotifyOfPropertyChange(() => Avatar);
            }
        }
        private BitmapImage _mapImg;
        public BitmapImage MapImg
        {
            get
            {
                return _mapImg;
            }
            set
            {
                _mapImg = value;
            }
        }
        public async void Searched()
        {
            await SetUserStatsToProperties();

        }




    }
}
}
