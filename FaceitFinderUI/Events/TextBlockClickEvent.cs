using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Events
{
  public  class TextBlockClickEvent
    {
        public delegate void Click();

      static  public event Click RegisterClicked;
        static public event Click SearchClicked;
       static  public  void RegisterPressed()
        {
            RegisterClicked?.Invoke();
        }

        static public void SearchPressed()
        {

            SearchClicked?.Invoke();
        }
    }
}
