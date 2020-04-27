using Surgit_NetworkManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surgit_NetworkManager
{
    public enum DeviceType
    {
        DesktopPC,
        Notebook,
        AllInOnePC,
        TabletComputer,

        Smartphone,
        Tablet,
        Organizer,
        GameConsole,
        VoIP,

        Printer,
        Scanner,
        Fax,
        MultiPrinter,
        Printer3D,
        VRHeadset,

        AccessPoint,
        Router,
        WirelessRouter,

        Server,
        VirtualMachine,
        NAS,
        Switch,
        UPS,

        IoTDevice,
        IPCamera,
        Intercom,

        IPTV,
        IPSetTopBox,
        IPRadio,
        IPSoundSystem,
        Projector,
        
        POSTerminal,
        HealthEquipment,
        SecuritySystem,

        DevelopmentDevice,
        PLC,

        UnknownDevice
    }

    public class NetDevice
    {
        public static ImageList GetImageList()
        {
            ImageList imgList = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };

            var values = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();
            foreach(DeviceType device in values)
            {

                imgList.Images.Add(device.ToString() + "_ON", (Icon)Resources.ResourceManager.GetObject($"{device}_ON"));
                imgList.Images.Add(device.ToString() + "_OFF", (Icon)Resources.ResourceManager.GetObject($"{device}_OFF"));
                imgList.Images.Add(device.ToString() + "_RAW", (Icon)Resources.ResourceManager.GetObject($"{device}_RAW"));
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
