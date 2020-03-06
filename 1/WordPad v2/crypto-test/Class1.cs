using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using crypto_test;

namespace Plugin {
    public class Class1 {
        public string HashPass { get; set; }
        public const string Name = "Crypto";
        private RichTextBox _textBox;
        private Form _form;
        private int _pos, _pos2, _pos3;
        private MenuStrip _menu;

        private ElGamal elGamal;

        public void run(ref Form form, ref RichTextBox textBox) {
            _textBox = textBox;
            _form = form;

            _menu = (MenuStrip)form.Controls[1];
            ToolStripMenuItem item = new ToolStripMenuItem("Crypto");
            ToolStripMenuItem cipherItem = new ToolStripMenuItem("AES cipher");
            ToolStripMenuItem asyncCipher = new ToolStripMenuItem("El Gamal cipher");

            StdGenerator stdGen = new StdGenerator(ref _textBox);
            YarrowGenerator yGen = new YarrowGenerator(ref _textBox);
            GeffeGenerator geffeGen = new GeffeGenerator(ref _textBox);
            SquareGenerator squareGen = new SquareGenerator(ref _textBox);
            Tester tester = new Tester(ref _textBox);
            MD5Hash md5Hash = new MD5Hash(ref _textBox, ref _form);
            
            item.DropDownItems.Add("Стандартный генератор");
            item.DropDownItems.Add("Квадратный конгруэнтный генератор");
            item.DropDownItems.Add("Генератор Геффа");
            item.DropDownItems.Add("Генератор Yarrow-160");
            item.DropDownItems.Add("Тестирование последовательности");
            item.DropDownItems.Add("MD5 хеш");

            item.DropDownItems[0].Click += stdGen.GenerateSequence;
            item.DropDownItems[1].Click += squareGen.GenerateSequence;
            item.DropDownItems[2].Click += geffeGen.GenerateSequence;
            item.DropDownItems[3].Click += yGen.GenerateSequence;
            item.DropDownItems[4].Click += tester.Test;
            item.DropDownItems[5].Click += md5Hash.WindowHashing;
            
            cipherItem.DropDownItems.Add("Зашифровать AES-128");
            cipherItem.DropDownItems.Add("Расшифровать AES-128");
            cipherItem.DropDownItems.Add("Загрузить хеш пароля из файла");
            cipherItem.DropDownItems.Add("Ввести пароль");

            cipherItem.DropDownItems[0].Click += WindowCiper;
            cipherItem.DropDownItems[1].Click += WindowDecrypt;
            cipherItem.DropDownItems[2].Click += LoadHashFromFile;
            cipherItem.DropDownItems[3].Click += InputPass;

            asyncCipher.DropDownItems.Add("Зашифровать");
            asyncCipher.DropDownItems.Add("Расшифровать");

            asyncCipher.DropDownItems[0].Click += EncryptElGamal;
            asyncCipher.DropDownItems[1].Click += DecryptElGamal;

            _menu.Items.Add(item);
            _menu.Items.Add(cipherItem);
            _menu.Items.Add(asyncCipher);
            _pos = _menu.Items.Count - 3;
            _pos2 = _menu.Items.Count - 2;
            _pos3 = _menu.Items.Count - 1;
        }

        public void stop() {
            _menu.Items.RemoveAt(_pos);
            _menu.Items.RemoveAt(_pos2 - 1);
            _menu.Items.RemoveAt(_pos3 - 2);
        }

        private void EncryptElGamal(object sender, EventArgs e) {
            elGamal = new ElGamal(ref _textBox, ref _form);
            string curExt = WordPad.Helpers.ReadHelper.GetExtention(_form.Text);
            bool isText = false;
            if (WordPad.Form1.TxtExts.Any(str => str == curExt)) {
                isText = true;
            }
            _textBox.Text = elGamal.Encrypt(_textBox.Text, isText);
        }

        private void DecryptElGamal(object sender, EventArgs e) {
            _textBox.Text = elGamal.Decrypt(_textBox.Text);
        }
         private void LoadHashFromFile(object sender, EventArgs e) {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.FileName = "";
            openDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK) {
                HashPass = File.ReadAllText(openDialog.FileName);
            }
        }

        private void InputPass(object sender, EventArgs e) {
            cipher_plugin.Utils.InputForm inputForm = new cipher_plugin.Utils.InputForm(this);
            inputForm.Show();
        }

        public void WindowCiper(object sender, EventArgs args) {
            if (HashPass == null) {
                MessageBox.Show("Не был введён пароль");
                return;
            }
            AES aes = new AES(ref _textBox, ref _form);
            _textBox.Text = aes.Encrypt(_textBox.Text, HashPass, true);
        }

        public void WindowDecrypt(object sender, EventArgs args) {
            if (HashPass == null) {
                MessageBox.Show("Не был введён пароль");
                return;
            }
            AES aes = new AES(ref _textBox, ref _form);
            _textBox.Text = aes.Decrypt(_textBox.Text, HashPass);
        }
    }
}
