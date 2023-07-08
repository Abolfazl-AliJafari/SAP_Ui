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
    /// Interaction logic for StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        public StudentInfo(Student_Tbl Student)
        {
            InitializeComponent();
            student = Student;
        }
        public bool Deleted { get; set; }
        public  Student_Tbl student { get; set; }
        private async void EditStudent_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Bll.Student.SelectStudent(student.StudentCode);
            if(!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            RegisterStudentForm registerStudentForm = new RegisterStudentForm(result.Data);
            await ShowDialog_DgHost.ShowDialog(registerStudentForm);
            if(registerStudentForm.Edited)
            {
                RefreshStudentInfo();
            }
        }


        void NowDate()
        {
            calendar.SelectedDate = DateTime.Now;
            calendar1.SelectedDate = DateTime.Now;
        }
        void FillComboBoxes()
        {
            var tashvighMavared = Bll.Mored.SelectTitles("تشویق");
            if(!tashvighMavared.Success)
            {
                MessageBox.Show(tashvighMavared.Message);
            }
            else
            {
                TypeTashvigh_CmBox.ItemsSource = tashvighMavared.Data;
            }
            var tazakorMavared = Bll.Mored.SelectTitles("تذکر");
            if (!tazakorMavared.Success)
            {
                MessageBox.Show(tazakorMavared.Message);
            }
            else
            {
                TypeTazakor_CmBox.ItemsSource = tazakorMavared.Data;
            }
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
         

        public void RefreshGheybat()
        {
            Gheybat_StckPnl.Children.Clear();
            var gheybats = Bll.Gheybat.SelectGheybatsStudent(student.StudentCode);
            if(!gheybats.Success)
            {
                MessageBox.Show(gheybats.Message);
            }
            else
            {
                foreach (Gheybat_Tbl gheybat in gheybats.Data)
                {
                    Gheybat_StckPnl.Children.Add(new StudentGhebatComponent(gheybat) { Height = 56 ,Width = 631.5 });
                }
            }
        }

        public void RefreshTakhir()
        {
            Takhir_StckPnl.Children.Clear();
            var takhirs = Bll.Takhir.SelectTakhirsStudent(student.StudentCode);
            if (!takhirs.Success)
            {
                MessageBox.Show(takhirs.Message);
            }
            else
            {
                foreach (Takhir_Tbl takhir in takhirs.Data)
                {
                    Takhir_StckPnl.Children.Add(new StudentTakhirComponent(takhir) { Height = 56, Width = 631.5 });
                }
            }
        }

        public void RefreshTazakor()
        {
            Tazakor_StckPnl.Children.Clear();

            var tazakors = Bll.Tazakor.SelectTazakorsStudent(student.StudentCode);
            if (!tazakors.Success)
            {
                MessageBox.Show(tazakors.Message);
            }
            else
            {
                foreach (Tazakor_Tbl tazakor in tazakors.Data)
                {
                    Tazakor_StckPnl.Children.Add(new StudentTazakorComponent1(tazakor) { Height = 56, Width = 631.5 });
                }
            }
        }

        public void RefreshTashvigh()
        {
            Tashvigh_StckPnl.Children.Clear();
            var tashvighs = Bll.Tashvigh.SelectTashvighsStudent(student.StudentCode);
            if (!tashvighs.Success)
            {
                MessageBox.Show(tashvighs.Message);
            }
            else
            {
                foreach (Tashvigh_Tbl tashvigh in tashvighs.Data)
                {
                    Tashvigh_StckPnl.Children.Add(new StudentTashvighComponent(tashvigh) { Height = 56, Width = 631.5 });
                }
            }

        }
        private void RefreshStudentInfo ()
        {
            var result = Bll.Student.SelectStudent(student.StudentCode);
            StudentFullName_TxtBlock.Text = result.Data.StudentFirstName +"  "+ result.Data.StudentLastName;
            Payeh_TxtBlock.Text = result.Data.StudentPayeh;
            Reshte_TxtBlock.Text = result.Data.StudentReshteh;
            NationalCode_TxtBlock.Text = result.Data.StudentNationalCode;
            StudentCode_TxtBlock.Text = result.Data.StudentCode;
            Bimary_TxtBlock.Text = result.Data.StudentBimaryKhas;
            HomeAddress_TxtBlock.Text = result.Data.StudentHomeAddress;
            HomePhoneNumber_TxtBlock.Text = result.Data.StudentHomeNumber;
            FatherName_TxtBlock.Text = result.Data.StudentFatherName;
            FatherJob_TxtBlock.Text = result.Data.StudentFatherJob;
            FatherMobile_TxtBlock.Text = result.Data.StudentFatherMobile;
            MotherJob_TxtBlock.Text = result.Data.StudentMotherJob;
            ParentDead_TxtBlock.Text = result.Data.StudentDeadParent;
            MotherMobile_TxtBlock.Text = result.Data.StudentMotherMobile;
            BimaryParent_TxtBlock.Text = result.Data.StudentParentBimary;
            Profile_Border.Background = ConvertImageToBackground(result.Data.StudentProfile);
            LeftParent_Img.Source = CheckLeftParent((bool)result.Data.StudentLeftParent);
            OtherAbout_TxtBlock.Text = result.Data.StudentOther;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NowDate();
            RefreshStudentInfo();
            FillComboBoxes();
            RefreshGheybat();
            RefreshTakhir();
            RefreshTashvigh();  
            RefreshTazakor();
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
                brush = new BitmapImage(new Uri("/cross.png", UriKind.Relative)); //Paste No Icon
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

        private async void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            SubmitDelete submitDelete = new SubmitDelete("از حذف دانش آموز مطمئن هستید؟", student) { Height = 90, Width = 299 };
           await ShowDialog_DgHost.ShowDialog(submitDelete);
            if (submitDelete.CloseOrOpen)
            {
                if (submitDelete.Result)
                {
                    Deleted = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("حذف موفقیت آمیز نبود");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel= true;
            this.Hide();
        }

        private void AddTazakor_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tazakor_Tbl tazakor = new Tazakor_Tbl()
                {
                    TazakorElat = ElatTazakor_Txt.Text,
                    TazakorEghdamKonande = EghdamKonandeTazakor_Txt.Text,
                    TazakorDate = ShowDate_TxtBlock.Text,
                    TazakorMoredTypeTitle = TypeTazakor_CmBox.SelectedItem.ToString(),
                    TazakorStudentCode = student.StudentCode
                };
                var result = Bll.Tazakor.Insert(tazakor);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    RefreshTazakor();
                    ElatTazakor_Txt.Clear();
                    EghdamKonandeTazakor_Txt.Clear();
                    TypeTazakor_CmBox.Text = string.Empty;
                    calendar.SelectedDate = DateTime.Now;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("فیلد ها را پر کنید");
            }
           
        }

        private void AddTashvigh_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tashvigh_Tbl tashvigh = new Tashvigh_Tbl()
                {
                    TashvighElat = ElatTashvigh_Txt.Text,
                    TashvighEghdamKonande = EghdamKonandeTashvigh_Txt.Text,
                    TashvighDate = ShowDate1_TxtBlock.Text,
                    TashvighMoredTypeTitle = TypeTashvigh_CmBox.SelectedItem.ToString(),
                    TashvighStudentCode = student.StudentCode
                };
                var result = Bll.Tashvigh.Insert(tashvigh);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    RefreshTashvigh();
                    ElatTashvigh_Txt.Clear();
                    EghdamKonandeTashvigh_Txt.Clear();
                    TypeTashvigh_CmBox.Text= string.Empty;
                    calendar1.SelectedDate = DateTime.Now;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("فیلد ها را پر کنید");
            }
            
        }

        private async void  ShowScore_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ShowDialog_DgHost.ShowDialog(new ShowScore(student.StudentCode) { Height = 90, Width = 299 });
            }
            catch (Exception)
            {
                MessageBox.Show("دیالوگ باز است");
            }
            
        }
    }
}
