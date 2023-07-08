using Bll;
using DataAccessLayer;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormComponent
{
    /// <summary>
    /// Interaction logic for GheybatForm.xaml
    /// </summary>
    public partial class GheybatForm : UserControl
    {
        public GheybatForm(string Date)
        {
            InitializeComponent();
            date = Date;
        }
        string date;
        List<string> studentsCode;
        public string DateSelect { get; set; }
        public string FillGhayeb()
        {
            GhayebsPanelShow_WrpPnl.Children.Clear();
            var gheybats = Bll.Gheybat.Select(date);
            if (!gheybats.Success)
            {
                MessageBox.Show(gheybats.Message);
            }
            else
            {
                foreach (Gheybat_Tbl ghayeb in gheybats.Data)
                {
                    GhayebsPanelShow_WrpPnl.Children.Add(new GhayebComponent(ghayeb) { Height = 56, Width = 631.5 });
                }
            }
            DateShow_Lbl.Content= date;
            return gheybats.Data.Count.ToString();

        }

        public void GetGheybatFilter(string Date)
        {
            GhayebsPanelShow_WrpPnl.Children.Clear();

            var result = Bll.Gheybat.Select(Date);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                foreach (Gheybat_Tbl ghayeb in result.Data)
                {
                    GhayebsPanelShow_WrpPnl.Children.Add(new GhayebComponent(ghayeb) { Height = 56, Width = 631.5 });
                }
                DateShow_Lbl.Content = Date;

            }
        }
        void FillComboBoxes()
        {
            var result = Bll.Mored.SelectTitles("غیبت");
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                GhayebTypeChoooze_CmBox.ItemsSource = result.Data;
            }
            var Names = Bll.Student.GetstudentName();
            if (!Names.Success)
            {
                MessageBox.Show(Names.Message);
            }
            else
            {
                GhayebChoozeName_CmBox.ItemsSource = Names.Data;

            }

            var codes = Bll.Student.GetstudentCode();
            if (!codes.Success)
            {
                MessageBox.Show(codes.Message);
            }
            else
            {
                studentsCode = codes.Data;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            calendar.SelectedDate = DateTime.Now;
            FillComboBoxes();
            GhayebNumber_Lbl.Content = "غایب"+FillGhayeb();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
         {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }

        private void AddGheybat_Btn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Gheybat_Tbl gheybat = new Gheybat_Tbl
                {
                    GheybatStudentName = GhayebChoozeName_CmBox.SelectedItem.ToString(),
                    GheybatMoredTypeTitle = GhayebTypeChoooze_CmBox.SelectedItem.ToString(),
                    GheybatDate = ShowDate_TxtBlock.Text,
                    GheybatStudentCode = studentsCode[GhayebChoozeName_CmBox.SelectedIndex],
                };

                var result = Bll.Gheybat.Insert(gheybat);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                GhayebNumber_Lbl.Content = FillGhayeb();
            }
            catch(Exception)
            {
                MessageBox.Show("فیلد ها را پر کنید");
            }
        }
    }
}
