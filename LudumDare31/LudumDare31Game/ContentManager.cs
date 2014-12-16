using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.IO;

using SFML.Graphics;

namespace LudumDare31Game
{
    class ContentManager
    {
        private List<LoadedImage> loadedImages = new List<LoadedImage>();
        private Dictionary<string, System.Drawing.Color[,]> images = new Dictionary<string, System.Drawing.Color[,]>();
        
        private BinaryFormatter bf;
        
        private FileStream fs;
        
        public void Load()
        {
            bf = new BinaryFormatter();
            fs = new FileStream("XmlImage.bin", FileMode.Open);
            loadedImages = (List<LoadedImage>)bf.Deserialize(fs);
            
            foreach(LoadedImage i in loadedImages)
            {
                images.Add(i.assetName, ImageToColor(i.image));
            }
        }
        
        private System.Drawing.Color[,] ImageToColor(System.Drawing.Image image)
        {
            Bitmap bmp = new Bitmap(image);
            
            System.Drawing.Color[,] tempColorArray = new System.Drawing.Color[bmp.Width, bmp.Height];
            
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    tempColorArray[x, y] = bmp.GetPixel(x, y);
                }
            }
            
            return tempColorArray;
        }

        

        private SFML.Graphics.Image ColorToImage(System.Drawing.Color[,] colorArray)
        {
            SFML.Graphics.Image temp;

            foreach(var i in images)
            {
                for (int x = 0; x < GetWidt(i.Key); x++)
                {
                    for (int y = 0; y < GetHeight(i.Key); y++)
                    {
                        temp.SetPixel(Convert.ToUInt32(x), Convert.ToUInt32(y), colorArray[x, y]);
                    }
                }
            }

            return temp;
        }

        private int GetWidt(string name)
        {
            int temp = 0;
            foreach(LoadedImage i in loadedImages)
            {
                if(i.assetName == name)
                {
                    temp = i.image.Width;
                }
            }

            return temp;
        }

        private int GetHeight(string name)
        {
            int temp = 0;
            foreach (LoadedImage i in loadedImages)
            {
                if (i.assetName == name)
                {
                    temp = i.image.Height;
                }
            }

            return temp;
        }
    }
}
