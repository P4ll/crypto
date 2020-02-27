using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPad.Helpers {
    public static class SaveHelper {
        public static void SaveTextToFile(string text, string fullFileName, string[] textExts) {
            string curExt = ReadHelper.GetExtention(fullFileName);
            if (textExts.Any(ext => ext == curExt)) {
                using (StreamWriter sw = new StreamWriter(fullFileName)) {
                    sw.Write(text);
                }
            }
            else {
                List<byte> bytes = new List<byte>();
                foreach (var ch in text) {
                    bytes.Add((byte)ch);
                }
                File.WriteAllBytes(fullFileName, bytes.ToArray());
            }
        }
    }
}
