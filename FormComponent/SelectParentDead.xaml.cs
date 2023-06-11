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
    /// Interaction logic for SelectParentDead.xaml
    /// </summary>
    public partial class SelectParentDead : UserControl
    {
        public SelectParentDead()
        {
            InitializeComponent();
        }
        public string SelectedItem { get; set; }

        public void enable(bool Status)
        {
            Both_Btn.IsEnabled = Status;
            Father_Btn.IsEnabled = Status;
            Mother_Btn.IsEnabled = Status;
        }

        void clickcolor (Control Elm)
        {
            Elm.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            Elm.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Button elm = Elm as Button;
            SelectedItem = elm.Content.ToString();
        }
        void noclickcolor(Control Elm)
        {
            Elm.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Elm.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }

        private void Both_Btn_Click(object sender, RoutedEventArgs e)
        {
            
            clickcolor(Both_Btn);
            noclickcolor(Father_Btn);
            noclickcolor(Mother_Btn);

        }

        private void Mother_Btn_Click(object sender, RoutedEventArgs e)
        {
            clickcolor(Mother_Btn);
            noclickcolor(Father_Btn);
            noclickcolor(Both_Btn);
        }

        private void Father_Btn_Click(object sender, RoutedEventArgs e)
        {
            clickcolor(Father_Btn);
            noclickcolor(Both_Btn);
            noclickcolor(Mother_Btn);
        }
    }
}
