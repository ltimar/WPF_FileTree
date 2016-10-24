using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FileExplorer
{
    public class Item
    {

        static string[] TEXT_EXTENSIONS = {".TXT",".HTM",".LOG"};
        FileInfo fileInfo;
        public FileInfo Info
        {
            get
            {
                return fileInfo;
            }
        }

        public bool IsImage
        {
            get
            {
                return ".PNG".Equals(fileInfo.Extension, StringComparison.InvariantCultureIgnoreCase) ||
                ".JPG".Equals(fileInfo.Extension, StringComparison.InvariantCultureIgnoreCase) ||
                ".GIF".Equals(fileInfo.Extension, StringComparison.InvariantCultureIgnoreCase) ||
                ".BMP".Equals(fileInfo.Extension, StringComparison.InvariantCultureIgnoreCase)
                ;
            }
        }

        public bool IsText
        {
            get
            {

                return TEXT_EXTENSIONS.Contains(fileInfo.Extension.ToUpperInvariant());


            }
        }

        public bool IsOther
        {
            get
            {
                return !IsText && !IsImage;

            }
        }

        public String FileName
        {
            get
            {
                return String.IsNullOrWhiteSpace(fileInfo.Name)?fileInfo.FullName:fileInfo.Name;
            }
        }

        public bool IsDirectory
        {
            get
            {
                return (fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
            }
        }
        public ImageSource Icon
        {
            get
            {
                return GetImageSource();
            }
        }

        private ImageSource GetImageSource()
        {
            string imageName = "Unknown.png";
            if (IsImage)
            {
                imageName = "Image.png";
            }
            else if (IsText)
            {
                imageName = "Text.png";
            }
            else if (IsDirectory)
            {
                imageName = "Directory.png";
            }
            return new ImageSourceConverter().ConvertFromString(
                        "pack://application:,,,/Images/"+ imageName) as ImageSource;
        }

        private ObservableCollection<Item> children = new ObservableCollection<Item>();
        public ObservableCollection<Item> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }
        public Item() { }
        public Item(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }
    }
}
