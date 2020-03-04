using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using crypto_test;

namespace Plugin {
    public class Class1 {
        public const string Name = "Cipher";
        private RichTextBox _textBox;
        private Form _form;
        private int _pos;
        private MenuStrip _menu;
        private string _hashPass;

        public void run(ref Form form, ref RichTextBox textBox) {
            _textBox = textBox;
            _form = form;

            _menu = (MenuStrip)form.Controls[1];
            ToolStripMenuItem item = new ToolStripMenuItem("Cipher");

            item.DropDownItems.Add("Зашифровать AES-128");
            item.DropDownItems.Add("Расшифровать AES-128");
            item.DropDownItems.Add("Загрузить хеш пароля из файла");
            item.DropDownItems.Add("Ввести пароль");

            AES aes = new AES(ref textBox, ref form, ref _hashPass);

            item.DropDownItems[0].Click += aes.WindowCiper;
            item.DropDownItems[1].Click += aes.WindowDecrypt;
            item.DropDownItems[2].Click += LoadHashFromFile;
            item.DropDownItems[3].Click += InputPass;

            _menu.Items.Add(item);
            _pos = _menu.Items.Count - 1;
        }

        public void stop() {
            _menu.Items.RemoveAt(_pos);
        }

        private void LoadHashFromFile(object sender, EventArgs e) {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.FileName = "";
            openDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK) {
                // load file
            }
        }

        private void InputPass(object sender, EventArgs e) {

            // open new form
            // input text
            // saveAs dialog
        }
    }
}
