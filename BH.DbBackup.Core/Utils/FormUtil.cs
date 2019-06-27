using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class FormUtil
    {
        public static T ToModel<T>(IFormCollection form) where T : class, new()
        {
            T t = new T();
            foreach (var item in typeof(T).GetProperties())
            {
                item.SetValue(t, form[item.Name].ToString());
            }


            return t;
        }
    }
}
