using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary
{
    public class ImageUtils
    {

        public static IImageConverter CreateImageConverter()
        {
            return new ImageConverterImpl();
        }

        public static IImageInfo GetImageInfo(string fileName)
        {
            return new ImageInfoImpl(fileName);
        }
    }
}
