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
    public partial class RegisterStudentForm : UserControl
    {
        public RegisterStudentForm()
        {
            InitializeComponent();
        }
        byte step = 1;
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NextStep_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (step+1 <= 3 && step+1 >= 1)
            {
                step++;
            }
            if (step==1)
            {
                ShowStep1();
            }
            else if(step == 2)
            {
                ShowStep2();
            }
            else
            {
                ShowStep3();
            }
        }

        void ShowStep1()
        {
            Step1.Visibility = Visibility.Visible;  
            Step2.Visibility = Visibility.Hidden;
            Step3.Visibility = Visibility.Hidden;
        }

        void ShowStep2()
        {
            Step2.Visibility = Visibility.Visible;
            Step1.Visibility = Visibility.Hidden;
            Step3.Visibility = Visibility.Hidden;
        }

        void ShowStep3()
        {
            Step3.Visibility = Visibility.Visible;
            Step2.Visibility = Visibility.Hidden;
            Step1.Visibility = Visibility.Hidden;
        }
        private void PerviuosStep_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(step-1 <=3 && step-1>=1)
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
