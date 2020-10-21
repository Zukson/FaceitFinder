using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Events
{
  public  class CreateAccountTextBlockEvent
    {
        public delegate void Click();

      static  public event Click Clicked;

       static  public  void Pressed()
        {
            Clicked?.Invoke();
        }
    }
}
