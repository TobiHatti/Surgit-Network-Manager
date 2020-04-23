using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Surgit_NetworkManager
{
    public enum DeviceType
    {
        Desktop,
        Notebook,
        Smartphone,
        Tablet,
        Server,
        GameConsole,
        VirtualMachine,
        VoIPDevice,
        Router,
        AccessPoint,
        Printer,
        Scanner,
        Fax,
        MultiPrinter,
        IPCamera,
        StorageArray,
        NAS,
        ManagedSwitch,
        POSTerminal,
        UPS,
        SecuritySystem,
        LightControl,
        IPTV,
        IPSetTopBox,
        IPRadio,
        IoTDevice,
        DevelopmentDevice,
        PLC,
        UnknownDevice
    }

    public class NetDevice
    {
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
