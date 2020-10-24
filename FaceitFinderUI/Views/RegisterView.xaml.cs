using FaceitFinderUI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FaceitFinderUI.Views
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            Test();
        }
        void Test()
        {
            Converter t = new Converter();
          var x =   t.GetImgByUrl("https://i.wpimg.pl/1000x0/d.wpimg.pl/1754975740--211928981/kot-motylek.jpg");
            TestImage.Source = x;
        }
    }
}
