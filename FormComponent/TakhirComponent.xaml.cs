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
    /// Interaction logic for TakhirComponent.xaml
    /// </summary>
    public partial class TakhirComponent : UserControl
    {
        public TakhirComponent()
        {
            InitializeComponent();
        }
        public TakhirComponent(Takhir_Tbl takhir)
        {
            InitializeComponent();
            Takhir = takhir;
        }
        public Takhir_Tbl Takhir { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            TakhirName_CmBox.Text = Takhir.TakhirStudentName;
            TakhirType_CmBox.Text = Takhir.TakhirMoredTypeTitle;
            ShowDate_TxtBlock.Text = Takhir.TakhirDate;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void FillComboBox()
        {
            var result = Bll.Mored.SelectTitles("تاخیر");
            var names = Bll.Student.GetstudentName();
            if(!names.Success)
            {
                MessageBox.Show(names.Message);
            }
            else
            {
                TakhirName_CmBox.ItemsSource = names.Data;
            }
            if(!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                TakhirType_CmBox.ItemsSource = result.Data;
            }
        }
        private void TakhirType_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Takhir.TakhirMoredTypeTitle = TakhirType_CmBox.SelectedItem.ToString();
            var result = Bll.Takhir.Update(Takhir);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
        }

        private void TakhirName_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
