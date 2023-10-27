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
            ApplyPerspective = new Button();
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
            PerspectiveComboBox = new ComboBox();
            label9 = new Label();
            comboBox2 = new ComboBox();
            button3 = new Button();
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
            comboBox1.Location = new Point(53, 71);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 47);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 2;
            label1.Text = "Выберите фигуру:";
            // 
            // button1
            // 
            button1.Location = new Point(54, 121);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(137, 31);
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
            PerspectiveLabel.Size = new Size(154, 20);
            PerspectiveLabel.TabIndex = 96;
            PerspectiveLabel.Text = "Выберите проекцию";
            // 
            // ApplyPerspective
            // 
            ApplyPerspective.Location = new Point(270, 121);
            ApplyPerspective.Margin = new Padding(3, 4, 3, 4);
            ApplyPerspective.Name = "ApplyPerspective";
            ApplyPerspective.Size = new Size(137, 31);
            ApplyPerspective.TabIndex = 95;
            ApplyPerspective.Text = "Применить";
            ApplyPerspective.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(317, 385);
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
            label8.Location = new Point(40, 255);
            label8.Name = "label8";
            label8.Size = new Size(177, 20);
            label8.TabIndex = 114;
            label8.Text = "Масштаб отн-но центра";
            // 
            // ApplyScaleCenter
            // 
            ApplyScaleCenter.Location = new Point(40, 327);
            ApplyScaleCenter.Margin = new Padding(3, 4, 3, 4);
            ApplyScaleCenter.Name = "ApplyScaleCenter";
            ApplyScaleCenter.Size = new Size(153, 31);
            ApplyScaleCenter.TabIndex = 113;
            ApplyScaleCenter.Text = "Применить";
            ApplyScaleCenter.UseVisualStyleBackColor = true;
            ApplyScaleCenter.Click += ApplyScaleCenter_Click;
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 1;
            numericUpDown10.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Location = new Point(69, 279);
            numericUpDown10.Margin = new Padding(3, 4, 3, 4);
            numericUpDown10.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown10.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(91, 27);
            numericUpDown10.TabIndex = 112;
            numericUpDown10.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(224, 329);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 111;
            label6.Text = "Масштаб";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(227, 280);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 110;
            label5.Text = "Поворот";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown7.Location = new Point(302, 327);
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
            numericUpDown8.Location = new Point(368, 327);
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
            numericUpDown9.Location = new Point(435, 327);
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
            numericUpDown4.Location = new Point(302, 277);
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
            numericUpDown5.Location = new Point(368, 277);
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
            numericUpDown6.Location = new Point(435, 277);
            numericUpDown6.Margin = new Padding(3, 4, 3, 4);
            numericUpDown6.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown6.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(56, 27);
            numericUpDown6.TabIndex = 104;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(218, 225);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 103;
            label4.Text = "Смещение";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 187);
            label3.Name = "label3";
            label3.Size = new Size(18, 20);
            label3.TabIndex = 102;
            label3.Text = "Z";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 187);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 101;
            label2.Text = "Y";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(319, 187);
            label7.Name = "label7";
            label7.Size = new Size(18, 20);
            label7.TabIndex = 100;
            label7.Text = "X";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown3.Location = new Point(438, 224);
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
            numericUpDown2.Location = new Point(370, 224);
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
            numericUpDown1.Location = new Point(302, 224);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 27);
            numericUpDown1.TabIndex = 97;
            // 
            // PerspectiveComboBox
            // 
            PerspectiveComboBox.FormattingEnabled = true;
            PerspectiveComboBox.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            PerspectiveComboBox.Location = new Point(269, 71);
            PerspectiveComboBox.Margin = new Padding(3, 4, 3, 4);
            PerspectiveComboBox.Name = "PerspectiveComboBox";
            PerspectiveComboBox.Size = new Size(138, 28);
            PerspectiveComboBox.TabIndex = 116;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(218, 444);
            label9.Name = "label9";
            label9.Size = new Size(88, 20);
            label9.TabIndex = 117;
            label9.Text = "Отражение";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Отражение по X", "Отражение по Y", "Отражение по Z" });
            comboBox2.Location = new Point(321, 444);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 118;
            // 
            // button3
            // 
            button3.Location = new Point(345, 478);
            button3.Name = "button3";
            button3.Size = new Size(102, 29);
            button3.TabIndex = 119;
            button3.Text = "Применить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 752);
            Controls.Add(button3);
            Controls.Add(comboBox2);
            Controls.Add(label9);
            Controls.Add(PerspectiveComboBox);
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
            Controls.Add(ApplyPerspective);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private Label PerspectiveLabel;
        private Button ApplyPerspective;
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
        private ComboBox PerspectiveComboBox;
        private Label label9;
        private ComboBox comboBox2;
        private Button button3;
    }
}