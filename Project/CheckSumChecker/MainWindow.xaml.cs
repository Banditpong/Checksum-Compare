using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.IO;

namespace CheckSumChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main_Window_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                    byte[] stream = File.ReadAllBytes(files[0]);

                    SHA1TxtBx.Text = BitConverter.ToString(SHA1.Create().ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
                    MD5TxtBx.Text = BitConverter.ToString(MD5.Create().ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
                    SHA256TxtBx.Text = BitConverter.ToString(SHA256.Create().ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
                    SHA512TxtBx.Text = BitConverter.ToString(SHA512.Create().ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string compStr = compTxtBox.Text.ToLowerInvariant();

            if (compStr == SHA1TxtBx.Text)
            {
                compTxtBox.Background = Brushes.Green;
            }
            else if (compStr == MD5TxtBx.Text)
            {
                compTxtBox.Background = Brushes.Green;
            }
            else if (compStr == SHA256TxtBx.Text)
            {
                compTxtBox.Background = Brushes.Green;
            }
            else if (compStr == SHA512TxtBx.Text)
            {
                compTxtBox.Background = Brushes.Green;
            }
            else
            {
                compTxtBox.Background = Brushes.Red;
            }
        }

        private void CompTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            compTxtBox.Background = Brushes.White;
        }
    }
}
