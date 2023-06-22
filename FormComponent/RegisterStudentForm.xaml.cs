using Bll;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAP_Ui;

namespace FormComponent
{
    /// <summary>
    /// Interaction logic for RegisterStudentForm.xaml
    /// </summary>
    public partial class RegisterStudentForm : UserControl
    {
        public RegisterStudentForm()
        {
            InitializeComponent();
        }
        byte step = 1;
        public bool Inserted { get; set; }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NextStep_Btn_Click(object sender, RoutedEventArgs e)
        {
                if (step + 1 <= 4 && step + 1 >= 0)
                {
                    step++;
                }
            if (step == 1)
            {
                ShowStep1();
            }
            else if (step == 2)
            {
                ShowStep2();
            }
            else if (step == 3)
            {
                ShowStep3();

            }
            else
            {
                Student_Tbl student = new Student_Tbl();
                student.StudentFirstName = Step1.StudentName;
                student.StudentLastName = Step1.StudentLastName;
                student.StudentPayeh = Step1.StudentPayeh;
                student.StudentReshteh = Step1.StudentReshte;
                student.StudentNationalCode = Step1.StudentNationalCode;
                student.StudentCode = Step1.StudentCode;
                student.StudentProfile = Step1.StudentProfileAddress;
                student.StudentBimaryKhas = Step1.StudentBimary;
                student.StudentFatherName = Step2.FatherName;
                student.StudentFatherJob = Step2.FatherJob;
                student.StudentFatherMobile = Step2.FatherMobile;
                student.StudentMotherJob = Step2.MotherJob;
                student.StudentMotherMobile = Step2.MotherMobile;
                student.StudentParentBimary = Step2.BimaryKhasParent;
                student.StudentLeftParent = Step2.LeftParent;
                student.StudentDeadParent = Step2.DeadParent;
                student.StudentRegisterDate = DateTime.Now.ToShortDateString();
                student.StudentHomeAddress = Step3.HomeAddress;
                student.StudentHomeNumber = Step3.HomeNumber;
                student.StudentOther = Step3.Other;
                student.StudentScore = 20;

                var result = Bll.Student.Insert(student);
                
                
                if (result.Success == true)
                {
                    Inserted = true;
                    Step1.Registered();
              
                    Step2.Registered();
                    Step3.Registered();
                    step = 0;
                    NextStep_Btn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            
        }

        void ShowStep1()
        {
            Step1.Visibility = Visibility.Visible;  
            Step2.Visibility = Visibility.Hidden;
            Step3.Visibility = Visibility.Hidden;
            NextStep_Btn.Content = "بعدی";
        }

        void ShowStep2()
        {
            Step2.Visibility = Visibility.Visible;
            Step1.Visibility = Visibility.Hidden;
            Step3.Visibility = Visibility.Hidden;
            NextStep_Btn.Content = "بعدی";
        }

        void ShowStep3()
        {
            Step3.Visibility = Visibility.Visible;
            Step2.Visibility = Visibility.Hidden;
            Step1.Visibility = Visibility.Hidden;
            NextStep_Btn.Content = "ثبت";
        }
        private void PerviuosStep_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (step-1 <=3 && step-1>=1)
            {
                step--;
            }
            if (step == 1)
            {
                ShowStep1();
            }
            else if (step == 2)
            {
                ShowStep2();
            }
            else
            {
                ShowStep3();
            }
        }
    }
}
