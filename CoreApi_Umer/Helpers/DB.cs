using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Helpers
{
    public static class DB
    {
        public static string AddObjectsToJson<T>(string json, T obj)
        {
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            list.Add(obj);
            return JsonConvert.SerializeObject(list);
        }
    }
}
