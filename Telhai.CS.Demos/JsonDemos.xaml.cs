using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telhai.CS.Demos.Models;

namespace Telhai.CS.Demos
{
    /// <summary>
    /// Interaction logic for JsonDemos.xaml
    /// </summary>
    public partial class JsonDemos : Window
    {
        public JsonDemos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                SummaryField = "Hot",
                DatesAvailable = new List<DateTimeOffset>()
                    { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
                TemperatureRanges = new Dictionary<string, HighLowTemps>
                {
                    ["Cold"] = new HighLowTemps { High = 20, Low = -10 },
                    ["Hot"] = new HighLowTemps { High = 60, Low = 20 }
                },
                SummaryWords = new[] { "Cool", "Windy", "Humid" }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(weatherForecast, options);
            this.txtJson.Text = jsonString;

            File.WriteAllText("weather.json", jsonString);

        }

        private void btnDesirialize_Click(object sender, RoutedEventArgs e)
        {
            WeatherForecast? ObjectCreated =
            JsonSerializer.Deserialize<WeatherForecast>(this.txtJson.Text);
        }
    }
}
