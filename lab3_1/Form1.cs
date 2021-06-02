using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        DateTimeFormat dtFormat = DateTimeFormat.ShowTime;
        ToolStripMenuItem currentCheckedItem;
        public Form1()
        {
            InitializeComponent();
            Text = "Пример строки состояния";
            CenterToScreen();
            BackColor = Color.CadetBlue;
            currentCheckedItem = toolStripMenuItemTime;
            currentCheckedItem.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox2.SelectedIndex = 0;
            toolStripComboBox3.SelectedIndex = 0;
            toolStripComboBox4.SelectedIndex = 0;
        }

        public enum DateTimeFormat
        {
            ShowTime,
            ShowDate
        }

        private void Calculate_Function(object sender, EventArgs e)
        {
            double X, Y, Z, a, b;
            a = Convert.ToDouble(toolStripComboBox1.SelectedItem);
            b = Convert.ToDouble(toolStripComboBox2.SelectedItem);
            try
            {
                X = Convert.ToDouble(toolStripTextBoxX.Text);
                Y = Convert.ToDouble(toolStripTextBoxY.Text);
                if (toolStripMenuItem6.Checked)
                {
                    Z = ((X + Y) / Math.Abs(Y - X));
                    toolStripTextBoxZ.Text = Convert.ToString(Z);
                }
                else
                {
                    Z = Convert.ToDouble(toolStripTextBoxZ.Text);
                }
                Text = Convert.ToString(((a * X / (b - Y)) + ((b * Y + Math.Sin(Z)) / (a * X))));
            }
            catch
            {
                MessageBox.Show("Необходимо ввести число", "Ошибка в задании параметров");
            }
            toolStripComboBox3.SelectedIndex = toolStripComboBox1.SelectedIndex;
            toolStripComboBox4.SelectedIndex = toolStripComboBox2.SelectedIndex;
            toolStripTextBox1.Text = toolStripTextBoxX.Text;
            toolStripTextBox2.Text = toolStripTextBoxY.Text;
            toolStripTextBox3.Text = toolStripTextBoxZ.Text;
        }
        private void Context_Calculate(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = toolStripComboBox3.SelectedIndex;
            toolStripComboBox2.SelectedIndex = toolStripComboBox4.SelectedIndex;
            toolStripTextBoxX.Text = toolStripTextBox1.Text;
            toolStripTextBoxY.Text = toolStripTextBox2.Text;
            toolStripTextBoxZ.Text = toolStripTextBox3.Text;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor_Location_Label.Text = string.Format("Координаты курсора равны ({0}, {1})", e.X, e.Y);
            if (toolStripMenuItem7.Checked)
            {
                toolStripTextBoxX.Enabled = false;
                toolStripTextBoxY.Enabled = false;
                toolStripTextBox1.Enabled = false;
                toolStripTextBox2.Enabled = false;
                toolStripTextBoxX.Text = Convert.ToString(e.X);
                toolStripTextBoxY.Text = Convert.ToString(e.Y);
            }
            else
            {
                toolStripTextBoxX.Enabled = true;
                toolStripTextBoxY.Enabled = true;
                toolStripTextBox1.Enabled = true;
                toolStripTextBox2.Enabled = true;
            }
        }

        private void toolStripMenuItem6_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripMenuItem6.Checked)
            {
                toolStripTextBoxZ.Enabled = false;
                toolStripTextBox3.Enabled = false;
            }
            else
            {
                toolStripTextBoxZ.Enabled = true;
                toolStripTextBox3.Enabled = true;
            }
        }

        private void timerDateTimeUpdate_Tick(object sender, EventArgs e)
        {
            string info = "";
            if (dtFormat == DateTimeFormat.ShowTime)
                info = DateTime.Now.ToLongTimeString();
            else
                info = DateTime.Now.ToLongDateString();
            toolStripStatusLabelClock.Text = info;
        }

        private void toolStripMenuItemDate_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowDate;
            currentCheckedItem = toolStripMenuItemDate;
            currentCheckedItem.Checked = true;
        }

        private void toolStripMenuItemTime_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowTime;
            currentCheckedItem = toolStripMenuItemTime;
            currentCheckedItem.Checked = true;
        }
    }
}
