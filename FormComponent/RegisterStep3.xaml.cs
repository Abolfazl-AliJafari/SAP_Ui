using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormComponent
{
    /// <summary>
    /// Interaction logic for RegisterStep3.xaml
    /// </summary>
    public partial class RegisterStep3 : UserControl
    {
        public RegisterStep3()
        {
            InitializeComponent();
        }
        public string HomeAddress { get; set; }
        public string HomeNumber { get; set; }
        public string Other { get; set; }
        private void HomePhoneNumber_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            HomeNumber = HomePhoneNumber_Txt.Text;
        }

        private void HomeAddress_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            HomeAddress= HomeAddress_Txt.Text;
        }

        private void OtherAbout_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Other= OtherAbout_Txt.Text;
        }
        public void Registered()
        {
            HomeAddress = "";
            HomeNumber = "";
            Other = "";
          HomeAddress_Txt.Clear();
          HomePhoneNumber_Txt.Clear();
          OtherAbout_Txt.Clear();

        }
    }
}
