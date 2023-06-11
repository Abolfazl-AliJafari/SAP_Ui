using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for RegisterStep1.xaml
    /// </summary>
    public partial class RegisterStep1 : UserControl
    {
        public RegisterStep1()
        {
            InitializeComponent();
        }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentPayeh { get; set; }
        public string StudentReshte { get; set; }
        public string StudentNationalCode { get; set; }
        public string StudentCode { get; set; }
        public string StudentProfileAddress { get; set; }
        public string StudentBimary { get; set; }
        private void Profile_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "Image Files|*.bmp;*.jpeg;*.jpg;*.png;*.gif";
            openFileDialog.Title = "انتخاب پروفایل";
            if (openFileDialog.ShowDialog() == true)
            {
                StudentProfileAddress = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(StudentProfileAddress, UriKind.Relative);
                bitmapImage.EndInit();
                Profile_Img.Source = null;
                ImageBrush imageBrush= new ImageBrush(bitmapImage);
                ProfileImg_Border.Background = imageBrush;
            }
        }

        private void Name_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentName = Name_Txt.Text;
        }

        private void LastName_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentLastName = LastName_Txt.Text;
        }

        private void Payeh_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentPayeh = Payeh_CmBox.SelectedItem.ToString();
        }

        private void Reshteh_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentReshte = Reshteh_CmBox.SelectedItem.ToString();
        }

        private void NationalCode_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentNationalCode = NationalCode_Txt.Text;
        }

        private void StudentCode_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentCode = StudentCode_Txt.Text;
        }
    }
}
