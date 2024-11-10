using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convertir_a_Hex {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
          }

        public string convertirAHex(string texto) {

            string hexString = "";

            try { 
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            hexString = BitConverter.ToString(bytes);

            //System.Diagnostics.Debug.WriteLine(hexString);

            hexString = hexString.Replace("-", "");
               
            } catch (Exception ex) {
                MessageBox.Show("El formato es incorrecto");
            }
            return hexString;
        }

        static string convertirAString(String texto) {

                byte[] raw = new byte[texto.Length / 2];

            try {
                for (int i = 0; i < raw.Length; i++) {
                    raw[i] = Convert.ToByte(texto.Substring(i * 2, 2), 16);
                }
                
            } catch (Exception ex) {
                MessageBox.Show("El formato es incorrecto");
            }
            return Encoding.UTF8.GetString(raw);
        }

        private void btStringAHex_Click(object sender, EventArgs e) {

            if (!textBox1.Text.Equals(String.Empty)) {

                textBox2.Text = "";

                textBox2.Text = convertirAHex(textBox1.Text);

            }
        }

        private void btHexAString_Click(object sender, EventArgs e) {

            if (!textBox2.Text.Equals(String.Empty)) {

                textBox1.Text = "";

                textBox1.Text = convertirAString(textBox2.Text);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox2.Text);
        }
    }
}
