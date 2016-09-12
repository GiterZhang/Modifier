using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modifier
{
    [XmlType]
    public class MemoryAddress
    {
        [XmlAttribute]
        public bool IsPtr { get; set; }
        [XmlElement]
        public bool IsContainModuleAddr { get; set; }
        [XmlElement]
        public long Address { get; set; }
        [XmlElement]
        public long RealAddress { get; set; }       
        [XmlArray]
        public List<int> Offsets { get; set; }

        public string GetAddrString(string moduleName = "module")
        {
            string addrString = "";

            if (IsContainModuleAddr)
                addrString = string.Format("[{0}+{1}]", moduleName, Address.ToString("x2"));
            else
                addrString = string.Format("[{0}]", Address.ToString("x2"));

            if (IsPtr)
            {
                foreach (var offset in Offsets)
                {
                    addrString = string.Format("[{0}+{1}]",addrString, offset.ToString("x2"));
                }
                if (Offsets.Count == 0)
                {
                    addrString = string.Format("[{0}]", addrString);
                }
            }
            return addrString;
        }
    }
    public static class MemoryAddressEx
    {
        public static long GetAddress(this MemoryAddress instance)
        {
            long addr = instance.Address;
            try
            {
                if (instance.IsContainModuleAddr)
                {
                    addr += ModifierConfigEx.ProcessInfo.ModuleAddress;
                }

                if (instance.IsPtr)
                {
                    foreach (var offset in instance.Offsets)
                    {
                        addr = APIHelper.ReadMemoryByInt64(ModifierConfigEx.ProcessInfo.Pid, addr);
                        addr += offset;
                    }

                    if (instance.Offsets.Count == 0)
                        addr = APIHelper.ReadMemoryByInt64(ModifierConfigEx.ProcessInfo.Pid, addr);
                }
                instance.RealAddress = addr;
            }
            catch (Exception ex)
            {
                string errorAddr = instance.GetAddrString(ModifierConfigEx.ProcessInfo.ModuleAddress.ToString());
                throw new Exception("读取地址:" +　errorAddr + "错误");

            }
            
            return addr;         
        }
    }
}
