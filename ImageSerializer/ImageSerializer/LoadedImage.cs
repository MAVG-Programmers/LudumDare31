using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace ImageSerializer
{
    [Serializable()]
    public class LoadedImage
    {
        public Image image { get; set; }

        public string assetName { get; set; }
    }
}
