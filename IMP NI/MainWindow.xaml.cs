//DAS PROBLEM IST DASS DIE BILDER LERZEICHEN HABEN!!!!!
//Wenn ich verdopplen würde, hätte warscheinlich einfach nur langsamer durchläuft (bilder²)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace IMP_NI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public int ActivatedButton = 0;
        public int Tempo = 100;
        public string LocalPath;
        int a = 0;
        public MainWindow()
        {

            InitializeComponent();










            Bild.Stretch = Stretch.Uniform;
            TypeOfRendering.Content = "Rendering Type - NearestNeighbor";
            RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.NearestNeighbor);

            timer = new DispatcherTimer();
            timer.Start();
            timer.Interval = TimeSpan.FromSeconds(2.75);

            timer.Tick += TextAnimation;


        }

        public async void TextAnimation(object sender, EventArgs e)
        {
            TempoUI.Text = $"{Tempo}";
            DoubleAnimation FontSizeAnimation = new DoubleAnimation();
            FontSizeAnimation.From = 10;
            FontSizeAnimation.To = 20;
            FontSizeAnimation.Duration = new Duration(TimeSpan.FromSeconds(1.5));
            FontSizeAnimation.AutoReverse = true;

            Storyboard.SetTargetName(FontSizeAnimation, "TypicalMinecraftText");
            Storyboard.SetTargetProperty(FontSizeAnimation, new PropertyPath(TextBlock.FontSizeProperty));


            Storyboard sb = new Storyboard();
            sb.Children.Add(FontSizeAnimation);



            TextBlock TargetTextBlock = (TextBlock)FindName("TypicalMinecraftText");
            sb.Begin(TargetTextBlock);




        }

        public async void AddImages_Click(object sender, RoutedEventArgs e)
        {
                    string resourceNamePrefix = "IMP_NI.FirstResources."; // Anpassen: Namespace und Ressourcenordner


            //Das versuchte ich mit resoursen, damit die debug.exe datei die Bilder hätte.
            /*
            ActivatedButton++;
            if (ActivatedButton == 1)
            {
                for (int i = 1; i <= 35; i++)
                {

                    
                    string imageNamePrefix = "Pixel Erde-";

                    for (int j = 1; j <= 2; j++)
                    {
                        string localimagePath = $"{LocalPath}Pixel Erde-{i}.png";
                        string resoucesimageName = $"{imageNamePrefix}{i}.png";
                        string resourceName = $"{resourceNamePrefix}{resoucesimageName}";

                        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                        {
                            if (stream != null)
                            {
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.EndInit();

                                // Verwenden Sie das BitmapImage in Ihrem WPF-Code
                                // z.B. imageControl.Source = bitmap;
                                Bild.Source = bitmap;
                            }

                        }
                            BitmapImage bitmap2 = new BitmapImage();
                            bitmap2.UriSource = new Uri($"P:\\Programme\\Paint\\Krita\\Meine Bilder\\Pixel Erde\\PNG\\Pixel Erde-{i}.png", UriKind.Absolute);
                            Bild.Source = bitmap2;
                            await Task.Delay(Tempo);
                    }




                }



            }

           */



            //Standard
            ActivatedButton++;
            if (ActivatedButton == 1)
            {
                for (int i = 1; i <= 35; i++)
                {

                    LocalPath = $@"P:\Programme\Paint\Krita\Meine Bilder\Pixel Erde\PNG\Pixel Erde-{i}.png";
                    BitmapImage bitmap = new BitmapImage(new Uri(LocalPath));

                    if (i == 35)
                    {
                        i = 1;
                    }


                    Link.Text = LocalPath;

                    Bild.Source = bitmap;


                    await Task.Delay(Tempo);
                }
            }

        }
            private void Button_Click(object sender, RoutedEventArgs e)
            {

            }

            private void CheckBox_Click(object sender, RoutedEventArgs e)
            {

            }



            private void MySliderForAnti_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                switch (MySliderForAnti.Value)
                {

                    case 0: { RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.NearestNeighbor); TypeOfRendering.Content = " Rendering Type - NearestNeighbor"; } break;
                    case 1: { RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.Fant); TypeOfRendering.Content = "Rendering Type - Fant"; } break;
                    case 2: { RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.LowQuality); TypeOfRendering.Content = "Rendering Type - LowQuality"; } break;
                    case 3: { RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.HighQuality); TypeOfRendering.Content = "Rendering Type - HighQuality"; } break;
                    case 4: { RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.Linear); TypeOfRendering.Content = "Rendering Type - Linear"; } break;
                    case 5: { RenderOptions.SetBitmapScalingMode(Bild, BitmapScalingMode.Unspecified); TypeOfRendering.Content = "Rendering Type - Unspecified"; } break;

                }
            }

            private void FasterButton_Click(object sender, RoutedEventArgs e)
            {




                if (Tempo <= 10)
                {
                    if (Tempo == 1)
                    {
                        TempoUI.Text = "MaxSpeed - Shortest Delay reached!";
                    }

                    if (Tempo > 1)
                    {
                        Tempo -= 1;
                    }
                }
                else
                {
                    Tempo -= 10;
                    TempoUI.Text = $"{Tempo}";
                }
            }

            private void SlowerButton_Click(object sender, RoutedEventArgs e)
            {
                if (Tempo < 10)
                {
                    Tempo += 1;
                }
                else
                {
                    Tempo += 10;
                    TempoUI.Text = $"{Tempo}";
                }
            }
    }
}

