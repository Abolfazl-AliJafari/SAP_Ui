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
    /// Interaction logic for RegisterStep2.xaml
    /// </summary>
    public partial class RegisterStep2 : UserControl
    {
        public RegisterStep2()
        {
            InitializeComponent();
        }
        public string FatherName { get; set; }
        public string FatherJob { get; set; }
        public string FatherMobile { get; set; }
        public string MotherJob { get; set; }
        public string MotherMobile { get; set; }
        public bool LeftParent { get; set; }
        public string DeadParent { get; set; }
        public string BimaryKhasParent { get; set; }


        bool btnfatherClick = false;
        bool btnMotherClick = false;
        bool btnBothClick = false;


        private void FatherName_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            FatherName = FatherName_Txt.Text;
        }

        private void FatherJob_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            FatherJob = FatherJob_Txt.Text;
        }

        private void FatherMobile_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            FatherMobile= FatherMobile_Txt.Text;
        }

        private void MotherMobile_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            MotherMobile= MotherMobile_Txt.Text;
        }

        private void MotherJob_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            MotherJob= MotherJob_Txt.Text;
        }

        public void enable(bool Status)
        {
            Both_Btn.IsEnabled = Status;
            Father_Btn.IsEnabled = Status;
            Mother_Btn.IsEnabled = Status;
        }

        void clickcolor(Control Elm)
        {
            Elm.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7161EF"));
            Elm.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Button elm = Elm as Button;
           
        }
        void noclickcolor(Control Elm)
        {
            Elm.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            Elm.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }

        private void Both_Btn_Click(object sender, RoutedEventArgs e)
        {
            DeadParent = Both_Btn_TxtBlock.Text;
            if (btnBothClick)
            {
                btnBothClick = false;

                noclickcolor(Both_Btn);
            }
            else
            {
                btnBothClick= true;
                clickcolor(Both_Btn);
                noclickcolor(Father_Btn);
                noclickcolor(Mother_Btn);
            }
            btnMotherClick = false;
            btnfatherClick = false;

        }

        private void Mother_Btn_Click(object sender, RoutedEventArgs e)
        {
            DeadParent = Mother_Btn_TxtBlock.Text;
            if (btnMotherClick)
            {
                btnMotherClick= false;
                noclickcolor(Mother_Btn);
            }
            else
            {
                btnMotherClick= true;
                clickcolor(Mother_Btn);
                noclickcolor(Father_Btn);
                noclickcolor(Both_Btn);
            }
                btnfatherClick= false;
                btnBothClick = false;
        }

        private void Father_Btn_Click(object sender, RoutedEventArgs e)
        {
            DeadParent = Father_Btn_TxtBlock.Text;
            if(btnfatherClick)
            {
                btnfatherClick= false;
                noclickcolor(Father_Btn);
            }
            else
            {
                btnfatherClick= true;
                clickcolor(Father_Btn);
                noclickcolor(Both_Btn);
                noclickcolor(Mother_Btn);
            }
                btnMotherClick= false;
            btnBothClick = false;

        }

        private void ParentDeadToggle_Checked(object sender, RoutedEventArgs e)
        {
            bool check = (bool)ParentDeadToggle.IsChecked;
            enable(check);
        }

        private void ParentDeadToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            bool check = (bool)ParentDeadToggle.IsChecked;
            enable(check);
        }

        private void BimariKhas_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            BimaryKhasParent = BimariKhas_Txt.Text;
        }

        private void BimaryParentToggle_Checked(object sender, RoutedEventArgs e)
        {
            BimariKhas_Txt.IsEnabled = true;
        }

        private void BimaryParentToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            BimariKhas_Txt.IsEnabled= false;
            noclickcolor(Father_Btn);
            noclickcolor(Both_Btn);
            noclickcolor(Mother_Btn);
            DeadParent = "";
        }

        private void LeftParentToggle_Checked(object sender, RoutedEventArgs e)
        {
            LeftParent = (bool)LeftParentToggle.IsChecked;
        }

        private void LeftParentToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            LeftParent = (bool)LeftParentToggle.IsChecked;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LeftParent = false;
        }
    }
}
