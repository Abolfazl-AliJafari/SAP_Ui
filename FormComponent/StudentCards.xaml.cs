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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FullName_TxtBlock.Text = FullName;
            Payeh_TxtBlock.Text = Payeh;
            Reshte_TxtBlock.Text = Reshte;
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(ProfileAddress, UriKind.Relative));
            Profile_Img.Background = brush;
        }
    }
}
