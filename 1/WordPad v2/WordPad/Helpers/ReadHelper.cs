using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPad.Helpers {
    public static class ReadHelper {
        public static string GetExtention(string fullFileName) {
            string[] partsOfName = fullFileName.Split('\\').Last().Split('.');
            if (partsOfName.Length == 0)
                return "";
            else
                return partsOfName.Last();
        }

        public static string GetTextFromFile(string fullFileName, Encoding encoding, string[] textExts) {
            string curExt = GetExtention(fullFileName);
            string text = "";
            if (textExts.Any(ext => ext == curExt)) {
                using (StreamReader sr = new StreamReader(fullFileName, encoding)) {
                    text = sr.ReadToEnd();
                }
            }
            else {
                byte[] bytes = File.ReadAllBytes(fullFileName);
                StringBuilder sb = new StringBuilder();
                foreach (var curByte in bytes) {
                    sb.Append(curByte);
                }
                text = sb.ToString();
            }
            
            return text;
        }
    }
}
