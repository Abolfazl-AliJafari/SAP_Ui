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
        public StudentTazakorComponent1()
        {
            InitializeComponent();
        }

        public string Date { get; set; }
        public string Type { get; set; }
        public string CodeStudent { get; set; }
        public string Elat { get; set; }
        public string EghdamKonande { get; set; }
        public StudentTazakorComponent1(string date, string elat, string type, string codeStudent, string eghdamKonande)
        {
            InitializeComponent();
            Date = date;
            Type = type;
            CodeStudent = codeStudent;
            Elat = elat;
            EghdamKonande = eghdamKonande;
        }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (Date != null)
            {
                ShowDate_TxtBlock.Text = Date;
            }
            EghdamKonandeTazakor_Txt.Text = EghdamKonande;
            ElatTazakor_Txt.Text = Elat;
            TypeTazakor_CmBox.Text = Type;
        }
    }
}
