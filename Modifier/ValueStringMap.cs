using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modifier
{
    [XmlType]
    public class ValueStringMap
    {
        [XmlArray]
        public List<string> Map { get; set; }

        public static string Separator = "=>";

        public Dictionary<string,string> GetMap()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            if (Map != null)
            {
                foreach (var str in Map)
                {
                    var line = str.Split(Separator.ToCharArray());
                    map.Add(line[0],line[2]);
                }
            }
            return map;
        }
        public void FillMap(Dictionary<string,string> objects)
        {
            if (objects != null)
            {
                Map = new List<string>();
                foreach (var line in objects)
                {
                    Map.Add(line.Key + Separator + line.Value);
                }
            }           
        }

        public List<string> GetValueList()
        {
            List<string> list = new List<string>();
            foreach (var unit in GetMap())
            {
                list.Add(unit.Value);
            }
            return list;
        }
        public int GetKey(string value)
        {
            int key = -1;
            foreach (var unit in GetMap())
            {
                if (unit.Value == value)
                {
                    key = int.Parse(unit.Key);
                    break;
                }
            }
            return key;
        }
        public string GetValue(long key)
        {
            string value = "";
            foreach (var unit in GetMap())
            {
                if (unit.Key == key.ToString())
                {
                    value = unit.Value;
                    break;
                }
            }
            return value;
        }
        public override string ToString()
        {
            string res = "";
            if (Map != null && Map.Count != 0)
            {
                foreach(var str in Map)
                {
                    if (res != "")
                    {
                        res += "\r\n";
                    }
                    res += str;
                }
            }
            return res;
        }
    }
}
