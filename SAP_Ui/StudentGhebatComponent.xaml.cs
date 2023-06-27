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
    /// Interaction logic for StudentGhebatComponent.xaml
    /// </summary>
    public partial class StudentGhebatComponent : UserControl
    {
        public StudentGhebatComponent(Gheybat_Tbl gheybat)
        {
            InitializeComponent();
            Gheybat = gheybat;
        }
        public Gheybat_Tbl Gheybat { get; set; }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }

        void FillComboGheybatBoxe()
        {
            var mored = Bll.Mored.SelectTitles("غیبت");
            if(!mored.Success)
            {
                MessageBox.Show(mored.Message);
            }
            else
            {
                TypeGheybat_CmBox.ItemsSource = mored.Data;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboGheybatBoxe();
            TypeGheybat_CmBox.Text = Gheybat.GheybatMoredTypeTitle;
            ShowDate_TxtBlock.Text = Gheybat.GheybatDate;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {

            var result = Bll.Gheybat.Delete(Gheybat.GheybatStudentCode, Gheybat.GheybatDate);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Forms.studentInfo.RefreshGheybat();
            }
        }

        private void TypeGheybat_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gheybat.GheybatMoredTypeTitle = TypeGheybat_CmBox.SelectedItem.ToString();
            var result = Bll.Gheybat.Update(Gheybat);
            if(!result.Success)
            {
                MessageBox.Show(result.Message);
            }

        }
    }
}
