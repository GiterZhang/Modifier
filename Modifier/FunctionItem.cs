﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modifier
{
    [XmlType]
    public class FunctionItem
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement]
        public string ValueType { get; set; }
        [XmlElement]
        public bool ReadOnly { get; set; }
        [XmlElement]
        public double MaxValue { get; set; }
        [XmlElement]
        public double MinValue { get; set; }
        [XmlElement]
        public int Size { get; set; }
        [XmlElement]
        public string FormStyle { get; set; }

        [XmlElement]
        public MemoryAddress Address { get; set; }

        //只有非浮点型和控件样式为combox才具备这个属性
        [XmlElement]
        public ValueStringMap ValueStringMap { get;set; }
    }
    public static class FunctionItemEx
    {
        //public string LastErrorInfo { get; set; }
        private static Dictionary<int, object> value_temp = new Dictionary<int, object>();

        public static Type GetValueType(this FunctionItem instance)
        {
            try
            {
                return Type.GetType(instance.ValueType);
            }
            catch { }

            return null;
        }

        public static object Read(this FunctionItem instance, bool isReload = false)
        {
            if (value_temp.ContainsKey(instance.GetHashCode()) != true)
            {
                value_temp.Add(instance.GetHashCode(), null);
            }

            if (!isReload)
            {
                if (value_temp[instance.GetHashCode()] != null)
                {
                    return value_temp[instance.GetHashCode()];
                }
                
            }
            //读内存
            try
            {
                int pid = ModifierConfigEx.ProcessInfo.Pid;
                long address = instance.Address.GetAddress();

                Type valueType = instance.GetValueType();

                switch (valueType.Name)
                {
                    case "Int32":
                        value_temp[instance.GetHashCode()] = APIHelper.ReadMemoryByInt32(pid, address);
                        break;

                    case "Int16":
                        value_temp[instance.GetHashCode()] = APIHelper.ReadMemoryByInt16(pid, address);
                        break;

                    case "Byte":
                        value_temp[instance.GetHashCode()] = APIHelper.ReadMemoryByByte(pid, address);
                        break;

                    case "Double":
                        value_temp[instance.GetHashCode()] = (double)APIHelper.ReadMemoryByInt64(pid, address);
                        break;

                    case "Single":
                        value_temp[instance.GetHashCode()] = APIHelper.ReadMemoryByFloat(pid, address);
                        break;

                    case "String":
                        value_temp[instance.GetHashCode()] = APIHelper.ReadMemoryByString(pid, address, instance.Size);
                        break;

                    case "Byte[]":
                        value_temp[instance.GetHashCode()] = APIHelper.ReadMemoryByBytes(pid, address, instance.Size);
                        break;

                    default:
                        break;
                }             
            }
            catch (Exception ex)
            {
                value_temp[instance.GetHashCode()] = -1;
                throw ex;
            }

            return value_temp[instance.GetHashCode()];
        }
        public static void Write(this FunctionItem instance, string value)
        {
            //读取成功之后改写这个value_temp
            //value_temp = value;
            //写内存
            if (instance.ReadOnly != true)
            {
                try
                {
                    int pid = ModifierConfigEx.ProcessInfo.Pid;
                    long address = instance.Address.GetAddress();

                    Type valueType = instance.GetValueType();

                    //判断大小

                    if(double.Parse(value) > double.MaxValue && double.Parse(value) < double.MinValue )
                    {
                        throw new Exception("值应该大于" + instance.MinValue + ",且小于" + instance.MaxValue);
                    }

                    switch (valueType.Name)
                    {
                        case "Int32":
                            object obj = Int32.Parse(value);

                            APIHelper.WriteMemoryByInt32(pid, address, (Int32)obj);
                            value_temp[instance.GetHashCode()] = obj;

                            break;

                        case "Int16":
                            obj = Int16.Parse(value);

                            APIHelper.WriteMemoryByInt16(pid, address, (Int16)obj);
                            value_temp[instance.GetHashCode()] = obj;
                            break;

                        case "Byte":
                            obj = Byte.Parse(value);

                            APIHelper.WriteMemoryByByte(pid, address, (byte)obj);
                            value_temp[instance.GetHashCode()] = obj;
                            break;

                        case "Double":
                            obj = Double.Parse(value);

                            APIHelper.WriteMemoryByInt64(pid, address, (double)obj);
                            value_temp[instance.GetHashCode()] = obj;

                            break;

                        case "Single":
                            obj = Single.Parse(value);

                            APIHelper.WriteMemoryByFloat(pid, address, Single.Parse(value));
                            value_temp[instance.GetHashCode()] = obj;

                            break;

                        case "String":
                            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(value);

                            APIHelper.WriteMemoryByBytes(pid, address, bytes);
                            value_temp[instance.GetHashCode()] = bytes;

                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                             
            }
            
        }        
    }
}
