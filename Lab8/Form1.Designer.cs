﻿using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab8
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button4 = new Button();
            label13 = new Label();
            numericUpDown17 = new NumericUpDown();
            label11 = new Label();
            label12 = new Label();
            numericUpDown14 = new NumericUpDown();
            numericUpDown15 = new NumericUpDown();
            numericUpDown16 = new NumericUpDown();
            numericUpDown11 = new NumericUpDown();
            numericUpDown12 = new NumericUpDown();
            numericUpDown13 = new NumericUpDown();
            label10 = new Label();
            button3 = new Button();
            comboBox2 = new ComboBox();
            label9 = new Label();
            ProjectionComboBox = new ComboBox();
            button2 = new Button();
            label8 = new Label();
            ApplyScaleCenter = new Button();
            numericUpDown10 = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            PerspectiveLabel = new Label();
            button1 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            pictureBox2 = new PictureBox();
            button5 = new Button();
            button6 = new Button();
            stepsNumericUpDown = new NumericUpDown();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            y1NnumericUpDown = new NumericUpDown();
            x1NumericUpDown = new NumericUpDown();
            y0NumericUpDown = new NumericUpDown();
            x0NumericUpDown = new NumericUpDown();
            functiounComboBox = new ComboBox();
            button7 = new Button();
            comboBox3 = new ComboBox();
            label20 = new Label();
            buttonNonFace = new Button();
            button8 = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stepsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)y1NnumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)x1NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)y0NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)x0NumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(153, 673);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(153, 31);
            button4.TabIndex = 172;
            button4.Text = "Применить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(81, 635);
            label13.Name = "label13";
            label13.Size = new Size(39, 20);
            label13.TabIndex = 171;
            label13.Text = "угол";
            // 
            // numericUpDown17
            // 
            numericUpDown17.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown17.Location = new Point(203, 627);
            numericUpDown17.Margin = new Padding(3, 4, 3, 4);
            numericUpDown17.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown17.Name = "numericUpDown17";
            numericUpDown17.Size = new Size(54, 27);
            numericUpDown17.TabIndex = 170;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(74, 600);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 169;
            label11.Text = "2 точка";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(74, 551);
            label12.Name = "label12";
            label12.Size = new Size(59, 20);
            label12.TabIndex = 168;
            label12.Text = "1 точка";
            // 
            // numericUpDown14
            // 
            numericUpDown14.DecimalPlaces = 2;
            numericUpDown14.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown14.Location = new Point(273, 592);
            numericUpDown14.Margin = new Padding(3, 4, 3, 4);
            numericUpDown14.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown14.Name = "numericUpDown14";
            numericUpDown14.Size = new Size(54, 27);
            numericUpDown14.TabIndex = 167;
            // 
            // numericUpDown15
            // 
            numericUpDown15.DecimalPlaces = 2;
            numericUpDown15.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown15.Location = new Point(207, 592);
            numericUpDown15.Margin = new Padding(3, 4, 3, 4);
            numericUpDown15.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown15.Name = "numericUpDown15";
            numericUpDown15.Size = new Size(56, 27);
            numericUpDown15.TabIndex = 166;
            // 
            // numericUpDown16
            // 
            numericUpDown16.DecimalPlaces = 2;
            numericUpDown16.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown16.Location = new Point(138, 592);
            numericUpDown16.Margin = new Padding(3, 4, 3, 4);
            numericUpDown16.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown16.Name = "numericUpDown16";
            numericUpDown16.Size = new Size(56, 27);
            numericUpDown16.TabIndex = 165;
            // 
            // numericUpDown11
            // 
            numericUpDown11.DecimalPlaces = 2;
            numericUpDown11.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown11.Location = new Point(274, 548);
            numericUpDown11.Margin = new Padding(3, 4, 3, 4);
            numericUpDown11.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(54, 27);
            numericUpDown11.TabIndex = 164;
            // 
            // numericUpDown12
            // 
            numericUpDown12.DecimalPlaces = 2;
            numericUpDown12.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown12.Location = new Point(207, 548);
            numericUpDown12.Margin = new Padding(3, 4, 3, 4);
            numericUpDown12.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(56, 27);
            numericUpDown12.TabIndex = 163;
            // 
            // numericUpDown13
            // 
            numericUpDown13.DecimalPlaces = 2;
            numericUpDown13.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown13.Location = new Point(138, 548);
            numericUpDown13.Margin = new Padding(3, 4, 3, 4);
            numericUpDown13.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(56, 27);
            numericUpDown13.TabIndex = 162;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(81, 511);
            label10.Name = "label10";
            label10.Size = new Size(286, 20);
            label10.TabIndex = 161;
            label10.Text = "Поворот вокруг произвольной прямой\r\n";
            // 
            // button3
            // 
            button3.Location = new Point(254, 212);
            button3.Name = "button3";
            button3.Size = new Size(154, 29);
            button3.TabIndex = 160;
            button3.Text = "Применить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Отражение по X", "Отражение по Y", "Отражение по Z" });
            comboBox2.Location = new Point(254, 175);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(154, 28);
            comboBox2.TabIndex = 159;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(254, 151);
            label9.Name = "label9";
            label9.Size = new Size(91, 20);
            label9.TabIndex = 158;
            label9.Text = "Отражение:";
            // 
            // ProjectionComboBox
            // 
            ProjectionComboBox.FormattingEnabled = true;
            ProjectionComboBox.Items.AddRange(new object[] { "Перспективная", "Изометрическая", "Ортогональная XY", "Ортогональная XZ", "Ортогональная YZ" });
            ProjectionComboBox.Location = new Point(254, 60);
            ProjectionComboBox.Margin = new Padding(3, 4, 3, 4);
            ProjectionComboBox.Name = "ProjectionComboBox";
            ProjectionComboBox.Size = new Size(154, 28);
            ProjectionComboBox.TabIndex = 157;
            // 
            // button2
            // 
            button2.Location = new Point(159, 459);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(153, 31);
            button2.TabIndex = 156;
            button2.Text = "Применить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(38, 151);
            label8.Name = "label8";
            label8.Size = new Size(180, 20);
            label8.TabIndex = 155;
            label8.Text = "Масштаб отн-но центра:";
            // 
            // ApplyScaleCenter
            // 
            ApplyScaleCenter.Location = new Point(39, 209);
            ApplyScaleCenter.Margin = new Padding(3, 4, 3, 4);
            ApplyScaleCenter.Name = "ApplyScaleCenter";
            ApplyScaleCenter.Size = new Size(154, 31);
            ApplyScaleCenter.TabIndex = 154;
            ApplyScaleCenter.Text = "Применить";
            ApplyScaleCenter.UseVisualStyleBackColor = true;
            ApplyScaleCenter.Click += ApplyScaleCenter_Click;
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 1;
            numericUpDown10.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Location = new Point(38, 175);
            numericUpDown10.Margin = new Padding(3, 4, 3, 4);
            numericUpDown10.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown10.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(155, 27);
            numericUpDown10.TabIndex = 153;
            numericUpDown10.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 403);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 152;
            label6.Text = "Масштаб";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 353);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 151;
            label5.Text = "Поворот";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Location = new Point(144, 399);
            numericUpDown7.Margin = new Padding(3, 4, 3, 4);
            numericUpDown7.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown7.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(54, 27);
            numericUpDown7.TabIndex = 150;
            numericUpDown7.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 1;
            numericUpDown8.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Location = new Point(210, 399);
            numericUpDown8.Margin = new Padding(3, 4, 3, 4);
            numericUpDown8.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(56, 27);
            numericUpDown8.TabIndex = 149;
            numericUpDown8.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 1;
            numericUpDown9.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown9.Location = new Point(277, 399);
            numericUpDown9.Margin = new Padding(3, 4, 3, 4);
            numericUpDown9.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown9.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(56, 27);
            numericUpDown9.TabIndex = 148;
            numericUpDown9.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown4.Location = new Point(144, 349);
            numericUpDown4.Margin = new Padding(3, 4, 3, 4);
            numericUpDown4.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(54, 27);
            numericUpDown4.TabIndex = 147;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown5.Location = new Point(210, 349);
            numericUpDown5.Margin = new Padding(3, 4, 3, 4);
            numericUpDown5.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(56, 27);
            numericUpDown5.TabIndex = 146;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown6.Location = new Point(277, 349);
            numericUpDown6.Margin = new Padding(3, 4, 3, 4);
            numericUpDown6.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(56, 27);
            numericUpDown6.TabIndex = 145;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 299);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 144;
            label4.Text = "Смещение";
            label4.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 259);
            label3.Name = "label3";
            label3.Size = new Size(18, 20);
            label3.TabIndex = 143;
            label3.Text = "Z";
            label3.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 259);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 142;
            label2.Text = "Y";
            label2.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(161, 259);
            label7.Name = "label7";
            label7.Size = new Size(18, 20);
            label7.TabIndex = 141;
            label7.Text = "X";
            label7.Click += button1_Click;
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown3.Location = new Point(280, 297);
            numericUpDown3.Margin = new Padding(3, 4, 3, 4);
            numericUpDown3.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(54, 27);
            numericUpDown3.TabIndex = 140;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown2.Location = new Point(213, 297);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(56, 27);
            numericUpDown2.TabIndex = 139;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown1.Location = new Point(144, 297);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 27);
            numericUpDown1.TabIndex = 138;
            // 
            // PerspectiveLabel
            // 
            PerspectiveLabel.AutoSize = true;
            PerspectiveLabel.Location = new Point(254, 36);
            PerspectiveLabel.Name = "PerspectiveLabel";
            PerspectiveLabel.Size = new Size(157, 20);
            PerspectiveLabel.TabIndex = 137;
            PerspectiveLabel.Text = "Выберите проекцию:";
            // 
            // button1
            // 
            button1.Location = new Point(38, 99);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(155, 41);
            button1.TabIndex = 135;
            button1.Text = "Применить ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 36);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 134;
            label1.Text = "Выберите фигуру:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            comboBox1.Location = new Point(39, 60);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(154, 28);
            comboBox1.TabIndex = 133;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(488, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(867, 725);
            pictureBox1.TabIndex = 132;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveBorder;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1823, 30);
            menuStrip1.TabIndex = 175;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem, загрузитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(166, 26);
            загрузитьToolStripMenuItem.Text = "Загрузить";
            загрузитьToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(1361, 41);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(395, 308);
            pictureBox2.TabIndex = 176;
            pictureBox2.TabStop = false;
            pictureBox2.MouseClick += pictureBox2_MouseClick;
            // 
            // button5
            // 
            button5.Location = new Point(1400, 635);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(111, 85);
            button5.TabIndex = 177;
            button5.Text = "Построить фигуру вращения";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(1400, 737);
            button6.Name = "button6";
            button6.Size = new Size(138, 45);
            button6.TabIndex = 178;
            button6.Text = "Очистить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // stepsNumericUpDown
            // 
            stepsNumericUpDown.Location = new Point(1633, 395);
            stepsNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            stepsNumericUpDown.Name = "stepsNumericUpDown";
            stepsNumericUpDown.Size = new Size(150, 27);
            stepsNumericUpDown.TabIndex = 179;
            stepsNumericUpDown.Value = new decimal(new int[] { 13, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(1390, 399);
            label14.Name = "label14";
            label14.Size = new Size(160, 23);
            label14.TabIndex = 180;
            label14.Text = "Кол-во разбиений:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(1390, 435);
            label15.Name = "label15";
            label15.Size = new Size(81, 23);
            label15.TabIndex = 182;
            label15.Text = "Функция:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(1400, 575);
            label16.Name = "label16";
            label16.Size = new Size(32, 23);
            label16.TabIndex = 183;
            label16.Text = "Y0:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(1400, 523);
            label17.Name = "label17";
            label17.Size = new Size(33, 23);
            label17.TabIndex = 184;
            label17.Text = "X0:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(1589, 523);
            label18.Name = "label18";
            label18.Size = new Size(33, 23);
            label18.TabIndex = 186;
            label18.Text = "X1:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(1589, 575);
            label19.Name = "label19";
            label19.Size = new Size(32, 23);
            label19.TabIndex = 185;
            label19.Text = "Y1:";
            // 
            // y1NnumericUpDown
            // 
            y1NnumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            y1NnumericUpDown.Location = new Point(1633, 575);
            y1NnumericUpDown.Margin = new Padding(3, 5, 3, 5);
            y1NnumericUpDown.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            y1NnumericUpDown.Name = "y1NnumericUpDown";
            y1NnumericUpDown.Size = new Size(56, 27);
            y1NnumericUpDown.TabIndex = 187;
            y1NnumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // x1NumericUpDown
            // 
            x1NumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            x1NumericUpDown.Location = new Point(1633, 523);
            x1NumericUpDown.Margin = new Padding(3, 5, 3, 5);
            x1NumericUpDown.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            x1NumericUpDown.Name = "x1NumericUpDown";
            x1NumericUpDown.Size = new Size(56, 27);
            x1NumericUpDown.TabIndex = 188;
            x1NumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // y0NumericUpDown
            // 
            y0NumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            y0NumericUpDown.Location = new Point(1445, 575);
            y0NumericUpDown.Margin = new Padding(3, 5, 3, 5);
            y0NumericUpDown.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            y0NumericUpDown.Name = "y0NumericUpDown";
            y0NumericUpDown.Size = new Size(56, 27);
            y0NumericUpDown.TabIndex = 189;
            // 
            // x0NumericUpDown
            // 
            x0NumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            x0NumericUpDown.Location = new Point(1445, 523);
            x0NumericUpDown.Margin = new Padding(3, 5, 3, 5);
            x0NumericUpDown.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            x0NumericUpDown.Name = "x0NumericUpDown";
            x0NumericUpDown.Size = new Size(56, 27);
            x0NumericUpDown.TabIndex = 190;
            x0NumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // functiounComboBox
            // 
            functiounComboBox.FormattingEnabled = true;
            functiounComboBox.Location = new Point(1633, 435);
            functiounComboBox.Margin = new Padding(3, 4, 3, 4);
            functiounComboBox.Name = "functiounComboBox";
            functiounComboBox.Size = new Size(154, 28);
            functiounComboBox.TabIndex = 191;
            // 
            // button7
            // 
            button7.Location = new Point(1589, 635);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(111, 85);
            button7.TabIndex = 192;
            button7.Text = "Построить график функции";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "по X", "по Y", "по Z" });
            comboBox3.Location = new Point(1633, 472);
            comboBox3.Margin = new Padding(3, 5, 3, 5);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(154, 28);
            comboBox3.TabIndex = 193;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(1390, 477);
            label20.Name = "label20";
            label20.Size = new Size(129, 23);
            label20.TabIndex = 194;
            label20.Text = "Ось вращения:";
            // 
            // buttonNonFace
            // 
            buttonNonFace.Location = new Point(26, 719);
            buttonNonFace.Name = "buttonNonFace";
            buttonNonFace.Size = new Size(167, 63);
            buttonNonFace.TabIndex = 195;
            buttonNonFace.Text = "Нарисовать с отсечением граней";
            buttonNonFace.UseVisualStyleBackColor = true;
            buttonNonFace.Click += buttonNonFace_Click;
            // 
            // button8
            // 
            button8.Location = new Point(254, 99);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(155, 41);
            button8.TabIndex = 196;
            button8.Text = "Применить ";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ApplyProjection_Click;
            // 
            // button9
            // 
            button9.Location = new Point(241, 719);
            button9.Name = "button9";
            button9.Size = new Size(167, 63);
            button9.TabIndex = 197;
            button9.Text = "Z Buffer";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1823, 803);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(buttonNonFace);
            Controls.Add(label20);
            Controls.Add(comboBox3);
            Controls.Add(button7);
            Controls.Add(functiounComboBox);
            Controls.Add(x0NumericUpDown);
            Controls.Add(y0NumericUpDown);
            Controls.Add(x1NumericUpDown);
            Controls.Add(y1NnumericUpDown);
            Controls.Add(label18);
            Controls.Add(label19);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(stepsNumericUpDown);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(pictureBox2);
            Controls.Add(button4);
            Controls.Add(label13);
            Controls.Add(numericUpDown17);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(numericUpDown14);
            Controls.Add(numericUpDown15);
            Controls.Add(numericUpDown16);
            Controls.Add(numericUpDown11);
            Controls.Add(numericUpDown12);
            Controls.Add(numericUpDown13);
            Controls.Add(label10);
            Controls.Add(button3);
            Controls.Add(comboBox2);
            Controls.Add(label9);
            Controls.Add(ProjectionComboBox);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(ApplyScaleCenter);
            Controls.Add(numericUpDown10);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(numericUpDown7);
            Controls.Add(numericUpDown8);
            Controls.Add(numericUpDown9);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(PerspectiveLabel);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)stepsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)y1NnumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)x1NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)y0NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)x0NumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Label label13;
        private NumericUpDown numericUpDown17;
        private Label label11;
        private Label label12;
        private NumericUpDown numericUpDown14;
        private NumericUpDown numericUpDown15;
        private NumericUpDown numericUpDown16;
        private NumericUpDown numericUpDown11;
        private NumericUpDown numericUpDown12;
        private NumericUpDown numericUpDown13;
        private Label label10;
        private Button button3;
        private ComboBox comboBox2;
        private Label label9;
        private ComboBox ProjectionComboBox;
        private Button button2;
        private Label label8;
        private Button ApplyScaleCenter;
        private NumericUpDown numericUpDown10;
        private Label label6;
        private Label label5;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown9;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label PerspectiveLabel;
        private Button button1;
        private Label label1;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem загрузитьToolStripMenuItem;
        private PictureBox pictureBox2;
        private Button button5;
        private Button button6;
        private NumericUpDown stepsNumericUpDown;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private NumericUpDown y1NnumericUpDown;
        private NumericUpDown x1NumericUpDown;
        private NumericUpDown y0NumericUpDown;
        private NumericUpDown x0NumericUpDown;
        private ComboBox functiounComboBox;
        private Button button7;
        private ComboBox comboBox3;
        private Label label20;
        private Button buttonNonFace;
        private Button button8;
        private Button button9;
    }
}