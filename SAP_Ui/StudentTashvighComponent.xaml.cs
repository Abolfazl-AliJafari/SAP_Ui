using DataAccessLayer;
using SAP_Ui;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormComponent
{
    /// <summary>
    /// Interaction logic for StudentTashvighComponent.xaml
    /// </summary>
    public partial class StudentTashvighComponent : UserControl
    {
        public StudentTashvighComponent(Tashvigh_Tbl tashvigh)
        {
            InitializeComponent();
            Tashvigh = tashvigh;
        }
        public Tashvigh_Tbl Tashvigh { get; set; }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }
        void FillComboGheybatBoxe()
        {
            var mored = Bll.Mored.SelectTitles("تشویق");
            if (!mored.Success)
            {
                MessageBox.Show(mored.Message);
            }
            else
            {
                TypeTashvigh_CmBox.ItemsSource = mored.Data;
            }
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            FillComboGheybatBoxe();
            ShowDate_TxtBlock.Text = Tashvigh.TashvighDate;
            ElatTashvigh_Txt.Text = Tashvigh.TashvighElat;
            EghdamKonandeTashvigh_Txt.Text = Tashvigh.TashvighEghdamKonande;
            TypeTashvigh_CmBox.Text = Tashvigh.TashvighMoredTypeTitle;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Bll.Tashvigh.Delete(Tashvigh.Id);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Forms.studentInfo.RefreshTashvigh();
            }
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Tashvigh.TashvighElat = ElatTashvigh_Txt.Text;
            Tashvigh.TashvighEghdamKonande= EghdamKonandeTashvigh_Txt.Text;
            Tashvigh.TashvighMoredTypeTitle = TypeTashvigh_CmBox.SelectedItem.ToString();
            var result = Bll.Tashvigh.Update(Tashvigh);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }

        }
    }
}
