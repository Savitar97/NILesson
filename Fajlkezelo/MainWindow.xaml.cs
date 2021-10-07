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

namespace Fajlkezelo
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

        private void ReadButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var fileStream = File.OpenRead("encrypted.txt"))
                using (var encryptedStream = new EncryptorStream(fileStream, 0x55))
                using (var streamReader = new StreamReader(encryptedStream))
                {
                    var text = streamReader.ReadToEnd();
                    TextToEncrypt.Text = text;
                    
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No file to read");
            }

        }

        private void WriteButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var fileStream = File.OpenWrite("encrypted.txt"))
                using (var encryptedStream = new EncryptorStream(fileStream, 0x55))
                using (var streamWriter = new StreamWriter(encryptedStream))
                {
                    var text=TextToEncrypt.Text;
                    streamWriter.Write(text);
                    TextToEncrypt.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error during writing file:{ex}");
            }
        }
    }
}
