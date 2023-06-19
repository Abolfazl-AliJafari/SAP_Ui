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
        GetStudent student;
        public StudentInfo(GetStudent Student)
        {
            InitializeComponent();
            student = Student;
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
            Tazakor_Scroll.Visibility = Visibility.Visible;
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
            Takhir_Scroll.Visibility = Visibility.Hidden;
            Gheybat_Scroll.Visibility = Visibility.Visible;
            Takhir_StckPnl.Visibility = Visibility.Hidden;
            Gheybat_StckPnl.Visibility = Visibility.Visible;
        }


        private void Takhir_Btn_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            TakhirBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            GheybatBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            Gheybat_Scroll.Visibility= Visibility.Hidden;
            Takhir_Scroll.Visibility= Visibility.Visible;
            Gheybat_StckPnl.Visibility = Visibility.Hidden;
            Takhir_StckPnl.Visibility = Visibility.Visible;

        }

        private void Tazakor_Btn_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTazakor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Tazakor_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            BorderBtnTashvigh.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Tashvigh_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            TazakorBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            TashvighBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            Tashvigh_Scroll.Visibility = Visibility.Hidden;
            Tazakor_Scroll.Visibility = Visibility.Visible;
            AddTazakor_Border.Visibility = Visibility.Visible;
            AddTashvigh_Border.Visibility = Visibility.Hidden;
            Tashvigh_StckPnl.Visibility = Visibility.Hidden;
            Tazakor_StckPnl.Visibility = Visibility.Visible;

        }

        private void Tashvigh_Btn_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTazakor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Tazakor_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            BorderBtnTashvigh.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Tashvigh_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            TazakorBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            TashvighBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            Tashvigh_Scroll.Visibility = Visibility.Visible;
            Tazakor_Scroll.Visibility = Visibility.Hidden;
            Tashvigh_StckPnl.Visibility = Visibility.Visible;
            AddTazakor_Border.Visibility = Visibility.Hidden;
            AddTashvigh_Border.Visibility = Visibility.Visible;
            Tashvigh_StckPnl.Visibility = Visibility.Visible;
            Tazakor_StckPnl.Visibility = Visibility.Hidden;
        }

    

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar1.SelectedDate.Value);
            ShowDate1_TxtBlock.Text = selectedDate;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StudentFullName_TxtBlock.Text = student.FirstName + student.LastName;
            //Payeh_TxtBlock.Text = student.Payeh;
            //Reshte_TxtBlock.Text = student.Reshteh;
            //NationalCode_TxtBlock.Text = student.NationalCode;
            //StudentCode_TxtBlock.Text = student.StudentCode;
            //Bimary_TxtBlock.Text = student.BimaryKhas;
            //HomeAddress_TxtBlock.Text = student.HomeAddress;
            //HomePhoneNumber_TxtBlock.Text = student.HomePhoneNumber;
            //FatherName_TxtBlock.Text = student.FatherName;
            //FatherJob_TxtBlock.Text = student.FatherJob;
            //FatherMobile_TxtBlock.Text = student.FatherMobile;
            //MotherJob_TxtBlock.Text = student.MotherJob;
            //MotherMobile_TxtBlock.Text = student.MotherMobile;
            //Profile_Border.Background = ConvertImageToBackground(student.Profile);
            //LeftParent_Img.Source = CheckLeftParent(student.LeftParent);

        }

        BitmapImage CheckLeftParent (bool LeftParent)
        {
            BitmapImage brush = new BitmapImage();

            if (LeftParent)
            {
                brush = new BitmapImage(new Uri("/done.png", UriKind.Relative));
            }
            else
            {
                brush = new BitmapImage(new Uri("/EnzebatiIco(Black).png", UriKind.Relative)); //Paste No Icon
            }
            return brush;
        }

        ImageBrush ConvertImageToBackground(string Address)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(Address, UriKind.Relative);
            bitmapImage.EndInit();
            ImageBrush imageBrush = new ImageBrush(bitmapImage);
            return imageBrush;
        }
    }
}
