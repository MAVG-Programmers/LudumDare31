using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace ImageSerializer
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            List<LoadedImage> images = new List<LoadedImage>();

            dialog.Multiselect = true;
            dialog.Title = "Image Browser";
            dialog.DefaultExt = ".png";
            dialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";

            Nullable<bool> result = dialog.ShowDialog();

            AddToImageList(dialog, images);

            byte[] array = ListToByteArray(images);

            BinaryWriter bw = new BinaryWriter(File.Open("XmlImage.bin", FileMode.OpenOrCreate));

            bw.Write(array);
            bw.Flush();
            bw.Close();
        }

        private void AddToImageList(Microsoft.Win32.OpenFileDialog dialog, List<LoadedImage> images)
        {
            foreach (string file in dialog.FileNames)
            {
                try
                {
                    Image loadedImage = Image.FromFile(file);
                    string fileName = file.Substring(file.LastIndexOf('\\'));
                    fileName = fileName.Remove(0, 1);
                    images.Add(new LoadedImage(loadedImage, fileName));
                    textBox.Text += fileName + " ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot load the image: " + file.Substring(file.LastIndexOf('\\'))
                    + ". You may not have permission to read the file, or " +
                    "it may be corrupt.\n\nReported error: " + ex.Message);
                }
            }
        }

        private byte[] ListToByteArray(List<LoadedImage> obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
    }
}
