using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surgit_NetworkManager
{
    public enum DeviceType
    {
        AccessPoint = 0,
        AllInOnePC = 1,
        DesktopPC = 2,
        DevelopmentDevice = 3,
        Fax = 4,
        GameConsole = 5,
        HealthEquipment = 6,
        Intercom = 7,
        IoTDevice = 8,
        IPCamera = 9,
        IPRadio = 10,
        IPSetTopBox = 11,
        IPSoundSystem = 12,
        IPTV = 13,
        MultiPrinter = 14,
        NAS = 15,
        Notebook = 16,
        Organizer = 17,
        PLC = 18,
        POSTerminal = 19,
        Printer = 20,
        Printer3D = 21,
        Projector = 22,
        Router = 23,
        Scanner = 24,
        SecuritySystem = 25,
        Server = 26,
        Smartphone = 27,
        Switch = 28,
        Tablet = 29,
        TabletComputer = 30,
        UnknownDevice = 31,
        UPS = 32,
        VirtualMachine = 33,
        VoIP = 34,
        VRHeadset = 35,
        WirelessRouter = 36
    }

    public class NetDevice
    {
        public static ImageList GetImageList()
        {
            string deviceIconBasePathON = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\DeviceIconsON");
            string deviceIconBasePathOFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\DeviceIconsOFF");
            string deviceIconBasePathRAW = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\DeviceIconsRAW");

            ImageList imgList = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };

            var values = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();
            foreach(DeviceType device in values)
            {
                imgList.Images.Add(device.ToString() + "_ON", new Icon(Path.Combine(deviceIconBasePathON, $"{device}.ico")));
                imgList.Images.Add(device.ToString() + "_OFF", new Icon(Path.Combine(deviceIconBasePathOFF, $"{device}.ico")));
                imgList.Images.Add(device.ToString() + "_RAW", new Icon(Path.Combine(deviceIconBasePathRAW, $"{device}.ico")));
            }

            return imgList;
        }


        public string Name { get; set; } = null;
        public string Description { get; set; } = null;
        public string Note { get; set; } = null;
        public string Hostname { get; set; } = null;
        public string IPv4 { get; set; } = null;
        public string IPv6 { get; set; } = null;
        public string MAC { get; set; } = null;
        public DeviceType DeviceType { get; set; } = DeviceType.UnknownDevice;
    }
}
