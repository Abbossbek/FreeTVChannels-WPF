using FreeTVChannels.Controls;
using FreeTVChannels.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
        public ObservableCollection<Channel> channels { get; }
       = new ObservableCollection<Channel>(); 
        public MainWindow()
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://iptv-org.github.io/iptv/channels.json");
                channels = JsonConvert.DeserializeObject<ObservableCollection<Channel>>(json);
            }
                wpChannels.ItemsSource = channels;
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            player.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(new LibVLCSharp.Shared.Media(new LibVLCSharp.Shared.LibVLC(), new Uri(((Channel)((ChannelCard)sender).DataContext).Url)));
            player.MediaPlayer.Play();
        }
    }
}
