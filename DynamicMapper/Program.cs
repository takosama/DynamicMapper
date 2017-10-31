using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMapper
{
    class Mapper
    {
        public static T Map<T>(dynamic obj) where T : new()
        {
            var rtn = new T();

            foreach (var n in obj)
            {
                var type = n.Key;
                var val = n.Value;
                try
                {
                    rtn.GetType().GetProperty(type).SetValue(rtn, val);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return rtn;
        }
    }
}