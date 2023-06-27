using DataAccessLayer;
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
    /// Interaction logic for GhayebComponent.xaml
    /// </summary>
    public partial class GhayebComponent : UserControl
    {
        public GhayebComponent()
        {
            InitializeComponent();
        }
        public GhayebComponent(Gheybat_Tbl Ghayeb)
        {
            InitializeComponent();
            ghayeb = Ghayeb;
        }
        public Gheybat_Tbl ghayeb { get; set; }
        public string MoredTitle{ get; set; }
        void FillComboBox()
        {
            var result = Bll.Mored.SelectTitles("غیبت");
            var names = Bll.Student.GetstudentName();
            if (!names.Success)
            {
                MessageBox.Show(names.Message);
            }
            else
            {
                GheybatName_CmBox.ItemsSource = names.Data;
            }
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                GheybatType_CmBox.ItemsSource = result.Data;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            GheybatName_CmBox.Text= ghayeb.GheybatStudentName;
            GheybatType_CmBox.Text= ghayeb.GheybatMoredTypeTitle;
            ShowDate_TxtBlock.Text = ghayeb.GheybatDate;

        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }


        private void GheybatType_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ghayeb.GheybatMoredTypeTitle = GheybatType_CmBox.SelectedItem.ToString();
            var result = Bll.Gheybat.Update(ghayeb);
            if(!result.Success) 
            {
                MessageBox.Show(result.Message);
            }
        }

        private void GheybatName_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
