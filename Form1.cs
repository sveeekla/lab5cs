//13.��� ��������� ����. ��������� � ����� ���� �� ������ ��������� �����,
//������� ����������  � ������������� �����  � ��� �� ������ (��� 
//����������� �� ��������). 

//������������

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
        private StreamReader f_In; //��� ������ �� �����
        private StreamWriter f_Out; //��� ������ � ����
        public Form1()
        {
            InitializeComponent();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)//��������� ������ ������ �����, ��������� ���� � ���������� ��� ���������� � textBox1
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
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //��������� ���������� textBox1
        {
            if (fileName == "") // ���� ��� ����� ������, �� �������� saveAsToolStripMenuItem_Click
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) //��� ���������� ����� ��� ������ ������
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                f_Out = new StreamWriter(saveFileDialog.FileName);
                f_Out.WriteLine(textBox1.Text);
                f_Out.Close();
            }
        }
        private void taskToolStripMenuItem_Click(object sender, EventArgs e) //������� ������
        {
            textBox2.Clear();
            string[] lines = textBox1.Lines; //�������� ��� ������ �� textBox1 � ��������� �� � ������ lines

            foreach (string line in lines)
            {
                if (char.ToLower(line[0]) == char.ToLower(line[line.Length - 1]))
                    textBox2.AppendText(line + Environment.NewLine);//��������� ��������� ������� � textBox2 � ����� �������
            }
        }
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e) //���������� ��������� � �������� ������
        {
            MessageBox.Show("��� ��������� ����. ��������� � ����� ���� �� ������ ��������� �����,\n" +
                            "������� ����������  � ������������� �����  � ��� �� ������ (��� ����������� �� ��������).", "������� ������");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //��������� �����
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // ����� ������� ��� "��������� ���..." ��� ����������
        private void saveAsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                f_Out = new StreamWriter(saveFileDialog.FileName);
                f_Out.WriteLine(textBox2.Text); // ���������� ����� �� textBox2
                f_Out.Close();
            }
        }

        
    }
}

