using ImageLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Item>  _root = new ObservableCollection<Item>();
        public ObservableCollection<Item> Root
        {
            get
            {
                return _root;
            }
        }

        Item MyComputer = new Item();

        public MainWindow()
        {
            InitializeComponent();
            //LoadFolder(Root, "C:\\");

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Item drive = new Item(new FileInfo(d.RootDirectory.FullName));
                Root.Add(drive);
                LoadFolder(MyComputer.Children, d.RootDirectory.FullName);
            }

            DataContext = this;
                
            //treeView.DataContext = Root;
        }

        void LoadFolder(ObservableCollection<Item> parent, string folder)
        {
            try
            {
                foreach (string directory in Directory.EnumerateDirectories(folder))
                {
                    parent.Add(new Item(new FileInfo(directory)));
                }
            }
            catch { }
            try {

                foreach (string file in Directory.EnumerateFiles(folder))
                {
                    parent.Add(new Item(new FileInfo(file)));
                }
            }
            catch { }

        }


        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Item item = e.NewValue as Item;
            if (item.IsDirectory)
            {
                LoadFolder(item.Children, item.Info.FullName);
            }
            else
            {
                if (item.IsImage)
                {
                    ShowImage(item.Info);
                }
                else if (item.IsText)
                {
                    ShowText(item.Info);
                }
                else
                {
                    ShowPreviewNotAvailable();
                }
            }

        }

        private void ShowPreviewNotAvailable()
        {
            //throw new NotImplementedException();
        }

        private void ShowText(FileInfo info)
        {
            try
            {
                textBlock.Text = File.ReadAllText(info.FullName);
            }
            catch(Exception e)
            {
                textBlock.Text = e.Message;
            }
            
        }

   

        private void ShowImage(FileInfo info)
        {
            image.Source = new BitmapImage(new Uri(info.FullName));
            try
            {
                IImageInfo imageInfo = ImageUtils.GetImageInfo(info.FullName);

                textBlockImageInfo.Text = String.Format("Width {0}, Height {1}, Depth {2} ", imageInfo.GetWidth(), imageInfo.GetHeight(), imageInfo.GetDepth());
            }
            catch (Exception e)
            {
                textBlockImageInfo.Text = e.Message;
            }
            //throw new NotImplementedException();
        }

    }
}
