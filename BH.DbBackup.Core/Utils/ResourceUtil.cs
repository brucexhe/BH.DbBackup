using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BH.DbBackup.Core
{
    public class ResourceUtil
    {
        static EmbeddedFileProvider fileProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
        public static String GetResource(string key)
        {
            var fi = fileProvider.GetFileInfo(key);
            byte[] bytes = new byte[fi.Length];
            using (var stream = fi.CreateReadStream())
            {
                stream.Read(bytes, 0, Convert.ToInt32(fi.Length));
            }
            var result = Encoding.UTF8.GetString(bytes);

            return result;
        }
    }
}
