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

#region COPYRIGHT NOTICE (Surgit Network Manager - Copyright(C) 2020  Tobias Hattinger)

/* Surgit Network Manager
 * Copyright(C) 2020  Tobias Hattinger
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<https://www.gnu.org/licenses/>.
 */
#endregion

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
                imgList.Images.Add(device.ToString() + "_GroupON", (Icon)Resources.ResourceManager.GetObject($"{device}_GroupON"));
                imgList.Images.Add(device.ToString() + "_GroupOFF", (Icon)Resources.ResourceManager.GetObject($"{device}_GroupOFF"));
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
