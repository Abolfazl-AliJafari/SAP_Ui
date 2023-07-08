using Bll;
using DataAccessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormComponent
{
    /// <summary>
    /// Interaction logic for TakhirForm.xaml
    /// </summary>
    public partial class TakhirForm : UserControl
    {
        public TakhirForm(string Date)
        {
            InitializeComponent();
            date= Date;
        }

        string date;
        List<string> studentsCode;
        public string Date { get; set; }
        public string DateSelect { get; set; }
        public string FillTakhir()
        {
            TakhirsPanelShow_WrpPnl.Children.Clear();
            var takhirs = Bll.Takhir.Select(date);
            if (!takhirs.Success)
            {
                MessageBox.Show(takhirs.Message);
            }
            else
            {
                foreach (Takhir_Tbl takhir in takhirs.Data)
                {
                    TakhirsPanelShow_WrpPnl.Children.Add(new TakhirComponent(takhir) { Height = 56, Width = 631.5 });
                }
            }
            return takhirs.Data.Count.ToString();

        }

        

        public  void GetTakhirFilter (string Date)
        {
            TakhirsPanelShow_WrpPnl.Children.Clear();
            DateShow_Lbl.Content= Date;
            var result = Bll.Takhir.Select(Date);
            if(!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                foreach (Takhir_Tbl takhir in result.Data)
                {
                    TakhirsPanelShow_WrpPnl.Children.Add(new TakhirComponent(takhir) { Height = 56, Width = 631.5 });
                }
            }
        }


        void FillComboBoxes()
        {
            var result = Bll.Mored.SelectTitles("تاخیر");
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                TakhirTypeChoooze_CmBox.ItemsSource = result.Data;
            }
            var Names = Bll.Student.GetstudentName();
            if (!Names.Success)
            {
                MessageBox.Show(Names.Message);
            }
            else
            {
                TakhirChoozeName_CmBox.ItemsSource = Names.Data;

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
            DateShow_Lbl.Content= ShowDate_TxtBlock.Text;
            TakhirNumber_Lbl.Content = FillTakhir() + "تاخیر ";
            FillComboBoxes();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }

        private void AddTakhir_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Takhir_Tbl takhir = new Takhir_Tbl
                {
                    TakhirStudentName = TakhirChoozeName_CmBox.SelectedItem.ToString(),
                    TakhirMoredTypeTitle = TakhirTypeChoooze_CmBox.SelectedItem.ToString(),
                    TakhirDate = ShowDate_TxtBlock.Text,
                    TakhirStudentCode = studentsCode[TakhirChoozeName_CmBox.SelectedIndex],
                };

                var result = Bll.Takhir.Insert(takhir);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                TakhirNumber_Lbl.Content = FillTakhir() + "تاخیر ";
            }
            catch (Exception)
            {
                MessageBox.Show("فیلد ها را پر کنید");
            }
            
        }

        private void TakhirChoozeName_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
