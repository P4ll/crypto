using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp.Helper {
    public static class MD5Transform {
        public static string Transform(string str, int state) {
            var gparts = new List<string>(str.Trim('[', ']').Split(' '));
            var parts = Array.FindAll(gparts.ToArray(), x => x != "");

            return $"Trans({state}, ref {Char.ToLower(parts[0][0])}, {Char.ToLower(parts[0][1])}," +
                $" {Char.ToLower(parts[0][2])}, {Char.ToLower(parts[0][3])}, x[{parts[1]}], {parts[2]}, {parts[3]});";
        }

        public static string FullTransform(string str) {
            var lines = str.Split('\n');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; ++i) {
                for (int j = 0; j < 4; ++j) {
                    var ch = lines[i * 4 + j].Split(']');
                    for (int k = 0; k < 4; ++k) {
                        sb.Append(Transform(ch[k], i + 1));
                    }
                    sb.Append('\n');
                }
            }
            return sb.ToString();
        }
    }
}
