using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BH.DbBackup.Core
{
    public class ZipUtil
    {
        public static void Zip(string fullFilename)
        {
            var fileName = fullFilename.Split("\\").Last().Split(".").First();
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = fileName;
                zip.AddFile(fullFilename, "");
                zip.Save(fullFilename + ".zip");
            }

        }

        public static void UnZip(string fullFilename)
        {
            var fileName = fullFilename.Split("\\").Last().Split(".").First();
            var path = new System.IO.FileInfo(fullFilename).DirectoryName;
            using (ZipFile zip = ZipFile.Read(fullFilename))
            {
                zip.ExtractAll(path, ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
}
