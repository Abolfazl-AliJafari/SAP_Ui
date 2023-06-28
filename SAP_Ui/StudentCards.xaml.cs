using DataAccessLayer;
using SAP_Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for StudentCards.xaml
    /// </summary>
    public partial class StudentCards : UserControl
    {
        public StudentCards()
        {
            InitializeComponent();
        }
        public StudentCards(Student_Tbl Student)
        {
            InitializeComponent();
            student = Student;
        }

        public Student_Tbl student { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (student != null)
            {
                FullName_TxtBlock.Text = student.StudentFirstName+"  "+student.StudentLastName;
                Payeh_TxtBlock.Text = student.StudentPayeh;
                Reshte_TxtBlock.Text = student.StudentReshteh;

                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(student.StudentProfile, UriKind.Relative));
                Profile_Img.Background = brush;
            }
        }


        public void ShowChckBox()
        {
            StudentSelect_ChckBox.Visibility = Visibility.Visible;
        }

        public void HideChckBox()
        {
            StudentSelect_ChckBox.Visibility= Visibility.Collapsed;
            StudentCard_Border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            StudentSelect_ChckBox.IsChecked= false;
        }

        private void StudentSelect_ChckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)StudentSelect_ChckBox.IsChecked)
            {
                StudentCard_Border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            }
            else
                StudentCard_Border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forms.studentInfo = new StudentInfo(student)
            {
                Height = 540,
                Width = 960
            };
            Forms.studentInfo.ShowDialog();
            if(Forms.studentInfo.Deleted)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}
