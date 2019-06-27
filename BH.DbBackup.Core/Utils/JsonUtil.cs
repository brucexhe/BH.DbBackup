using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class JsonUtil
    {
        public static string ToJsonString(Object t)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            bool first = true;
            foreach (var item in t.GetType().GetProperties())
            {
                if (!first)
                {
                    json.Append(", ");
                }
                else
                { 
                    first = false;
                }

                json.Append(Environment.NewLine);
                json.Append("\t");
                json.Append("\"");
                json.Append(item.Name);
                json.Append("\"");
                json.Append(": ");
                json.Append("\"");
                json.Append(item.GetValue(t));
                json.Append("\"");
            }
            json.Append(Environment.NewLine);
            json.Append("}");

            return json.ToString();
        }
    }
}
