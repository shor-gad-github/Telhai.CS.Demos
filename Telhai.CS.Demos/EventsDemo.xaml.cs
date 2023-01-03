using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telhai.CS.Demos;


namespace Telhai.CS.Demos
{
    /// <summary>
    /// Interaction logic for EventsDemo.xaml
    /// </summary>
    public partial class EventsDemo : Window
    {
        public event EventHandler ColorChangedEvent;
        public EventsDemo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Get All Properties of Colors by thier Names an build ColorInfo 
            var color_query = from PropertyInfo property in typeof(Colors).GetProperties()
                              orderby property.Name
                              //orderby ((Color)property.GetValue(null, null)).ToString()
                              select new ColorInfo(property.Name, (System.Windows.Media.Color)property.GetValue(null, null));

            lstboxColors.ItemsSource = color_query;

        }
        public System.Windows.Media.Color SelectedColor {
            get; set; 
        }

        private void lstboxColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            //foreach (object o in lb.SelectedItems)
            //    MessageBox.Show((o as ColorInfo).ColorName +
            //        "\nHex Value " + (o as ColorInfo).HexValue +
            //        "\nRed " + (o as ColorInfo).Color.R +
            //        "\nGreen " + (o as ColorInfo).Color.G +
            //        "\nBlue " + (o as ColorInfo).Color.B +
            //        "\nAlpha " + (o as ColorInfo).Color.A);
            // change the background of the title in the first TextBox
            ColorInfo? colorInfo = lb.SelectedItem as ColorInfo;
            this.SelectedColor = System.Windows.Media.Color.FromRgb(colorInfo.Color.R, colorInfo.Color.G, colorInfo.Color.B);
            //Raise EVENT
            if (colorInfo != null)
            {
                this.ColorChangedEvent.Invoke(this, new EventArgs());
            }

           // txtblkTitle.Background = new SolidColorBrush(color);

            // display the RBG and A of the selected color
            // object ci = lb.SelectedItem;
         //   txtblkRGBNumbers.Text = colorInfo.ColorName +
          //  "Red:" + colorInfo.Color.R + " "+
           // "Green:" + colorInfo.Color.G + " "+
           // "Blue:" + colorInfo.Color.B + " "+
           // "Alpha:" + colorInfo.Color.A + " ";

        }
    }


    //Source Class For Binding
    public class ColorInfo
    {
        public string ColorName { get; set; }
        public System.Windows.Media.Color Color { get; set; }
        public SolidColorBrush SampleBrush
        {
            get { return new SolidColorBrush(Color); }
        }

        public string HexValue
        {
            get { return Color.ToString(); }
        }

        public ColorInfo(string color_name, System.Windows.Media.Color color)
        {
            ColorName = color_name;
            Color = color;
        }

    }






}
