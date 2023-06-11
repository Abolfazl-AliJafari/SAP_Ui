using FormComponent;
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
    /// Interaction logic for StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        private void EditStudent_Btn_Click(object sender, RoutedEventArgs e)
        {

        }


        void EnzebatiSliderSelect()
        {
            var brush = new BitmapImage();
            EnzebatiTabHeader_TxtBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            brush = new BitmapImage(new Uri("/EnzebatiIco(Purpple).png", UriKind.Relative));
            EnzebatiTabHeader_Img.Source = brush;
            brush = new BitmapImage(new Uri("/Border2(Purpple).png", UriKind.Relative));
            EnzebatiTabBorder_Img.Source = brush;

            GheybatTakhirTabHeader_TxtBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            brush = new BitmapImage(new Uri("/GheybatTakhirIco(Black).png", UriKind.Relative));
            GheybatTakhirTabHeader_Img.Source = brush;
            brush = new BitmapImage(new Uri("", UriKind.Relative));
            GheybatTakhirTabBorder_Img.Source = brush;

            Enzebati_Grid.Visibility = Visibility.Visible;
            GheybatTakhir_Grid.Visibility = Visibility.Hidden;
        }

        void GheybatTakhirSliderSelect()
        {
            var brush = new BitmapImage();
            EnzebatiTabHeader_TxtBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            brush = new BitmapImage(new Uri("/EnzebatiIco(Black).png", UriKind.Relative));
            EnzebatiTabHeader_Img.Source = brush;
            brush = new BitmapImage(new Uri("", UriKind.Relative));
            EnzebatiTabBorder_Img.Source = brush;

            GheybatTakhirTabHeader_TxtBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            brush = new BitmapImage(new Uri("/GheybatTakhirIco(Purpple).png", UriKind.Relative));
            GheybatTakhirTabHeader_Img.Source = brush;
            brush = new BitmapImage(new Uri("/Border(Purpple).png", UriKind.Relative));
            GheybatTakhirTabBorder_Img.Source = brush;

            Enzebati_Grid.Visibility = Visibility.Hidden;
            GheybatTakhir_Grid.Visibility = Visibility.Visible;
        }
        private void GheybatTakhirSlider_Btn_Click(object sender, RoutedEventArgs e)
        {
            GheybatTakhirSliderSelect();
            
        }

        private void EnzebatiSlider_Btn_Click(object sender, RoutedEventArgs e)
        {
            EnzebatiSliderSelect();
        }

        private void BtnGheybat_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            TakhirBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            GheybatBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            Takhir_Grid.Visibility = Visibility.Hidden;
            Gheybat_Grid.Visibility = Visibility.Visible;
        }


        private void Takhir_Btn_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            TakhirBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            GheybatBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            Gheybat_Grid.Visibility= Visibility.Hidden;
            Takhir_Grid.Visibility= Visibility.Visible;
        }

      
    }
}
