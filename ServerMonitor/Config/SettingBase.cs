﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace ServerMonitor.Config
{
    public class SettingBase
    {

        protected virtual int IndentLength { get { return 0; } }




        private PropertyInfo[] _props { get; set; }


        private static readonly string[] _falseCandidate = new string[]
        {
            "", "0", "-", "false", "fals", "no", "not", "none", "non", "empty", "null", "否", "不", "無", "dis", "disable", "disabled"
        };



        public void Load(TextSeeker seeker)
        {
            Console.WriteLine(this.GetType().Name);

            string line = "";
            while ((line = seeker.ReadLine()) != null)
            {
                if (line.Contains(":"))
                {
                    var indent = Regex.Match(line, @"^\s*").Value;
                    if (indent.Length == IndentLength)
                    {
                        string nam = line.Substring(0, line.IndexOf(":")).Trim();
                        string val = line.Substring(line.IndexOf(":") + 1).Trim();

                        _props ??= this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                        var prop = _props.FirstOrDefault(x => x.Name.Equals(nam, StringComparison.OrdinalIgnoreCase));
                        var type = prop.PropertyType;
                        if (type == typeof(string))
                        {
                            prop.SetValue(this, val);
                        }
                        else if (type == typeof(int?))
                        {
                            prop.SetValue(this, int.TryParse(val, out int num) ? num : null);
                        }
                        else if (type == typeof(bool?))
                        {
                            bool? bol = null;
                            if (!string.IsNullOrEmpty(val))
                            {
                                bol = !_falseCandidate.Any(x => x.Equals(val.ToLower()));
                            }
                            prop.SetValue(this, bol);
                        }
                        else if (type == typeof(string[]))
                        {
                            prop.SetValue(this, val.Split(',').Select(x => x.Trim()).ToArray());
                        }
                        else if (type == typeof(DateTime?))
                        {
                            if (DateTime.TryParse(val, out DateTime dt))
                            {
                                prop.SetValue(this, dt);
                            }
                        }
                        else if (type.IsSubclassOf(typeof(SettingBase)))
                        {
                            var subParam = Activator.CreateInstance(type) as SettingBase;
                            subParam.Load(seeker);
                            prop.SetValue(this, subParam);
                        }
                    }
                    else
                    {
                        seeker.Position--;
                        break;
                    }
                }
            }
        }




    }
}
