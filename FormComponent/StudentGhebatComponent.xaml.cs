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
        public StudentGhebatComponent()
        {
            InitializeComponent();
        }
        public string Date { get; set; }
        public string Type { get; set; }
        public string CodeStudent { get; set; }
        public StudentGhebatComponent(string date,string type,string codeStudent)
        {
            InitializeComponent();
            Date= date;
            Type= type;
            CodeStudent= codeStudent;
        }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDate = ConvertDate.MiladiToShamsiNumberDate(calendar.SelectedDate.Value);
            ShowDate_TxtBlock.Text = selectedDate;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(Date!=null) 
            {
                ShowDate_TxtBlock.Text = Date;
            }
            TypeGheybat_CmBox.Text = Type;

        }
    }
}
