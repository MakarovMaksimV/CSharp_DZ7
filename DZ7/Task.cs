using System;
using System.Reflection;
using System.Text;

namespace DZ7
{
    
	public class Task
	{
        [Custom("CustomField")]
        public int I { get; set; }

        public string? S { get; set; }
        public decimal D { get; set; }
        public char[]? C { get; set; }

        public Task()
        {

        }

        private Task(int i)
        {
            I = i;
        }

        public Task(int i, string s, decimal d, char[] c) : this(i)
        {
            S = s;
            D = d;
            C = c;
        }

        public Task? Run3(int i, string s, decimal d, char[] c)
        {
            var tc = typeof(Task);
            return Activator.CreateInstance(tc, new object[] { i, s, d, c }) as Task;
        }


        public static string ObjectToString(object o)
        {
            Type type = o.GetType();
            StringBuilder sb = new StringBuilder();
            sb.Append(type.AssemblyQualifiedName + ":"
                + type.Name + "|");

            var prop = type.GetProperties();
            foreach (var p in prop)
            {
                var attrib = p.GetCustomAttributes(false);
                if(attrib.Length > 0)
                {
                    foreach (var a in attrib)
                    {
                        if (a.GetType() == typeof(CustomAttribute))
                        {
                            sb.Append(p.GetCustomAttribute<CustomAttribute>().CustomName
                                + ":" + p.GetValue(o) + "|");
                        }
                    }
                }
                else
                {
                    sb.Append(p.Name + ":");
                    if (p.PropertyType == typeof(char[]))
                    {
                        sb.Append(new string(p.GetValue(o) as char[]) + "|");
                    }
                    else
                    {
                        sb.Append(p.GetValue(o) + "|");
                    }
                }
            }
            return sb.ToString();
        }


        public static object StringToObject(string s)
        {
            string[] arr = s.Split("|");
            string[] arr1 = arr[0].Split(":");

            object? ob = Activator.CreateInstance(null, arr[0].Split(',')[0]);

            Task task1 = new Task();


            if (arr1.Length > 1 && ob != null)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    string[] nameAndValue = arr[i].Split(":");

                    var p = task1.GetType().GetProperty(nameAndValue[0]);

                    if (p == null)
                    {
                        continue;
                    }

                    if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(task1, int.Parse(nameAndValue[1]));
                    }
                    if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(task1, int.Parse(nameAndValue[1]));
                    }
                    else if (p.PropertyType == typeof(string))
                    {
                        p.SetValue(task1, nameAndValue[1]);
                    }
                    else if (p.PropertyType == typeof(decimal))
                    {
                        p.SetValue(task1, decimal.Parse(nameAndValue[1]));
                    }
                    else if (p.PropertyType == typeof(char[]))
                    {
                        p.SetValue(task1, nameAndValue[1].ToCharArray());
                    }
                }
            }
            return task1;
        }
    }
}

