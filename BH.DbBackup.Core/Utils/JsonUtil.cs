using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core.Utils
{
    public class JsonUtil
    {
        public static string ToJsonString<T>(T t) where T : class, new()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            bool first = true;
            foreach (var item in typeof(T).GetProperties())
            {
                if (first)
                {
                    json.Append("\", ");
                    first = false;
                }
                
                json.Append("\"");
                json.Append(item.Name);
                json.Append("\"");
                json.Append(": ");
                json.Append("\"");
                json.Append(item.GetValue(t));
                json.Append(Environment.NewLine);
            }
            json.Append("}");

            return json.ToString();
        }
    }
}
