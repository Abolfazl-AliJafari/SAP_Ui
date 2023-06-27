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
namespace FormComponent
{
    /// <summary>
    /// Interaction logic for RegisterStudentForm.xaml
    /// </summary>
    public partial class RegisterStudentForm : UserControl ,IDisposable
    {
        public RegisterStudentForm()
        {
            InitializeComponent();
        }
        public RegisterStudentForm(Student_Tbl Student)
        {
            InitializeComponent();
            edit = true;
            lastStudentCode = Student.StudentCode;
            student = Student;
        }

        RegisterStep1 step1;
        RegisterStep2 step2;
        RegisterStep3 step3;
        Student_Tbl student;
        byte step = 1;
        string lastStudentCode;
        bool edit= false;
        public bool Inserted { get; set; }
        public bool Edited { get; set; }
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
                Student_Tbl student_ = new Student_Tbl();
                student_.StudentFirstName = step1.StudentName;
                student_.StudentLastName = step1.StudentLastName;
                student_.StudentPayeh = step1.StudentPayeh;
                student_.StudentReshteh = step1.StudentReshte;
                student_.StudentNationalCode = step1.StudentNationalCode;
                student_.StudentCode = step1.StudentCode;
                student_.StudentProfile = step1.StudentProfileAddress;
                student_.StudentBimaryKhas = step1.StudentBimary;
                student_.StudentFatherName = step2.FatherName;
                student_.StudentFatherJob = step2.FatherJob;
                student_.StudentFatherMobile = step2.FatherMobile;
                student_.StudentMotherJob = step2.MotherJob;
                student_.StudentMotherMobile = step2.MotherMobile;
                student_.StudentParentBimary = step2.BimaryKhasParent;
                student_.StudentLeftParent = step2.LeftParent;
                student_.StudentDeadParent = step2.DeadParent;
                student_.StudentHomeAddress = step3.HomeAddress;
                student_.StudentHomeNumber = step3.HomeNumber;
                student_.StudentOther = step3.Other;
                student_.StudentScore = 20;
                if (!edit)
                {

                    student_.StudentRegisterDate = DateTime.Now.ToShortDateString();
                    var result = Bll.Student.Insert(student_);


                    if (result.Success)
                    {
                        Inserted = true;
                        step1.Registered();

                        step2.Registered();
                        step3.Registered();
                        step = 0;
                        NextStep_Btn_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                    
                }
                else
                {
                    var result = Bll.Student.Update(lastStudentCode, student_);
                    if(result.Success)
                    {
                        Edited= true;
                        DialogHost.CloseDialogCommand.Execute(null,null);
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
            }
            
        }

        void ShowStep1()
        {
            step1.Visibility = Visibility.Visible;  
            step2.Visibility = Visibility.Hidden;
            step3.Visibility = Visibility.Hidden;
            NextStep_Btn.Content = "بعدی";
        }

        void ShowStep2()
        {
            step2.Visibility = Visibility.Visible;
            step1.Visibility = Visibility.Hidden;
            step3.Visibility = Visibility.Hidden;
            NextStep_Btn.Content = "بعدی";
        }

        void ShowStep3()
        {
            step3.Visibility = Visibility.Visible;
            step2.Visibility = Visibility.Hidden;
            step1.Visibility = Visibility.Hidden;
            if (edit)
            {
                NextStep_Btn.Content = "ویرایش";

            }
            else
            {
                NextStep_Btn.Content = "ثبت";
            }
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                 step1 = new RegisterStep1(student.StudentFirstName, student.StudentLastName, student.StudentPayeh, student.StudentReshteh, student.StudentNationalCode, student.StudentCode, student.StudentProfile, student.StudentBimaryKhas)
                {
                    VerticalAlignment= VerticalAlignment.Top,
                    Width = 352
                };
                 step2 = new RegisterStep2(student.StudentFatherName, student.StudentFatherJob, student.StudentFatherMobile, student.StudentMotherJob, student.StudentMotherMobile,
                    (bool)student.StudentLeftParent, student.StudentDeadParent, student.StudentParentBimary)
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    Visibility = Visibility.Hidden,
                    Width = 352
                };
                 step3 = new RegisterStep3(student.StudentHomeAddress, student.StudentHomeNumber, student.StudentOther)
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    Visibility = Visibility.Hidden,
                    Width = 352
                };
                ShowStep_Grid.Children.Add(step1);
                ShowStep_Grid.Children.Add(step2);
                ShowStep_Grid.Children.Add(step3);

            }
            else
            {
                 step1 = new RegisterStep1()
                {

                    VerticalAlignment= VerticalAlignment.Top,
                    Width = 352
                };
                 step2 = new RegisterStep2()
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    Visibility = Visibility.Hidden,
                    Width = 352
                };
                 step3 = new RegisterStep3()
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    Visibility = Visibility.Hidden,
                    Width = 352
                };
                ShowStep_Grid.Children.Add(step1);
                ShowStep_Grid.Children.Add(step2);
                ShowStep_Grid.Children.Add(step3);
            }
        }
        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
