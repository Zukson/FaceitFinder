using ApiLibrary.Models;
using AutoMapper;
using FaceitFinderUI.Models;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Helpers
{
    public class MapperHelper : IMapperHelper
    {
        readonly IMapper _mapper;
        public MapperHelper(IMapper mapper)
        {
            _mapper = mapper;
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
