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
    /// Interaction logic for GheybatTakhir.xaml
    /// </summary>
    public partial class GheybatTakhir : UserControl
    {
        public GheybatTakhir()
        {
            InitializeComponent();

        }
        List <Ghayeb> ghayebs= new List <Ghayeb>();
        List<Takhir> takhirs= new List <Takhir>();
        public GheybatTakhir(List<Ghayeb> Ghayebs,List<Takhir> Takhirs)
        {
            InitializeComponent();
            ghayebs = Ghayebs;
            takhirs = Takhirs;
        }
        TakhirForm takhirForm;
        GheybatForm gheybatForm;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            takhirForm = new TakhirForm() { takhirs = takhirs , Width=671.5 , Height= 256.5 };
            gheybatForm = new GheybatForm() { ghayebs = ghayebs,Width = 671.5, Height = 256.5 };
            Show_WrpPnl.Children.Add(takhirForm);
            Show_WrpPnl.Children.Add(gheybatForm);
            ShowPanel(takhirForm,gheybatForm);
            
        }

        private void ShowPanel (UserControl lastform ,UserControl form)
        {
            lastform.Visibility = Visibility.Hidden;
            form.Visibility = Visibility.Visible;
        }
        private void BtnGheybat_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            TakhirBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            GheybatBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            ShowPanel(takhirForm, gheybatForm);
        }

        private void Takhir_Btn_Click(object sender, RoutedEventArgs e)
        {
            BorderBtnTakhir.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            Takhir_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E3DFFC"));
            BorderBtnGheybat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Gheybat_Btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            TakhirBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            GheybatBtn_TextBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D1D1D"));
            ShowPanel(gheybatForm,takhirForm);
        }

    }
}
