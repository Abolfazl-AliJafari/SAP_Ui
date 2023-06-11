using DataAccessLayer;
using FormComponent;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace SAP_Ui
{


    /// <summary>
    /// Interaction logic for HomePage_Frm.xaml
    /// </summary>
    public partial class HomePage_Frm : Window
    {
        public HomePage_Frm()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
        }
        private void DialogHost_DialogClosed(object sender, MaterialDesignThemes.Wpf.DialogClosedEventArgs eventArgs)
        {

        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }
        private void StudentSearch_Txt_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag.ToString())
                textBox.Text = "";
        }
        public void AddText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = textBox.Tag.ToString();
        }
        private void StudentSearch_Txt_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void DahomChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.DahomChckBox.IsChecked == true)
            {
                ChckBoxDahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                DahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));

            }
            else
            {
                ChckBoxDahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                DahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }

        }

        private void YazdahomChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.YazdahomChckBox.IsChecked == true)
            {
                ChckBoxYazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                YazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
            }
            else
            {
                ChckBoxYazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                YazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }
        }

        private void DavazdahomChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.DavazdahomChckBox.IsChecked == true)
            {
                ChckBoxDavazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                DavazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
            }
            else
            {
                ChckBoxDavazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                DavazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }
        }

        private void HesabdariChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.HesabdariChckBox.IsChecked == true)
            {
                ChckBoxHesabdariBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                HesabdariChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
            }
            else
            {
                ChckBoxHesabdariBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                HesabdariChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }
        }

        private void ShabakeChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.ShabakeChckBox.IsChecked == true)
            {
                ChckBoxShabakeBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                ShabakeChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
            }
            else
            {
                ChckBoxShabakeBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                ShabakeChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateHome_TxtBlock.Text = ConvertDate.MiladiToShamsiWithMonthName(DateTime.Now);

        }

        private void GheybatTakhirAdd_Btn_Click(object sender, RoutedEventArgs e)
        {
          

            DialogGheybat.ShowDialog(new GheybatTakhir{ Width = 671.5 , Height = 315.5}); 
           
        }

        private  void Import_Btn_Click(object sender, RoutedEventArgs e)
        {
            new StudentInfo().ShowDialog();
        }

        private void AddStudent_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogGheybat.ShowDialog(new RegisterStudentForm());

        }

        private void DeleteStudent_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
