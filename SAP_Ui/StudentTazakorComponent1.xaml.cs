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
    /// Interaction logic for StudentTazakorComponent1.xaml
    /// </summary>
    public partial class StudentTazakorComponent1 : UserControl
    {
        public StudentTazakorComponent1(Tazakor_Tbl tazakor)
        {
            InitializeComponent();
            Tazakor = tazakor;
        }
        public Tazakor_Tbl Tazakor{ get; set; }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }
        void FillComboGheybatBoxe()
        {
            var mored = Bll.Mored.SelectTitles("تذکر");
            if (!mored.Success)
            {
                MessageBox.Show(mored.Message);
            }
            else
            {
                TypeTazakor_CmBox.ItemsSource = mored.Data;
            }
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            FillComboGheybatBoxe();
            ShowDate_TxtBlock.Text = Tazakor.TazakorDate;
            ElatTazakor_Txt.Text = Tazakor.TazakorElat;
            EghdamKonandeTazakor_Txt.Text = Tazakor.TazakorEghdamKonande;
            TypeTazakor_CmBox.Text = Tazakor.TazakorMoredTypeTitle;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Bll.Tazakor.Delete(Tazakor.Id);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Forms.studentInfo.RefreshTazakor();
            }
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Tazakor.TazakorElat = ElatTazakor_Txt.Text;
            Tazakor.TazakorEghdamKonande = EghdamKonandeTazakor_Txt.Text;
            Tazakor.TazakorMoredTypeTitle = TypeTazakor_CmBox.SelectedItem.ToString();
            var result = Bll.Tazakor.Update(Tazakor);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            
        }
    }
}
