using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modifier
{
    struct Module
    {
        public int dwSize;
        public int th32ModuleID;
        public int th32ProcessID;
        public int GlblcntUsage;
        public int ProccntUsage;
        public int modBaseAddr;
        public int modBaseSize;
        public int hModule;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szExePath;

    }
    public static class APIHelper
    {
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        const int PROCESS_VM_READ = 0X0010;
        const int PROCESS_VM_WRITE = 0x0020;

        [DllImport("KERNEL32.DLL")]
        private extern static int CreateToolhelp32Snapshot(int flags,int pid);

        [DllImport("KERNEL32.DLL")]
        private extern static int CloseHandle(int handle);

        [DllImport("KERNEL32.DLL")]
        private extern static int Module32First(int snapshotHandle, ref Module modulehandle);

        [DllImport("KERNEL32.DLL")]
        private extern static int Module32Next(int snapshotHandle, ref Module modulehandle);

        [DllImport("KERNEL32.DLL")]
        private extern static int OpenProcess(int AcessID,bool inhertHandle,int pid);

        [DllImport("NTDLL.DLL")]
        private extern static int ZwWriteVirtualMemory(int processHandle,long baseAddr, byte[] buffer,int size,out int numberOfBytesWritten);

        [DllImport("ntdll.dll")]
        private extern static int ZwReadVirtualMemory(int processHandle, long baseAddr, byte[] buffer, long size,out long numberOfBytesWritten);


        private static int GetProcessHandle(int pid)
        {
            int handle = OpenProcess(PROCESS_ALL_ACCESS, false, pid);

            if (handle == 0)
            {
                throw new Exception("进程(pid:" + pid + ")不存在！");
            }

            return handle;
        }

        public static ProcessModule GetProcessModule(string processName, string moduleName)
        {
            Process[] p = Process.GetProcessesByName(processName);
            
            if (p.Length <= 0)
            {
                throw new Exception(processName + "进程不存在！");
            }

            Process currentP = p[0];

            foreach (ProcessModule pm in currentP.Modules)
            {
                if(pm.ModuleName == moduleName)
                {
                    return pm;
                }
            }
            throw new Exception(moduleName + "模块不存在！");
        }
        public static int GetProcessID(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);

            if (p.Length <= 0)
            {
                
                throw new Exception(processName + "进程不存在！");
            }
            return p[0].Id;
        }

        public static int GetModuleAddr(int pid,string moduleName)
        {
            int snapShotHandle = CreateToolhelp32Snapshot(8, pid);

            Module module = new Module();
            int moduleAddr = 0;

            List<Module> modules = new List<Module>();

            if (snapShotHandle != 0)
            {
                module.dwSize = 1024;

                int handle = Module32First(snapShotHandle,ref module);
                while (handle != 0)
                {
                    modules.Add(module);
                    handle = Module32Next(snapShotHandle, ref module);                   
                }

                foreach (Module _module in modules)
                {
                    if (_module.szModule.ToLower() == moduleName.ToLower())
                    {
                        moduleAddr = _module.modBaseAddr;
                        break;
                    }
                }                           
            }
            CloseHandle(snapShotHandle);
            return moduleAddr;
        }//废弃

        public static long GetModuleAddr(string processName,string moduleName)
        {
            Process[] p = Process.GetProcessesByName(processName);

            if (p.Length <= 0)
            {
                throw new Exception(processName + "进程不存在！");
            }
            return GetProcessModule(processName, moduleName).BaseAddress.ToInt64();
        }

        public static bool WriteMemoryByInt64(int pid, long addr, double value)
        {
            return WriteMemoryByBytes(pid, addr, System.BitConverter.GetBytes(value));
        }
        public static Int64 ReadMemoryByInt64(int pid, long addr)
        {
            byte[] res = ReadMemoryByBytes(pid, addr, sizeof(Int64));
            return BitConverter.ToInt64(res, 0);
        }

        public static bool WriteMemoryByInt32(int pid,long addr,int value)
        {
            return WriteMemoryByBytes(pid, addr, System.BitConverter.GetBytes(value));
        }
        public static int ReadMemoryByInt32(int pid, long addr)
        {
            byte[] res = ReadMemoryByBytes(pid, addr, sizeof(int));
            return BitConverter.ToInt32(res, 0);
        }

        public static bool WriteMemoryByBytes(int pid,long addr,byte[] value)
        {
            int _out_size = 0;

            if (ZwWriteVirtualMemory(GetProcessHandle(pid), addr, value, value.Length, out _out_size) != 0)
            {
                throw new Exception("写内存错误,进程(pid:" + pid + "),0x" + addr.ToString("x8") + "位置不能为write！");
            }
            return true;
        }
        public static byte[] ReadMemoryByBytes(int pid, long addr,int size)
        {
            byte[] buffer = new byte[size];

            long _out_size = 0;

            if (ZwReadVirtualMemory(GetProcessHandle(pid), addr, buffer, size, out _out_size) != 0)
            {
                 throw new Exception("读内存错误,进程(pid:" + pid + "),0x" + addr.ToString("x8") + "位置不能为read！");
            }

            return buffer;
        }

        public static bool WriteMemoryByFloat(int pid, long addr,float value)
        {
            return WriteMemoryByBytes(pid, addr, System.BitConverter.GetBytes(value));
        }
        public static float ReadMemoryByFloat(int pid, long addr)
        {
            byte[] res = ReadMemoryByBytes(pid, addr, sizeof(float));
            return System.BitConverter.ToSingle(res,0);
        }

        public static bool WriteMemoryByByte(int pid, long addr, byte value)
        {
            return WriteMemoryByBytes(pid, addr, new byte[] { value });
        }
        public static byte ReadMemoryByByte(int pid ,long addr)
        {
            byte[] res = ReadMemoryByBytes(pid, addr, 1);
            return res[0];
        }

        public static bool WriteMemoryByInt16(int pid, long addr, short value)
        {
            return WriteMemoryByBytes(pid, addr, BitConverter.GetBytes(value));
        }
        public static short ReadMemoryByInt16(int pid, long addr)
        {
            byte[] res = ReadMemoryByBytes(pid, addr, sizeof(short));
            return BitConverter.ToInt16(res,0);
        }

        public static string ReadMemoryByString(int pid, long addr, int size = 20)//utf-16
        {
            string res = "";
            List<byte> bytes = new List<byte>();
            List<byte> bytes_temp = new List<byte>();

            bytes_temp.AddRange(ReadMemoryByBytes(pid, addr, size * 2));

            for (int i = 0; i<bytes_temp.Count ;i+=2)
            {
                byte temp_1 = bytes_temp[i];
                byte temp_2 = bytes_temp[i + 1];

                if (temp_1 == 0 && temp_2 == 0)
                {
                    break;
                }
                bytes.Add(temp_1);
                bytes.Add(temp_2);
            }
            res = System.Text.Encoding.Unicode.GetString(bytes.ToArray());
            return res;
        }

        public static bool WriteMemoryByBinary(int pid, long addr, int startPlace, int size, long value)
        {
            long originalNum = ReadMemoryByInt64(pid, addr);
            long marks = 0;//设置掩码
            for (int i = 0; i < size; i++)
            {
                marks = marks << 1;
                marks++;
            }
            marks <<= startPlace;//置掩码起始位
            marks = ~marks;//掩码取反

            originalNum &= marks; //写位置零

            long res = originalNum | (value << startPlace);

            WriteMemoryByInt64(pid, addr, res);

            return false;
        }
        public static long ReadMemoryByBinary(int pid, long addr, int startPlace, int size)
        {
            long originalNum = ReadMemoryByInt64(pid, addr);
            long marks = 0;//设置掩码
            for (int i = 0; i < size; i++)
            {
                marks = marks << 1;
                marks++;
            }
            marks <<= startPlace;//置掩码起始位

            long res = (originalNum & marks) >> startPlace; //与掩码进行与运算，并使数字归位
            return res;
               
        }

    }
}
