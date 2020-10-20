using ApiLibrary.Api;
using Caliburn.Micro;
using FaceitFinderUI.Events;
using FaceitFinderUI.Helpers;
using FaceitFinderUI.ViewModels;
using SqlLibrary.DataAccess;
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
        protected override void Configure()
        {
            base.Configure();
            _container.Instance(_container);
            _container.Singleton<LogOnEvent>();

            _container.PerRequest<IValidateHelper, ValidateHelper>().PerRequest<IFaceitApi, FaceitApi>();

            _container.Singleton<IWindowManager, WindowManager>().
                Singleton<IEventAggregator, EventAggregator>().
                Singleton<ISqlHelper,SqlHelper>().Singleton<ISqlData,SqlData>();
         
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
