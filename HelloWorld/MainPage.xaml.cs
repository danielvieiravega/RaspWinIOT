using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Gpio;
using Windows.Devices.Enumeration;
using Windows.Devices.Bluetooth.Rfcomm;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public GpioController GpioController { get; set; }

        private DeviceInformationCollection deviceCollection;
        private DeviceInformation selectedDevice;
        private RfcommDeviceService deviceService;

        public string deviceName = "RNBT-76B7";

        public MainPage()
        {
            this.InitializeComponent();
            initGPIO();
            showRadial(); 

        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            const string message = "Hello Daniel!";
            const string message1 = "Hello World!";
            if (HelloMessage.Text == message)
            {
                HelloMessage.Text = message1;
            }
            else
            {
                HelloMessage.Text = message;
            }
            textBlock.Text = $"Pin Count: {GpioController.PinCount.ToString()}";
        }

        private void initGPIO()
        {
            GpioController = GpioController.GetDefault();
            if (GpioController == null)
            {
                textBlock.Text = "There is no GPIO controller on this device.";
            }
        }

        public void showRadial()
        {
            //timer.Interval = TimeSpan.FromSeconds(2); 
            timer.Start();
            int i = 0;

            timer.Tick += (object sender, object e) =>
            {

                if (i == 360)
                    i = 0;
                else
                {
                    myGrapg.Value = i;
                    i++;
                }
            };
        }
    }
}
