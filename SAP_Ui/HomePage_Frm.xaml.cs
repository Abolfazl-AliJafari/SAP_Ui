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
using System.Windows.Media.Animation;
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
        bool DeleteReady = false;
        public string Dahom { get; set; }
        public string Yazdahom { get; set; }
        public string Davazdahom { get; set; }
        public string Hesabdari { get; set; }
        public string Shabake { get; set; }
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

        void Filter(string Dahom,string Yazdahom, string Davazdahom, string Hesabdari, string Shabake)
        {

            foreach (StudentCards studentCards in SudentCard_WrpPnl.Children)
            {
                if (studentCards.student.StudentPayeh == Dahom || studentCards.student.StudentPayeh == Yazdahom || studentCards.student.StudentPayeh == Davazdahom  ) //رشته کار نمیکنه
                {
                    if(Hesabdari!="" || Shabake!="")
                    {
                        if(studentCards.student.StudentReshteh == Hesabdari || studentCards.student.StudentReshteh == Shabake)
                        {
                            studentCards.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            studentCards.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        studentCards.Visibility = Visibility.Visible;

                    }

                }
                else
                {
                    studentCards.Visibility = Visibility.Collapsed;
                }

                //(SudentCard_WrpPnl.Children[i] as StudentCards).student = check.Data[i];
            }
        }

        private void DahomChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.DahomChckBox.IsChecked == true)
            {
                ChckBoxDahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                DahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
                Dahom = DahomChckBox.Content.ToString();
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);

            }
            else
            {
                ChckBoxDahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                DahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                Dahom = "";
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
              
            }

        }

        private void YazdahomChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.YazdahomChckBox.IsChecked == true)
            {
                ChckBoxYazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                YazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));

                Yazdahom = YazdahomChckBox.Content.ToString();
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
            else
            {
                ChckBoxYazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                YazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                Yazdahom = "";
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
        }

        private void DavazdahomChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.DavazdahomChckBox.IsChecked == true)
            {
                ChckBoxDavazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                DavazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
               Davazdahom = DavazdahomChckBox.Content.ToString();
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
            else
            {
                ChckBoxDavazdahomBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                DavazdahomChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                Davazdahom = "";
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
        }

        private void HesabdariChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.HesabdariChckBox.IsChecked == true)
            {
                ChckBoxHesabdariBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                HesabdariChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
                Hesabdari = HesabdariChckBox.Content.ToString();
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
            else
            {
                ChckBoxHesabdariBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                HesabdariChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                Hesabdari = "";
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
        }

        private void ShabakeChckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.ShabakeChckBox.IsChecked == true)
            {
                ChckBoxShabakeBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
                ShabakeChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6750A4"));
                Shabake = ShabakeChckBox.Content.ToString();
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
            else
            {
                ChckBoxShabakeBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                ShabakeChckBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                Shabake = "";
                Filter(Dahom, Yazdahom, Davazdahom, Hesabdari, Shabake);
            }
        }

        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Shabake = "";
            Hesabdari = "";
            Dahom = "";
            Yazdahom = "";
            Davazdahom= "";
            DateHome_TxtBlock.Text = ConvertDate.MiladiToShamsiWithMonthName(DateTime.Now);
            var result = Bll.Student.Select();
            foreach(var student in result.Data)
            {
                SudentCard_WrpPnl.Children.Add(new StudentCards(student) { Height = 185 ,Width = 161.5 });
            }
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
            if(DeleteReady)
            {
                foreach(object card in SudentCard_WrpPnl.Children)
                {
                    if(card is StudentCards)
                    {
                        (card as StudentCards).HideChckBox();
                    }
                }
                DeleteReady= false;
                deletepnl_Grid.Visibility = Visibility.Collapsed;
            }
            else
            {
                foreach (object card in SudentCard_WrpPnl.Children)
                {
                    if (card is StudentCards)
                    {
                        (card as StudentCards).ShowChckBox();
                    }
                }
                deletepnl_Grid.Visibility = Visibility.Visible;
                DeleteReady = true;
            }
           
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StudentSearch_Txt.Focus();
        }

        private void SearchBoxBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StudentSearch_Txt.Focus();
        }

        private void MavaredEnzebati_Btn_Click(object sender, RoutedEventArgs e)
        {
            ShowMavaredEnzebati_Grid.Visibility = Visibility.Visible;
            ShowStudents_Grid.Visibility = Visibility.Hidden;

        }

        private void GoHome_Btn_Click(object sender, RoutedEventArgs e)
        {
            ShowMavaredEnzebati_Grid.Visibility = Visibility.Hidden;
            ShowStudents_Grid.Visibility = Visibility.Visible;
        }

        private void DahomChckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
