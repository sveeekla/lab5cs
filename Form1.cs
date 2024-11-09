//13.Дан текстовый файл. Перенести в новый файл те строки исходного файла,
//которые начинаются  и заканчиваются одной  и той же буквой (вне 
//зависимости от регистра). 

//Михайловская

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace lab5
{
    public partial class Form1 : Form
    {
        private string fileName = "";
        private StreamReader f_In; //для чтения из файла
        private StreamWriter f_Out; //для записи в файл
        public Form1()
        {
            InitializeComponent();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)//Открывает диалог выбора файла, считывает файл и отображает его содержимое в textBox1
        {
            if (fileName == "")
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    f_In = new StreamReader(openFileDialog1.FileName);
                    fileName = openFileDialog1.FileName;
                    textBox1.Text = f_In.ReadToEnd();
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //Сохраняет содержимое textBox1
        {
            if (fileName == "") // Если имя файла пустое, то вызываем saveAsToolStripMenuItem_Click
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    f_Out = new StreamWriter(saveFileDialog1.FileName);
                    f_Out.WriteLine(textBox1.Text);
                    f_Out.Close();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) //для сохранения файла под другим именем
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                f_Out = new StreamWriter(saveFileDialog.FileName);
                f_Out.WriteLine(textBox1.Text);
                f_Out.Close();
            }
        }
        private void taskToolStripMenuItem_Click(object sender, EventArgs e) //Решение задачи
        {
            textBox2.Clear();
            string[] lines = textBox1.Lines; //Получает все строки из textBox1 и сохраняет их в массив lines

            foreach (string line in lines)
            {
                if (char.ToLower(line[0]) == char.ToLower(line[line.Length - 1]))
                    textBox2.AppendText(line + Environment.NewLine);//Добавляет выбранную строчку в textBox2 с новой строкой
            }
        }
        private void условиеЗадачиToolStripMenuItem_Click(object sender, EventArgs e) //Отображает сообщение с условием задачи
        {
            MessageBox.Show("Дан текстовый файл. Перенести в новый файл те строки исходного файла,\n" +
                            "которые начинаются  и заканчиваются одной  и той же буквой (вне зависимости от регистра).", "Условие задачи");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //Закрывает форму
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // Новая функция для "Сохранить как..." для результата
        private void saveAsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                f_Out = new StreamWriter(saveFileDialog.FileName);
                f_Out.WriteLine(textBox2.Text); // Записываем текст из textBox2
                f_Out.Close();
            }
        }

        
    }
}

