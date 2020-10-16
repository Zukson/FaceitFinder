using Caliburn.Micro;
using FaceitFinderUI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Events
{
  
    public class LogOnEvent
    {

        public delegate void Log();
        public event Log LogInEvent;

      public  virtual   void LogIn()
        {
            LogInEvent?.Invoke();
        }

    }
}
