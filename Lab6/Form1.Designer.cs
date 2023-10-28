namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            PerspectiveLabel = new Label();
            ApplyProjection = new Button();
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
            ProjectionComboBox = new ComboBox();
            label9 = new Label();
            comboBox2 = new ComboBox();
            button3 = new Button();
            label10 = new Label();
            numericUpDown11 = new NumericUpDown();
            numericUpDown12 = new NumericUpDown();
            numericUpDown13 = new NumericUpDown();
            numericUpDown14 = new NumericUpDown();
            numericUpDown15 = new NumericUpDown();
            numericUpDown16 = new NumericUpDown();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            numericUpDown17 = new NumericUpDown();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(503, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(867, 725);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            comboBox1.Location = new Point(54, 71);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(154, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 47);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 2;
            label1.Text = "Выберите фигуру:";
            // 
            // button1
            // 
            button1.Location = new Point(52, 107);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(156, 31);
            button1.TabIndex = 3;
            button1.Text = "Применить ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PerspectiveLabel
            // 
            PerspectiveLabel.AutoSize = true;
            PerspectiveLabel.Location = new Point(269, 47);
            PerspectiveLabel.Name = "PerspectiveLabel";
            PerspectiveLabel.Size = new Size(157, 20);
            PerspectiveLabel.TabIndex = 96;
            PerspectiveLabel.Text = "Выберите проекцию:";
            // 
            // ApplyProjection
            // 
            ApplyProjection.Location = new Point(269, 107);
            ApplyProjection.Margin = new Padding(3, 4, 3, 4);
            ApplyProjection.Name = "ApplyProjection";
            ApplyProjection.Size = new Size(154, 31);
            ApplyProjection.TabIndex = 95;
            ApplyProjection.Text = "Применить";
            ApplyProjection.UseVisualStyleBackColor = true;
            ApplyProjection.Click += ApplyProjection_Click;
            // 
            // button2
            // 
            button2.Location = new Point(159, 498);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(153, 31);
            button2.TabIndex = 115;
            button2.Text = "Применить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(52, 181);
            label8.Name = "label8";
            label8.Size = new Size(180, 20);
            label8.TabIndex = 114;
            label8.Text = "Масштаб отн-но центра:";
            // 
            // ApplyScaleCenter
            // 
            ApplyScaleCenter.Location = new Point(54, 240);
            ApplyScaleCenter.Margin = new Padding(3, 4, 3, 4);
            ApplyScaleCenter.Name = "ApplyScaleCenter";
            ApplyScaleCenter.Size = new Size(154, 31);
            ApplyScaleCenter.TabIndex = 113;
            ApplyScaleCenter.Text = "Применить";
            ApplyScaleCenter.UseVisualStyleBackColor = true;
            ApplyScaleCenter.Click += ApplyScaleCenter_Click;
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 1;
            numericUpDown10.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Location = new Point(53, 205);
            numericUpDown10.Margin = new Padding(3, 4, 3, 4);
            numericUpDown10.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown10.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(155, 27);
            numericUpDown10.TabIndex = 112;
            numericUpDown10.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 442);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 111;
            label6.Text = "Масштаб";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 393);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 110;
            label5.Text = "Поворот";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Location = new Point(144, 440);
            numericUpDown7.Margin = new Padding(3, 4, 3, 4);
            numericUpDown7.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown7.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(54, 27);
            numericUpDown7.TabIndex = 109;
            numericUpDown7.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 1;
            numericUpDown8.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Location = new Point(210, 440);
            numericUpDown8.Margin = new Padding(3, 4, 3, 4);
            numericUpDown8.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(56, 27);
            numericUpDown8.TabIndex = 108;
            numericUpDown8.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 1;
            numericUpDown9.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown9.Location = new Point(277, 440);
            numericUpDown9.Margin = new Padding(3, 4, 3, 4);
            numericUpDown9.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown9.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(56, 27);
            numericUpDown9.TabIndex = 107;
            numericUpDown9.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown4.Location = new Point(144, 390);
            numericUpDown4.Margin = new Padding(3, 4, 3, 4);
            numericUpDown4.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(54, 27);
            numericUpDown4.TabIndex = 106;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown5.Location = new Point(210, 390);
            numericUpDown5.Margin = new Padding(3, 4, 3, 4);
            numericUpDown5.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(56, 27);
            numericUpDown5.TabIndex = 105;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown6.Location = new Point(277, 390);
            numericUpDown6.Margin = new Padding(3, 4, 3, 4);
            numericUpDown6.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(56, 27);
            numericUpDown6.TabIndex = 104;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 338);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 103;
            label4.Text = "Смещение";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 300);
            label3.Name = "label3";
            label3.Size = new Size(18, 20);
            label3.TabIndex = 102;
            label3.Text = "Z";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 300);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 101;
            label2.Text = "Y";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(161, 300);
            label7.Name = "label7";
            label7.Size = new Size(18, 20);
            label7.TabIndex = 100;
            label7.Text = "X";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown3.Location = new Point(280, 337);
            numericUpDown3.Margin = new Padding(3, 4, 3, 4);
            numericUpDown3.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(54, 27);
            numericUpDown3.TabIndex = 99;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown2.Location = new Point(212, 337);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(56, 27);
            numericUpDown2.TabIndex = 98;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown1.Location = new Point(144, 337);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 27);
            numericUpDown1.TabIndex = 97;
            // 
            // ProjectionComboBox
            // 
            ProjectionComboBox.FormattingEnabled = true;
            ProjectionComboBox.Items.AddRange(new object[] { "Перcпективная", "Изометрическая" });
            ProjectionComboBox.Location = new Point(269, 71);
            ProjectionComboBox.Margin = new Padding(3, 4, 3, 4);
            ProjectionComboBox.Name = "ProjectionComboBox";
            ProjectionComboBox.Size = new Size(154, 28);
            ProjectionComboBox.TabIndex = 116;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(269, 181);
            label9.Name = "label9";
            label9.Size = new Size(91, 20);
            label9.TabIndex = 117;
            label9.Text = "Отражение:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Отражение по X", "Отражение по Y", "Отражение по Z" });
            comboBox2.Location = new Point(269, 205);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(154, 28);
            comboBox2.TabIndex = 118;
            // 
            // button3
            // 
            button3.Location = new Point(269, 242);
            button3.Name = "button3";
            button3.Size = new Size(154, 29);
            button3.TabIndex = 119;
            button3.Text = "Применить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(87, 545);
            label10.Name = "label10";
            label10.Size = new Size(284, 20);
            label10.TabIndex = 120;
            label10.Text = "поворот вокруг произвольной прямой\r\n";
            // 
            // numericUpDown11
            // 
            numericUpDown11.DecimalPlaces = 2;
            numericUpDown11.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown11.Location = new Point(280, 583);
            numericUpDown11.Margin = new Padding(3, 4, 3, 4);
            numericUpDown11.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown11.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(54, 27);
            numericUpDown11.TabIndex = 123;
            // 
            // numericUpDown12
            // 
            numericUpDown12.DecimalPlaces = 2;
            numericUpDown12.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown12.Location = new Point(212, 583);
            numericUpDown12.Margin = new Padding(3, 4, 3, 4);
            numericUpDown12.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown12.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(56, 27);
            numericUpDown12.TabIndex = 122;
            // 
            // numericUpDown13
            // 
            numericUpDown13.DecimalPlaces = 2;
            numericUpDown13.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown13.Location = new Point(144, 583);
            numericUpDown13.Margin = new Padding(3, 4, 3, 4);
            numericUpDown13.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown13.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(56, 27);
            numericUpDown13.TabIndex = 121;
            // 
            // numericUpDown14
            // 
            numericUpDown14.DecimalPlaces = 2;
            numericUpDown14.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown14.Location = new Point(279, 627);
            numericUpDown14.Margin = new Padding(3, 4, 3, 4);
            numericUpDown14.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown14.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown14.Name = "numericUpDown14";
            numericUpDown14.Size = new Size(54, 27);
            numericUpDown14.TabIndex = 126;
            // 
            // numericUpDown15
            // 
            numericUpDown15.DecimalPlaces = 2;
            numericUpDown15.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown15.Location = new Point(212, 627);
            numericUpDown15.Margin = new Padding(3, 4, 3, 4);
            numericUpDown15.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown15.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown15.Name = "numericUpDown15";
            numericUpDown15.Size = new Size(56, 27);
            numericUpDown15.TabIndex = 125;
            // 
            // numericUpDown16
            // 
            numericUpDown16.DecimalPlaces = 2;
            numericUpDown16.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown16.Location = new Point(144, 627);
            numericUpDown16.Margin = new Padding(3, 4, 3, 4);
            numericUpDown16.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown16.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown16.Name = "numericUpDown16";
            numericUpDown16.Size = new Size(56, 27);
            numericUpDown16.TabIndex = 124;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(80, 634);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 128;
            label11.Text = "2 точка";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(80, 585);
            label12.Name = "label12";
            label12.Size = new Size(59, 20);
            label12.TabIndex = 127;
            label12.Text = "1 точка";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(87, 669);
            label13.Name = "label13";
            label13.Size = new Size(39, 20);
            label13.TabIndex = 130;
            label13.Text = "угол";
            // 
            // numericUpDown17
            // 
            numericUpDown17.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown17.Location = new Point(210, 662);
            numericUpDown17.Margin = new Padding(3, 4, 3, 4);
            numericUpDown17.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown17.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown17.Name = "numericUpDown17";
            numericUpDown17.Size = new Size(54, 27);
            numericUpDown17.TabIndex = 129;
            // 
            // button4
            // 
            button4.Location = new Point(159, 708);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(153, 31);
            button4.TabIndex = 131;
            button4.Text = "Применить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 752);
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
            Controls.Add(ApplyProjection);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private Label PerspectiveLabel;
        private Button ApplyProjection;
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
        private ComboBox ProjectionComboBox;
        private Label label9;
        private ComboBox comboBox2;
        private Button button3;
        private Label label10;
        private NumericUpDown numericUpDown11;
        private NumericUpDown numericUpDown12;
        private NumericUpDown numericUpDown13;
        private NumericUpDown numericUpDown14;
        private NumericUpDown numericUpDown15;
        private NumericUpDown numericUpDown16;
        private Label label11;
        private Label label12;
        private Label label13;
        private NumericUpDown numericUpDown17;
        private Button button4;
    }
}