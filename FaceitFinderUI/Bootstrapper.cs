using ApiLibrary.Api;
using ApiLibrary.Models;
using AutoMapper;
using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.Models;
using FaceitFinderUI.ViewModels;
using SqlLibrary.DataAccess;
using SqlLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FaceitFinderUI
{
 public    class Bootstrapper : BootstrapperBase

    {
        //dd
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
            ConventionManager.AddElementConvention<PasswordBox>(
           PasswordBoxHelper.BoundPasswordProperty,
           "Password",
           "PasswordChanged");
        }
       
        private IMapper ConfigureMapper()
        {
            IConverter converter = new Converter();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FaceitCsgoModel, FaceitUserModel>();

                cfg.CreateMap<UserSqlModel, UserModel>();//.ForMember(x => x.Avatar,opt => opt.MapFrom(src=>new byte[6])); 
                cfg.CreateMap<Lifetime, LifetimeModel>();
                cfg.CreateMap<FaceitCsgoModel, FaceitUserModel>()
                .ForMember(faceitUserModel=>faceitUserModel.lifetime,dpt=>dpt.MapFrom(faceitcsgomodel=>MapperHelper.MappLifeTimeModel(faceitcsgomodel.lifetime, ConfigureMapper())))
                .ForMember(faceitusermodel => faceitusermodel.MapImg, 
                cfg => cfg.MapFrom((src) => MapperHelper.GetFavoriteMapImg(src.segments)))
                .ForMember(faceituser => faceituser.FavoriteMap,
                src=>src.MapFrom(faceitcsgo=>MapperHelper.GetFavoriteMapName(faceitcsgo.segments)))
                
                ;
            });
            
            var output = config.CreateMapper();
            return output;

        }
        protected override void Configure()
        {
            base.Configure();
            _container.Instance(_container);
            _container.Instance<IMapper>(ConfigureMapper());
            _container.Singleton<LogOnEvent>();
            _container.Singleton<CreateAccountTextBlockEvent>();
            _container.Singleton<RegisterEvent>();
            _container.Singleton<UserModel>();
            _container.Singleton<FaceitUserModel>();
            _container.Singleton<TestModel>();
              

            _container.PerRequest<IValidateHelper, ValidateHelper>()
                .PerRequest<IFaceitApi, FaceitApi>()
                .PerRequest<IApiHelper, ApiHelper>()
                .PerRequest<IConverter, Converter>()
                .PerRequest<IMapperHelper, MapperHelper>()
                 .PerRequest<ISetterHelper, SetterHelper>();
             

            _container.Singleton<IWindowManager, WindowManager>().
                Singleton<IEventAggregator, EventAggregator>().
                Singleton<ISqlHelper, SqlHelper>().Singleton<ISqlData, SqlData>();
         
            GetType().Assembly.GetTypes().Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {

            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
