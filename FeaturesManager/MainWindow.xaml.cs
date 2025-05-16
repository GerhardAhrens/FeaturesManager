namespace FMDemo
{
    using System.Windows;
    using System.Windows.Controls;

    using FMDemo.Features;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            WeakEventManager<Window, RoutedEventArgs>.AddHandler(this, "Loaded", this.OnLoaded);

            using (ApplicationFeatures sm = new ApplicationFeatures())
            {
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            bool featureFoundA = ApplicationFeatures.HasFeatures(FeaturesTyp.Features1);
            if (featureFoundA == true)
            {
                FeaturesResult result = ApplicationFeatures.Get(FeaturesTyp.Features1);
                if (result != null)
                {
                    this.BtnFunktionA.Visibility = Visibility.Visible;
                    this.BtnFunktionA.Content = result.Description;
                }
            }
            else
            {
                this.BtnFunktionA.Visibility = Visibility.Collapsed;
            }

                bool featureFoundB = ApplicationFeatures.HasFeatures(FeaturesTyp.Features2);
            if (featureFoundB == true)
            {
                FeaturesResult result = ApplicationFeatures.Get(FeaturesTyp.Features2);
                if (result != null)
                {
                    this.BtnFunktionB.Visibility = Visibility.Visible;
                    this.BtnFunktionB.Content = result.Description;
                }
            }
            else
            {
                this.BtnFunktionB.Visibility = Visibility.Collapsed;
            }
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}