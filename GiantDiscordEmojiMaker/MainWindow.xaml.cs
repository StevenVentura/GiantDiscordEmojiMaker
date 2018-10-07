using System;
using System.Collections.Generic;
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

namespace GiantDiscordEmojiMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(Directory.GetCurrentDirectory());
            this.Loaded += onloadpls;
        }

        public void onloadpls(object o1, object o2)
        {
            makeimagefiles();
        }

        private static string CURRENT_EMOJI_BASE_NAME = "xRageMeme";

        public void makeimagefiles()
        {
            StebinEmojiUpload stebin = new StebinEmojiUpload();
            string filename = stebin.AskUserToPickFile();
            var tiler = new ImageTile(filename, 7, 7);
            tiler.GenerateTiles(CURRENT_EMOJI_BASE_NAME, stebin.StebBaseDirectory() + "\\" + "splitboye\\");

        }

        public void uploadtoserver()
        {
            //click on "upload emoji" button

            //enter the file in.


            /*
             * 
             * 
             * i can do this with
             * jjavascript
             * 
             * 
             * using 
             * my
             * 
             * 
             * 
             * deepfriedmemes thing
             * 
             * 
             * 
             * */


        }

        private void CopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            string allEmotes = "";

            for (int i = 0; i < 49; i++)
            {
                allEmotes += ":" + CURRENT_EMOJI_BASE_NAME + i + ":";
                if ((i+1)%7 == 0)
                    allEmotes += "\r\n";
            }

            Clipboard.SetText(allEmotes);
        }
    }
}
