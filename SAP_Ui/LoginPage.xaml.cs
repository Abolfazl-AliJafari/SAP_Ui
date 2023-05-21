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
        bool ShowPass = false;
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag.ToString())
                textBox.Text = "";
        }
        public void AddText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = textBox.Tag.ToString();
        }

        private void ShowPass_Btn_MouseEnter_1(object sender, MouseEventArgs e)
        {

        }
        private void ShowPass_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ShowPass == false)
            {
                ShowPass = true;
                string imagePath = "/Property 1=visibility_off (2).png";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
                bitmap.EndInit();
                PassTxt_Img.Source = bitmap;
            }
            else
            {
                ShowPass = false;
                string imagePath = "/Component 7 (1).png";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
                bitmap.EndInit();
                PassTxt_Img.Source = bitmap;
            }
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            new HomePage_Frm().ShowDialog();
        }

        private void Login_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
        }
    }
}
