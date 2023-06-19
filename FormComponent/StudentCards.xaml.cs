using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for StudentCards.xaml
    /// </summary>
    public partial class StudentCards : UserControl
    {
        public StudentCards()
        {
            InitializeComponent();
        }
        public string Payeh { get; set; }
        public string Reshte { get; set; }
        public string FullName { get; set; }
        public string ProfileAddress { get; set; }
        public StudentCards(string payeh, string reshteh, string fullName, string profileaddress)
        {
            InitializeComponent();
            Payeh = payeh;
            Reshte = reshteh;
            FullName = fullName;
            ProfileAddress = profileaddress;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Payeh != null && Reshte != null && FullName != null && ProfileAddress != null)
            {
                FullName_TxtBlock.Text = FullName;
                Payeh_TxtBlock.Text = Payeh;
                Reshte_TxtBlock.Text = Reshte;

                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(ProfileAddress, UriKind.Relative));
                Profile_Img.Background = brush;
            }
        }


        private void StudentSelect_ChckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)StudentSelect_ChckBox.IsChecked)
            {
                StudentCard_Border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            }
            else
                StudentCard_Border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }
    }
}
