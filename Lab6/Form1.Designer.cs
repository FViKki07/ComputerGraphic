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
            pictureBox1.Location = new Point(440, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(759, 544);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            comboBox1.Location = new Point(47, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(135, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 35);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 2;
            label1.Text = "Выберите фигуру:";
            // 
            // button1
            // 
            button1.Location = new Point(46, 80);
            button1.Name = "button1";
            button1.Size = new Size(136, 23);
            button1.TabIndex = 3;
            button1.Text = "Применить ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PerspectiveLabel
            // 
            PerspectiveLabel.AutoSize = true;
            PerspectiveLabel.Location = new Point(235, 35);
            PerspectiveLabel.Name = "PerspectiveLabel";
            PerspectiveLabel.Size = new Size(124, 15);
            PerspectiveLabel.TabIndex = 96;
            PerspectiveLabel.Text = "Выберите проекцию:";
            // 
            // ApplyProjection
            // 
            ApplyProjection.Location = new Point(235, 80);
            ApplyProjection.Name = "ApplyProjection";
            ApplyProjection.Size = new Size(135, 23);
            ApplyProjection.TabIndex = 95;
            ApplyProjection.Text = "Применить";
            ApplyProjection.UseVisualStyleBackColor = true;
            ApplyProjection.Click += ApplyProjection_Click;
            // 
            // button2
            // 
            button2.Location = new Point(139, 374);
            button2.Name = "button2";
            button2.Size = new Size(134, 23);
            button2.TabIndex = 115;
            button2.Text = "Применить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(46, 136);
            label8.Name = "label8";
            label8.Size = new Size(144, 15);
            label8.TabIndex = 114;
            label8.Text = "Масштаб отн-но центра:";
            // 
            // ApplyScaleCenter
            // 
            ApplyScaleCenter.Location = new Point(47, 180);
            ApplyScaleCenter.Name = "ApplyScaleCenter";
            ApplyScaleCenter.Size = new Size(135, 23);
            ApplyScaleCenter.TabIndex = 113;
            ApplyScaleCenter.Text = "Применить";
            ApplyScaleCenter.UseVisualStyleBackColor = true;
            ApplyScaleCenter.Click += ApplyScaleCenter_Click;
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 1;
            numericUpDown10.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Location = new Point(46, 154);
            numericUpDown10.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown10.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(136, 23);
            numericUpDown10.TabIndex = 112;
            numericUpDown10.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 332);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 111;
            label6.Text = "Масштаб";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 295);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 110;
            label5.Text = "Поворот";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Location = new Point(126, 330);
            numericUpDown7.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown7.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(47, 23);
            numericUpDown7.TabIndex = 109;
            numericUpDown7.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 1;
            numericUpDown8.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Location = new Point(184, 330);
            numericUpDown8.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(49, 23);
            numericUpDown8.TabIndex = 108;
            numericUpDown8.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 1;
            numericUpDown9.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown9.Location = new Point(242, 330);
            numericUpDown9.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown9.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(49, 23);
            numericUpDown9.TabIndex = 107;
            numericUpDown9.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown4.Location = new Point(126, 292);
            numericUpDown4.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(47, 23);
            numericUpDown4.TabIndex = 106;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown5.Location = new Point(184, 292);
            numericUpDown5.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(49, 23);
            numericUpDown5.TabIndex = 105;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown6.Location = new Point(242, 292);
            numericUpDown6.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown6.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(49, 23);
            numericUpDown6.TabIndex = 104;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 254);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 103;
            label4.Text = "Смещение";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(259, 225);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 102;
            label3.Text = "Z";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 225);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 101;
            label2.Text = "Y";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(141, 225);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 100;
            label7.Text = "X";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown3.Location = new Point(245, 253);
            numericUpDown3.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(47, 23);
            numericUpDown3.TabIndex = 99;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown2.Location = new Point(186, 253);
            numericUpDown2.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(49, 23);
            numericUpDown2.TabIndex = 98;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown1.Location = new Point(126, 253);
            numericUpDown1.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 23);
            numericUpDown1.TabIndex = 97;
            // 
            // ProjectionComboBox
            // 
            ProjectionComboBox.FormattingEnabled = true;
            ProjectionComboBox.Items.AddRange(new object[] { "Перcпективная", "Изометрическая" });
            ProjectionComboBox.Location = new Point(235, 53);
            ProjectionComboBox.Name = "ProjectionComboBox";
            ProjectionComboBox.Size = new Size(135, 23);
            ProjectionComboBox.TabIndex = 116;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(235, 136);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 117;
            label9.Text = "Отражение:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Отражение по X", "Отражение по Y", "Отражение по Z" });
            comboBox2.Location = new Point(235, 154);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(135, 23);
            comboBox2.TabIndex = 118;
            // 
            // button3
            // 
            button3.Location = new Point(235, 182);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(135, 22);
            button3.TabIndex = 119;
            button3.Text = "Применить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(76, 409);
            label10.Name = "label10";
            label10.Size = new Size(224, 15);
            label10.TabIndex = 120;
            label10.Text = "Поворот вокруг произвольной прямой\r\n";
            // 
            // numericUpDown11
            // 
            numericUpDown11.DecimalPlaces = 2;
            numericUpDown11.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown11.Location = new Point(245, 437);
            numericUpDown11.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(47, 23);
            numericUpDown11.TabIndex = 123;
            // 
            // numericUpDown12
            // 
            numericUpDown12.DecimalPlaces = 2;
            numericUpDown12.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown12.Location = new Point(186, 437);
            numericUpDown12.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(49, 23);
            numericUpDown12.TabIndex = 122;
            // 
            // numericUpDown13
            // 
            numericUpDown13.DecimalPlaces = 2;
            numericUpDown13.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown13.Location = new Point(126, 437);
            numericUpDown13.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(49, 23);
            numericUpDown13.TabIndex = 121;
            // 
            // numericUpDown14
            // 
            numericUpDown14.DecimalPlaces = 2;
            numericUpDown14.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown14.Location = new Point(244, 470);
            numericUpDown14.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown14.Name = "numericUpDown14";
            numericUpDown14.Size = new Size(47, 23);
            numericUpDown14.TabIndex = 126;
            // 
            // numericUpDown15
            // 
            numericUpDown15.DecimalPlaces = 2;
            numericUpDown15.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown15.Location = new Point(186, 470);
            numericUpDown15.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown15.Name = "numericUpDown15";
            numericUpDown15.Size = new Size(49, 23);
            numericUpDown15.TabIndex = 125;
            // 
            // numericUpDown16
            // 
            numericUpDown16.DecimalPlaces = 2;
            numericUpDown16.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown16.Location = new Point(126, 470);
            numericUpDown16.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown16.Name = "numericUpDown16";
            numericUpDown16.Size = new Size(49, 23);
            numericUpDown16.TabIndex = 124;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(70, 476);
            label11.Name = "label11";
            label11.Size = new Size(47, 15);
            label11.TabIndex = 128;
            label11.Text = "2 точка";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(70, 439);
            label12.Name = "label12";
            label12.Size = new Size(47, 15);
            label12.TabIndex = 127;
            label12.Text = "1 точка";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(76, 502);
            label13.Name = "label13";
            label13.Size = new Size(32, 15);
            label13.TabIndex = 130;
            label13.Text = "угол";
            // 
            // numericUpDown17
            // 
            numericUpDown17.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown17.Location = new Point(184, 496);
            numericUpDown17.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown17.Name = "numericUpDown17";
            numericUpDown17.Size = new Size(47, 23);
            numericUpDown17.TabIndex = 129;
            // 
            // button4
            // 
            button4.Location = new Point(139, 531);
            button4.Name = "button4";
            button4.Size = new Size(134, 23);
            button4.TabIndex = 131;
            button4.Text = "Применить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 564);
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
            Margin = new Padding(3, 2, 3, 2);
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