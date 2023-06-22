using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SAP_Ui;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace FormComponent
{
    /// <summary>
    /// Interaction logic for SubmitDelete.xaml
    /// </summary>
    public partial class SubmitDelete : UserControl
    {
        List<Student_Tbl> students;
        Student_Tbl student;
        public bool Result { get; set; }
        public bool CloseOrOpen { get; set; }
        public SubmitDelete(string Massage , List<Student_Tbl> Students)
        {
            InitializeComponent();
            Massage_TxtBlock.Text = Massage;
            students = Students;
        }
        public SubmitDelete(string Massage, Student_Tbl Student)
        {
            InitializeComponent();
            Massage_TxtBlock.Text = Massage;
            student = Student;
        }
       
        private void SubmitDelete_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(student != null)
            {
                var result = Bll.Student.Delete(student);
                Result = result.Success;
                CloseOrOpen = true;
                DialogHost.CloseDialogCommand.Execute(null, null);

            }
            else
            {
                var result = Bll.Student.DeleteStudents(students);
                Result = result.Success;
                CloseOrOpen = true;
                DialogHost.CloseDialogCommand.Execute(null, null);

            }
        }
    }
}
