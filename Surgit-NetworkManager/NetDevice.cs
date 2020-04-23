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
            string deviceIconBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Surgit\DeviceIcons");

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(64, 64);
            imgList.ColorDepth = ColorDepth.Depth32Bit;

            imgList.Images.Add(DeviceType.AccessPoint.ToString(), new Icon(Path.Combine(deviceIconBasePath, "AccessPoint.ico")));
            imgList.Images.Add(DeviceType.AllInOnePC.ToString(), new Icon(Path.Combine(deviceIconBasePath, "AllInOnePC.ico")));
            imgList.Images.Add(DeviceType.DesktopPC.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Desktop.ico")));
            imgList.Images.Add(DeviceType.DevelopmentDevice.ToString(), new Icon(Path.Combine(deviceIconBasePath, "DevelopmentDevice.ico")));
            imgList.Images.Add(DeviceType.Fax.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Fax.ico")));
            imgList.Images.Add(DeviceType.GameConsole.ToString(), new Icon(Path.Combine(deviceIconBasePath, "GameConsole.ico")));
            imgList.Images.Add(DeviceType.HealthEquipment.ToString(), new Icon(Path.Combine(deviceIconBasePath, "HealthEquipment.ico")));
            imgList.Images.Add(DeviceType.Intercom.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Intercom.ico")));
            imgList.Images.Add(DeviceType.IoTDevice.ToString(), new Icon(Path.Combine(deviceIconBasePath, "IoTDevice.ico")));
            imgList.Images.Add(DeviceType.IPCamera.ToString(), new Icon(Path.Combine(deviceIconBasePath, "IPCamera.ico")));
            imgList.Images.Add(DeviceType.IPRadio.ToString(), new Icon(Path.Combine(deviceIconBasePath, "IPRadio.ico")));
            imgList.Images.Add(DeviceType.IPSetTopBox.ToString(), new Icon(Path.Combine(deviceIconBasePath, "IPSetTopBox.ico")));
            imgList.Images.Add(DeviceType.IPSoundSystem.ToString(), new Icon(Path.Combine(deviceIconBasePath, "IPSoundSystem.ico")));
            imgList.Images.Add(DeviceType.IPTV.ToString(), new Icon(Path.Combine(deviceIconBasePath, "IPTV.ico")));
            imgList.Images.Add(DeviceType.MultiPrinter.ToString(), new Icon(Path.Combine(deviceIconBasePath, "MultiPrinter.ico")));
            imgList.Images.Add(DeviceType.NAS.ToString(), new Icon(Path.Combine(deviceIconBasePath, "NAS.ico")));
            imgList.Images.Add(DeviceType.Notebook.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Notebook.ico")));
            imgList.Images.Add(DeviceType.Organizer.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Organizer.ico")));
            imgList.Images.Add(DeviceType.PLC.ToString(), new Icon(Path.Combine(deviceIconBasePath, "PLC.ico")));
            imgList.Images.Add(DeviceType.POSTerminal.ToString(), new Icon(Path.Combine(deviceIconBasePath, "POSTerminal.ico")));
            imgList.Images.Add(DeviceType.Printer.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Printer.ico")));
            imgList.Images.Add(DeviceType.Printer3D.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Printer3D.ico")));
            imgList.Images.Add(DeviceType.Projector.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Projector.ico")));
            imgList.Images.Add(DeviceType.Router.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Router.ico")));
            imgList.Images.Add(DeviceType.Scanner.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Scanner.ico")));
            imgList.Images.Add(DeviceType.SecuritySystem.ToString(), new Icon(Path.Combine(deviceIconBasePath, "SecuritySystem.ico")));
            imgList.Images.Add(DeviceType.Server.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Server.ico")));
            imgList.Images.Add(DeviceType.Smartphone.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Smartphone.ico")));
            imgList.Images.Add(DeviceType.Switch.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Switch.ico")));
            imgList.Images.Add(DeviceType.Tablet.ToString(), new Icon(Path.Combine(deviceIconBasePath, "Tablet.ico")));
            imgList.Images.Add(DeviceType.TabletComputer.ToString(), new Icon(Path.Combine(deviceIconBasePath, "TabletComputer.ico")));
            imgList.Images.Add(DeviceType.UnknownDevice.ToString(), new Icon(Path.Combine(deviceIconBasePath, "UnknownDevice.ico")));
            imgList.Images.Add(DeviceType.UPS.ToString(), new Icon(Path.Combine(deviceIconBasePath, "UPS.ico")));
            imgList.Images.Add(DeviceType.VirtualMachine.ToString(), new Icon(Path.Combine(deviceIconBasePath, "VirtualMachine.ico")));
            imgList.Images.Add(DeviceType.VoIP.ToString(), new Icon(Path.Combine(deviceIconBasePath, "VoIP.ico")));
            imgList.Images.Add(DeviceType.VRHeadset.ToString(), new Icon(Path.Combine(deviceIconBasePath, "VRHeadset.ico")));
            imgList.Images.Add(DeviceType.WirelessRouter.ToString(), new Icon(Path.Combine(deviceIconBasePath, "WirelessRouter.ico")));

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
