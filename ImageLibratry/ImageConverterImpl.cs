using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary
{
    class ImageConverterImpl : IImageConverter
    {
        public void Convert(string source, string destination, ImageFormat format)
        {
            System.Drawing.Image image1 = System.Drawing.Image.FromFile(source);
            image1.Save(destination, format);            
        }


    }
}

