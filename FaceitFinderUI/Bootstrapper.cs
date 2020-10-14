using Caliburn.Micro;
using FaceitFinderUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FaceitFinderUI
{
 public    class Bootstrapper : BootstrapperBase

    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
