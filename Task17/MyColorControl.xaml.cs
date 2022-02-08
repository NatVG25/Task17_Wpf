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

namespace Task17
{
    /// <summary>
    /// Логика взаимодействия для MyColorControl.xaml
    /// </summary>
    public partial class MyColorControl : UserControl
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color",
            typeof(Color), typeof(MyColorControl), 
            new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

        public static readonly DependencyProperty RedProperty = DependencyProperty.Register("Red",
            typeof(byte), typeof(MyColorControl),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        
        public static readonly DependencyProperty GreenProperty = DependencyProperty.Register("Green",
            typeof(byte), typeof(MyColorControl),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        
        public static readonly DependencyProperty BlueProperty = DependencyProperty.Register("Blue",
            typeof(byte), typeof(MyColorControl),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e) //метод возвращающий значение свойства Color в зависимости от значений RGB
        {
            MyColorControl myColorControl = (MyColorControl)sender;
            Color color = myColorControl.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            myColorControl.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender,
                            DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            MyColorControl myColorControl = (MyColorControl)sender;
            myColorControl.Red = newColor.R;
            myColorControl.Green = newColor.G;
            myColorControl.Blue = newColor.B;
        }

        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
            "ColorChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>), 
            typeof(MyColorControl));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }


        public MyColorControl()
        {
            InitializeComponent();
        }
    }
}
