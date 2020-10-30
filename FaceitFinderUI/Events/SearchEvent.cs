using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Events
{
    public class SearchEvent
    {
        public delegate void del();


        public event del Searched;
              

       public void OnSearched()
        {
            Searched?.Invoke();
        }
    }
}
