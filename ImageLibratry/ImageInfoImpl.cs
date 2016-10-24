using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary
{
    class ImageInfoImpl : IImageInfo
    {
        Image img;
        public ImageInfoImpl(string fileName)
        {
            img = Image.FromFile(fileName);

        }

        public PixelFormat GetDepth()
        {
            return img.PixelFormat;
        }

        public int GetHeight()
        {
           return img.Height;
        }

        public SizeF GetSize()
        {
            return img.PhysicalDimension;
        }

        public byte[] GetUncompressedData()
        {
            Byte[] data;

            using (MemoryStream ms = new MemoryStream())
            {

                img.Save(ms, img.RawFormat);

                data = new byte[ms.Length];

                data = ms.ToArray();
            }
            return data;
        }

       
        public int GetWidth()
        {
            return img.Width;
        }
    }
}
