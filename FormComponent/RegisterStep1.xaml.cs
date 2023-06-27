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
        bool Edit = false;

        public RegisterStep1(string FirstName , string LastName, string Payeh , string Reshteh , string NationalCode , string StudentCode
            ,string ProfileAddress,string Bimary)
        {
            InitializeComponent();
            StudentCode_Txt.IsReadOnly= true;
            NationalCode_Txt.IsReadOnly= true;
            Name_Txt.Text = FirstName;
            LastName_Txt.Text = LastName;
            Payeh_CmBox.Text = Payeh;
            Reshteh_CmBox.Text= Reshteh;
            NationalCode_Txt.Text = NationalCode;
            StudentCode_Txt.Text = StudentCode;
            if(!string.IsNullOrEmpty(Bimary))
            {
                BimariKhas_Txt.Text = Bimary;
                BimariToggle.IsChecked = true;
            }
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(ProfileAddress, UriKind.Relative);
            bitmapImage.EndInit();
            Profile_Img.Source = null;
            ImageBrush imageBrush = new ImageBrush(bitmapImage);
            ProfileImg_Border.Background = imageBrush;
            Edit = true;
            StudentProfileAddress = ProfileAddress;

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
            if (Payeh_CmBox.SelectedItem != null)
            {
                string item = Payeh_CmBox.SelectedItem.ToString();
                StudentPayeh = item.Split(':')[1].Trim();
            }
        }

        private void Reshteh_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Reshteh_CmBox.SelectedItem != null)
            {
                string item = Reshteh_CmBox.SelectedItem.ToString();
                StudentReshte = item.Split(':')[1].Trim();
            }
        }

        private void NationalCode_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentNationalCode = NationalCode_Txt.Text;
        }

        private void StudentCode_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentCode = StudentCode_Txt.Text;
        }

        private void BimariKhas_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentBimary = BimariKhas_Txt.Text;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            BimariKhas_Txt.IsEnabled = true;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            BimariKhas_Txt.IsEnabled = false;
            BimariKhas_Txt.Text = "";
            StudentBimary = "";
        }
        public void Registered()
        {
            Name_Txt.Clear();
            LastName_Txt.Clear();
            Payeh_CmBox.SelectedValue = "";
            Reshteh_CmBox.SelectedValue= "";
            NationalCode_Txt.Clear();
            StudentCode_Txt.Clear();
            BimariKhas_Txt.Clear();
            BimariToggle.IsChecked = false;
            StudentName = "";
            StudentLastName = "";
            StudentNationalCode = "";
            StudentCode = "";
            StudentPayeh = "";
            StudentReshte = "";
            StudentProfileAddress = "";
            StudentBimary = "";
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("/FormComponent;component/add_a_photo.png", UriKind.Relative);
            bitmapImage.EndInit();
            Profile_Img.Source = bitmapImage;
            ProfileImg_Border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#EFEFEF"));

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Edit)
            {
                Name_Txt_TextChanged(null, null);
                LastName_Txt_TextChanged(null, null);
                Payeh_CmBox_SelectionChanged(null, null);
                Reshteh_CmBox_SelectionChanged(null, null);
                NationalCode_Txt_TextChanged(null, null);
                StudentCode_Txt_TextChanged(null, null);
                BimariKhas_Txt_TextChanged(null, null);
                ToggleButton_Checked(null, null);
            }
        }
    }
}
