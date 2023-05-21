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
        public Takhir takhir { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GhayebName_CmBox.SelectedItem = takhir.Name;
            TypeGheybat_CmBox.SelectedItem = takhir.Type;
            ShowDate_TxtBlock.Text = takhir.Date;
        }
    }
}
