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

using SFML.Graphics;

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

        List<LoadedImage> images = new List<LoadedImage>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.Multiselect = true;
            dialog.Title = "Image Browser";
            dialog.DefaultExt = ".png";
            dialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";

            Nullable<bool> result = dialog.ShowDialog();

            AddToImageList(dialog, images);           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
                
                Image loadedImage = new Image(file);
                string fileName = file.Substring(file.LastIndexOf('\\'));
                fileName = fileName.Remove(0, 1);

                LoadedImage imager;
                images.Add(imager = new LoadedImage());
                imager.assetName = fileName;
                imager.image = ImageToColorArray(loadedImage);

                textBox.Text += fileName + " ";
                
            }
        }

        private SFML.Graphics.Color[,] ImageToColorArray(Image image)
        {
            SFML.Graphics.Color[,] tempArray = new SFML.Graphics.Color[image.Size.X, image.Size.Y];

            for (int x = 0; x < image.Size.X; x++)
            {
                for (int y = 0; y < image.Size.Y; y++)
                {
                    tempArray[x, y] = image.GetPixel(Convert.ToUInt32(x), Convert.ToUInt32(y));
                }
            }

            return tempArray;
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
