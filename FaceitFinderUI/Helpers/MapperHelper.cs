using Accessibility;
using ApiLibrary.Models;
using AutoMapper;
using FaceitFinderUI.Models;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceitFinderUI.Helpers
{
    public class MapperHelper : IMapperHelper
    {
        readonly IMapper _mapper;
        IConverter _converter;
        public MapperHelper(IMapper mapper,IConverter  converter)
        {
            _mapper = mapper;
            _converter = converter;
        }

        static string GetFavoriteMapName(IList<Segment> maps)
        {
          var favoriteMap=  maps.OrderBy(map=>map.stats.Matches).LastOrDefault();

            return favoriteMap.label;
        }
        static string   GetFavoriteMapImg(IList<Segment> maps)
        {
            var favoriteMap = maps.OrderBy(map => map.stats.Matches).LastOrDefault();
                               


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
    }
}
