using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace GiantDiscordEmojiMaker
{

    /*
     * https://www.stefangordon.com/simple-image-tiling-in-c/
     * 
     * var tiler = new ImageTile("image.png", 8, 8);
     * tiler.GenerateTiles("outputdirectory");
     * */
        
        
    public class ImageTile
    {
        //private BitmapImage ImageFromFile(string _FilePath)
        //{
        //    System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
        //    myImage.Source = new BitmapImage(new Uri(_FilePath));
        //}
        private System.Drawing.Image image;
        private System.Drawing.Size size;

        public ImageTile(string inputFile, int xSize, int ySize)
        {
            if (!File.Exists(inputFile)) throw new FileNotFoundException();

            image = System.Drawing.Image.FromFile(inputFile);
            size = new System.Drawing.Size(xSize, ySize);
        }

        public void GenerateTiles(string emojiName, string outputPath)
        {
            int xMax = (int)(image.Width);
            int yMax = (int)(image.Height);
            int tileWidth = (int)(xMax / size.Width);
            int tileHeight = (int)(yMax / size.Height);

            if (!Directory.Exists(outputPath)) { Directory.CreateDirectory(outputPath); }
            int count = -1;
            for (int y = 0; y < size.Height; y++) 
            {
                for (int x = 0; x < size.Width; x++)
                {
                    count++;
                    string outputFileName = Path.Combine(outputPath, emojiName + count + ".JPG");

                    Rectangle tileBounds = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                    Bitmap target = new Bitmap(tileWidth, tileHeight);

                    using (Graphics graphics = Graphics.FromImage(target))
                    {
                        graphics.DrawImage(
                            image,
                            new Rectangle(0, 0, tileWidth, tileHeight),
                            tileBounds,
                            GraphicsUnit.Pixel);
                    }

                    target.Save(outputFileName, ImageFormat.Jpeg);
                }
            }
        }
    }
    /*
     * Keep in mind you can upload up to 50 emoji per server, and that those 
     * emoji will only work in the server they're uploaded in. For optimal emoji
     * resolution, you can upload them in sizes up to 128x128 pixels, but keep 
     * in mind that they'll be resized to 32x32.
     * */


    /// <summary>
    /// max width is like
    /// 32*50
    /// and 
    /// height is 
    /// 32*50
    /// 
    /// so
    /// 
    /// 1600x1600
    /// </summary>
    public class StebinEmojiUpload
    {
        public StebinEmojiUpload()
        {

        }
        public string StebBaseDirectory()
        {
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\"));
        }

        string PickedFile = null;
        public string AskUserToPickFile()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            //dialog.DefaultExt = "ini";
            //dialog.Filter = "ini file (*ini)|*.ini";


            dialog.InitialDirectory = StebBaseDirectory();
            Nullable<bool> result = dialog.ShowDialog();
            string picked = null;
            if (result.HasValue && result.Value)
            {
                picked = dialog.FileName;
               
            }
            PickedFile = picked;
            return picked;

        }

        

        public void CutUpImage(string _Filepath, string _OutputDirectory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(_OutputDirectory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }


            //https://stackoverflow.com/questions/13625891/cut-an-image-into-9-pieces-c-sharp
            var imgarray = new System.Drawing.Image[9];
            var img = System.Drawing.Image.FromFile(_Filepath);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var index = i * 3 + j;
                    imgarray[index] = new Bitmap(104, 104);
                    var graphics = Graphics.FromImage(imgarray[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, 104, 104), new Rectangle(i * 104, j * 104, 104, 104), GraphicsUnit.Pixel);

                    imgarray[index].Save(_OutputDirectory + "pls" + i + "-" + j + ".jpg");

                    graphics.Dispose();
                }
            }


        }









    }
}
