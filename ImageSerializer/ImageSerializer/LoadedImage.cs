using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace ImageSerializer
{
    [Serializable()]
    public class LoadedImage
    {
        public Image image { get; set; }

        public string assetName { get; set; }


        public LoadedImage(Image image, string fileName)
        {
            this.image = image;
            this.assetName = fileName;
        }
    }
}
