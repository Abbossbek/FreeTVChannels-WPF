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
        string json = "";
        public MainWindow()
        {
            InitializeComponent();
            LibVLCSharp.Shared.Core.Initialize();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://iptv-org.github.io/iptv/channels.json");
                channels = JsonConvert.DeserializeObject<ObservableCollection<Channel>>(json);
            }
            wpChannels.ItemsSource = channels.Where(x => x.Countries.Length > 0 && x.Countries[0].Name.Contains("german", StringComparison.OrdinalIgnoreCase));
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Channel channel = (Channel)((ChannelCard)sender).DataContext;
            if (player.MediaPlayer == null)
            {
                player.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(new LibVLCSharp.Shared.Media(new LibVLCSharp.Shared.LibVLC(), new Uri(channel.Url)));
                player.MediaPlayer.Play();
            }
            else
            {
                player.MediaPlayer.Stop();
                player.MediaPlayer.Play(new LibVLCSharp.Shared.Media(new LibVLCSharp.Shared.LibVLC(), new Uri(channel.Url)));
            }
            tbName.Text = channel.Name;
            tbUrl.Text = channel.Url;
            tbLogo.Text = channel.Logo;
            tbCountry.Text = channel.Countries?[0]?.Name;
            tbCategory.Text = channel.Category;
            json = "";
            json += "{";
            json += $"\"Id\":,";
            json += $"\"Name\":\"{channel.Name}\",";
            json += $"\"Link\":\"{channel.Url}\",";
            json += $"\"IconSource\":\"{channel.Logo}\",";
            json += $"\"Tags\":[";
            json += channel.Category != null ? $"\"{channel.Category?.ToLower()}\"" : "";
            json += channel.Countries != null ? $",\"{channel.Countries?[0]?.Name?.ToLower()}\"" : "";
            json += "]}";
        }

        private void btnCopyJson_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(json);
        }
    }
}
