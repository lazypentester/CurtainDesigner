using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    public class PathCombiner
    {
        private static string current_directory = Directory.GetCurrentDirectory();

        public static string combine(string fullpath)
        {
            string[] path_arr = fullpath.Split(new string[] { current_directory }, StringSplitOptions.None);
            return path_arr[1];
        }

        public static string join_combine(string path)
        {
            string p = string.Join("", new string[] { current_directory, path });
            return p;
        }
    }
}
