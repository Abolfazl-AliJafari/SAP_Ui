using DataAccessLayer;
using SAP_Ui;
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
    /// Interaction logic for StudentTakhirComponent.xaml
    /// </summary>
    public partial class StudentTakhirComponent : UserControl
    {
        public StudentTakhirComponent(Takhir_Tbl takhir)
        {
            InitializeComponent();
            Takhir = takhir;
        }
        public Takhir_Tbl Takhir { get; set; }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate; 
        }
        void FillComboGheybatBoxe()
        {
            var mored = Bll.Mored.SelectTitles("تاخیر");
            if (!mored.Success)
            {
                MessageBox.Show(mored.Message);
            }
            else
            {
                TypeTakhir_CmBox.ItemsSource = mored.Data;
            }
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            FillComboGheybatBoxe();
            TypeTakhir_CmBox.Text = Takhir.TakhirMoredTypeTitle;
            ShowDate_TxtBlock.Text = Takhir.TakhirDate;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Bll.Takhir.Delete(Takhir.TakhirStudentCode,Takhir.TakhirDate);
            if(!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Forms.studentInfo.RefreshTakhir();
            }
        }

        private void TypeTakhir_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Takhir.TakhirMoredTypeTitle = TypeTakhir_CmBox.SelectedItem.ToString();
            var result = Bll.Takhir.Update(Takhir);
            if(!result.Success)
            {
               MessageBox.Show(result.Message);
            }

        }
    }
}
