﻿using Accessibility;
using ApiLibrary.Models;
using AutoMapper;
using FaceitFinderUI.Models;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceitFinderUI.Helpers
{
    public class MapperHelper : IMapperHelper
    {
        readonly IMapper _mapper;
        IConverter _converter;
        IValidateHelper _validate;
        public MapperHelper(IMapper mapper,IConverter  converter, IValidateHelper validate)
        {
            _mapper = mapper;
            _converter = converter;
            _validate = validate;
        }

      public   static string GetFavoriteMapName(IList<Segment> maps)
        {
            var favoriteMap = maps.OrderBy(map => int.Parse(map.stats.Matches)).LastOrDefault();


            return favoriteMap.label;
        }
     public   static string   GetFavoriteMapImg(IList<Segment> maps)
        {
            var favoriteMap = maps.OrderBy(map => int.Parse(map.stats.Matches)).LastOrDefault();
                               
            

            return favoriteMap.img_regular;
        }
        public FaceitUserModel MapToFaceitUserModel(FaceitCsgoModel faceitCsgo)
        {
            return _mapper.Map<FaceitUserModel>(faceitCsgo);

        }
        public UserModel MapToUserModel(UserSqlModel sqlModel)
        {
            return _mapper.Map<UserModel>(sqlModel);
        }
        public void  MapToSingletonUserModel(UserSqlModel sqlModel, UserModel singleton)
        {
            var output = _mapper.Map<UserModel>(sqlModel);
            singleton.Avatar = output.Avatar;
            singleton.CountryImg = output.CountryImg;
            singleton.Email = output.Email;
            singleton.Nickname = output.Nickname;
            singleton.Password = output.Password;
            singleton.Playerid = output.Playerid;
        }

            public void  MapToSingletonFaceitModel(FaceitCsgoModel faceitModel, FaceitUserModel singleton)
            {
                var output = _mapper.Map<FaceitUserModel>(faceitModel);
            singleton.FavoriteMap = output.FavoriteMap;
            singleton.game_id = output.game_id;
            singleton.lifetime = output.lifetime;
            singleton.MapImg = output.MapImg;
            singleton.player_id = output.player_id;

            }
            public static LifetimeModel MappLifeTimeModel(Lifetime lifetime,IMapper mapper)
        {
            return mapper.Map<LifetimeModel>(lifetime);
        }

    }
}
