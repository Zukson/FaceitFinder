﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.ViewModels
{
 public   class ShellViewModel :Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(IoC.Get<LoginViewModel>());
        }
    }
}
