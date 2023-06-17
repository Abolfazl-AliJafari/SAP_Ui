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
        public GheybatForm()
        {
            InitializeComponent();

        }
        public List<GetGhayeb> ghayebs = new List<GetGhayeb>();
        public GheybatForm(List<GetGhayeb> Ghayebs)
        {
            InitializeComponent();
            ghayebs = Ghayebs;
        }
        public string Date { get; set; }
        public string DateSelect { get; set; }
        public string FillGhayeb(List<GetGhayeb> ghayebs)
        {
            WrapPanel panel = new WrapPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Width = GhayebsPanelShow_WrpPnl.Width;
            panel.Height = GhayebsPanelShow_WrpPnl.Height;
            foreach (GetGhayeb ghayeb in ghayebs)
            {
                panel.FlowDirection = FlowDirection.LeftToRight;
                panel.Children.Add(new GhayebComponent() {ghayeb =ghayeb });
            }

            GhayebsPanelShow_WrpPnl.Children.Add(panel);
            return ghayebs.Count.ToString();

        }
        //private void BtnGheybat_Click(object sender, RoutedEventArgs e)
        //{
        //    BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        //    Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        //    BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
        //    Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
        //}

        //private void Takhir_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    //BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
        //    //Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
        //    //BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        //    //Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        //}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(ghayebs != null)
            {
               GhayebNumber_Lbl.Content = FillGhayeb(ghayebs)+"غایب ";
            }
        }
    }
}
