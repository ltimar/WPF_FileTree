using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary
{

    public interface IImageConverter
    {
        void Convert(string source, string destination, ImageFormat format);
    }


}
