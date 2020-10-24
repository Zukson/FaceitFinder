using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Events
{
    class RegisterEvent
    {
     public   delegate void Register();

        public event Register  Registered;


        protected virtual void RegisterTriggered()
        {
            Registered?.Invoke();
        }
    }
}
