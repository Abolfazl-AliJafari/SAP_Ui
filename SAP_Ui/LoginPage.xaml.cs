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
using System.Windows.Shapes;
using Bll;
using DataAccessLayer;

namespace SAP_Ui
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        
        public LoginPage()
        {
            InitializeComponent();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                UserName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                UserName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }

        private void ShowPass_Btn_MouseEnter_1(object sender, MouseEventArgs e)
        {

        }
        //private void ShowPass_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ShowPass == false)
        //    {
        //        ShowPass = true;
        //        string imagePath = "/Property 1=visibility_off (2).png";
        //        BitmapImage bitmap = new BitmapImage();
        //        bitmap.BeginInit();
        //        bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
        //        bitmap.EndInit();
        //        //PassTxt_Img.Source = bitmap;
        //        string pass = PassWord_PassBx.Password;
        
        //        PassWord_PassBx.Password= pass;

        //    }
        //    else
        //    {
        //        ShowPass = false;
        //        string imagePath = "/ShowPass.png";
        //        BitmapImage bitmap = new BitmapImage();
        //        bitmap.BeginInit();
        //        bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
        //        bitmap.EndInit();
        //        //PassTxt_Img.Source = bitmap;
        //    }
        //}

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserName_Txt.Text;
            string passWord = PassWord_PassBx.Password;
            OperationResult result = Bll.User.Login(userName, passWord);
            Forms.homePage = new HomePage_Frm();
            if(result.Success== true)
            {
                Forms.homePage.ShowDialog();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
            
        }

        private void PassWord_Txt_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PassWord_Txt_LostFocus(object sender, RoutedEventArgs e)
        {
        
        }

        private void PassWord_PassBx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PassWord_PassBx.Password))
            {
                PassWord_PassBx.Password = PassWord_PassBx.Tag.ToString();
                PassWord_PassBx.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }

        private void PassWord_PassBx_GotFocus(object sender, RoutedEventArgs e)
        {

            if (PassWord_PassBx.Password == PassWord_PassBx.Tag.ToString())
            {
                PassWord_PassBx.Password = "";
                PassWord_PassBx.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
