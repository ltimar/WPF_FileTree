using System.Drawing;
using System.Drawing.Imaging;

namespace ImageLibrary
{
    public interface IImageInfo
    {
        int GetHeight();
        int GetWidth();
        SizeF GetSize();
        PixelFormat GetDepth();
        byte[] GetUncompressedData();
        
    }
}