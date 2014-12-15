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
        private List<LoadedImage> images = new List<LoadedImage>();

        private BinaryFormatter bf;

        private FileStream fs;

        public void Load()
        {
            bf = new BinaryFormatter();
            fs = new FileStream("XmlImage.bin", FileMode.Open);
            images = (List<LoadedImage>)bf.Deserialize(fs);

            foreach(LoadedImage i in images)
            {
                

                
            }
        }

        
    }
}
