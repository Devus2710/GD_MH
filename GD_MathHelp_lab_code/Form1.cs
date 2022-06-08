using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_MathHelp_lab_code
{
    public partial class Form1 : Form
    {
        private MathHelper Solver = new MathHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(maskedTextBox1.Text, out int value) || value < 1)
            {
                MessageBox.Show($"Входные данные не являются корректными: {maskedTextBox1.Text}", "ERROR!");
                return;
            }

            textBox1.Text = await StartWork(value);
            SetTextToBox($" = {textBox1.Text}\n\n");
            MessageBox.Show($"Подсчет окончен\nРезультат: {textBox1.Text}");
        }

        private void SetTextToBox(string text) => richTextBox1.Invoke(new Action(() => richTextBox1.Text += text));

        private async Task<string> StartWork(int value)
        {
            //Solver = new Class1();
            return await Task.Run(() =>
            {
                string resultString = "";
                double result = 0.0;

                if (radioButton1.Checked)
                {
                    result = Solver.Func1(value, new SetTextDelegate(SetTextToBox));
                    resultString = result.ToString();
                }
                else if (radioButton2.Checked)
                {
                    resultString = Solver.Func2(value, new SetTextDelegate(SetTextToBox)).ToString();
                }
                else if (radioButton3.Checked)
                {
                    resultString = Solver.Func3(value, new SetTextDelegate(SetTextToBox)).ToString();
                }

                return resultString;
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Недостаточно данных для сохранения!");
                return;
            }

            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult != DialogResult.OK && dialogResult != DialogResult.Yes) return;

            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.Write(richTextBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно записать данные в файл. {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}