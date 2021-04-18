using System;
using System.Collections.Generic;
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

namespace FreeTVChannels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();
            player.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(new LibVLCSharp.Shared.Media(new LibVLCSharp.Shared.LibVLC(), new Uri("http://sc.id-tv.kz/Kinokomediya_hd_34_35.m3u8")));
            player.MediaPlayer.Play();
        }
    }
}
