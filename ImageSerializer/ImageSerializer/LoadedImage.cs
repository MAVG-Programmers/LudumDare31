using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace ImageSerializer
{
    [Serializable()]
    public class LoadedImage
    {
        public Color[,] image { get; set; }

        public string assetName { get; set; }

        public LoadedImage()
        {

        }
    }
}
