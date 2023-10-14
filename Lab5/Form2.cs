using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form2 : Form
    {
        Graphics g;
        string axiom;
        double angle;
        string start;
        Dictionary<char, string> rules;
        int iterations;

        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

            rules = new Dictionary<char, string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы txt|*.txt";

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] file = File.ReadAllLines(OPF.FileName);
                    string[] parameters = file[0].Split(' ');

                    axiom = parameters[0];
                    angle = Convert.ToDouble(parameters[1]);
                    start = parameters[2];

                    rules.Clear();
                    string[] rule;
                    for (int i = 1; i < file.Length; ++i)
                    {
                        rule = file[i].Split('=');
                        rules[Convert.ToChar(rule[0])] = rule[1];
                    }
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Can't open file",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Fractus(string path)
        {

        }

        string AllPath()
        {
            string prev = axiom;
            string next = axiom;
            int iter = 0;
            while (iter < iterations)
            {
                prev = next;
                next = "";
                for (int i = 0; i < prev.Length; ++i)
                {
                    if (rules.ContainsKey(prev[i]))
                        next += rules[prev[i]];
                    else
                        next += prev[i];
                }
                ++iter;
            }
            return next;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            iterations = Convert.ToInt32(numericUpDown1.Value);
            if (axiom != null)
            {
                string path = AllPath();

                Fractus(path);
            }
        }
    }
}
