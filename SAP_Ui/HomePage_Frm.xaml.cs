using DataAccessLayer;
using FormComponent;
using MaterialDesignThemes.Wpf;
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
            //WrapPanel panel = new WrapPanel();
            //panel.Orientation = Orientation.Horizontal;
            //panel.Height = 488;
            //panel.Width = PanelCart_WrpPnl.Width;
            //panel.Height = PanelCart_WrpPnl.Height;
            //panel.FlowDirection = FlowDirection.LeftToRight;
            //for (int i = 0; i < 100; i++)
            //{
            //    panel.Children.Add(new FormComponent.StudentCards() { Width = 161.5, Height = 171, FullName = "محمد مهدی درویش پور" + i, Payeh = "یازدهم" + i, Reshte = "شبکه نرم افزار " + i, ProfileAddress = "AppLogo.png" });
            //}
            //PanelCart_WrpPnl.Children.Add(panel);

        }

        private void GheybatTakhirAdd_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Ghayeb> ghayeb = new List<Ghayeb>()
            {
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="1ابوالفضل علی جعفری",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری2",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری3",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری4",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری5",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری6",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری7",Type="موجه"},
                new Ghayeb(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری8",Type="موجه"},
            };
            List<Takhir> takhir = new List<Takhir>()
            {
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="1ابوالفضل علی جعفری",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری2",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری3",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری4",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری5",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری6",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری7",Type="موجه"},
                new Takhir(){ Date = "1401/12/29",Name="ابوالفضل علی جعفری8",Type="موجه"},
            };

            DialogGheybat.ShowDialog(new GheybatTakhir(ghayeb,takhir){ Width = 671.5 , Height = 315.5}); 
           
        }
    }
}
