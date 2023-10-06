namespace Lab4
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
            groupBox1 = new GroupBox();
            DotRadioButton = new RadioButton();
            LineRadioButton = new RadioButton();
            PolygonRadioButton = new RadioButton();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            button2 = new Button();
            groupBox3 = new GroupBox();
            textBox3 = new TextBox();
            button3 = new Button();
            label3 = new Label();
            groupBox4 = new GroupBox();
            label4 = new Label();
            textBox4 = new TextBox();
            button4 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(285, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(667, 516);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(DotRadioButton);
            groupBox1.Controls.Add(LineRadioButton);
            groupBox1.Controls.Add(PolygonRadioButton);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(252, 54);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Нарисовать:";
            // 
            // DotRadioButton
            // 
            DotRadioButton.AutoSize = true;
            DotRadioButton.Location = new Point(6, 24);
            DotRadioButton.Name = "DotRadioButton";
            DotRadioButton.Size = new Size(60, 21);
            DotRadioButton.TabIndex = 12;
            DotRadioButton.TabStop = true;
            DotRadioButton.Text = "Точка";
            DotRadioButton.UseVisualStyleBackColor = true;
            // 
            // LineRadioButton
            // 
            LineRadioButton.AutoSize = true;
            LineRadioButton.Location = new Point(72, 24);
            LineRadioButton.Name = "LineRadioButton";
            LineRadioButton.Size = new Size(79, 21);
            LineRadioButton.TabIndex = 13;
            LineRadioButton.TabStop = true;
            LineRadioButton.Text = "Отрезок";
            LineRadioButton.UseVisualStyleBackColor = true;
            // 
            // PolygonRadioButton
            // 
            PolygonRadioButton.AutoSize = true;
            PolygonRadioButton.Location = new Point(163, 24);
            PolygonRadioButton.Name = "PolygonRadioButton";
            PolygonRadioButton.Size = new Size(75, 21);
            PolygonRadioButton.TabIndex = 14;
            PolygonRadioButton.TabStop = true;
            PolygonRadioButton.Text = "Полигон";
            PolygonRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(84, 498);
            button1.Name = "button1";
            button1.Size = new Size(105, 30);
            button1.TabIndex = 21;
            button1.Text = "Очистить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 20);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(65, 23);
            textBox1.TabIndex = 22;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 20);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(65, 23);
            textBox2.TabIndex = 23;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 25);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 24;
            label1.Text = "DX";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 25);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 25;
            label2.Text = "DY";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(18, 71);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(241, 73);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Сместить на:";
            // 
            // button2
            // 
            button2.Location = new Point(72, 46);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 26;
            button2.Text = "ок";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(24, 160);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(214, 70);
            groupBox3.TabIndex = 27;
            groupBox3.TabStop = false;
            groupBox3.Text = "Повернуть на:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(73, 20);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(110, 23);
            textBox3.TabIndex = 2;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // button3
            // 
            button3.Location = new Point(66, 44);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 1;
            button3.Text = "ок";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 22);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 0;
            label3.Text = "Градусы:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(button4);
            groupBox4.Location = new Point(31, 248);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(207, 82);
            groupBox4.TabIndex = 28;
            groupBox4.TabStop = false;
            groupBox4.Text = "Масштабировать:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 25);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 3;
            label4.Text = "На :";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(66, 20);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(110, 23);
            textBox4.TabIndex = 2;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // button4
            // 
            button4.Location = new Point(60, 56);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 1;
            button4.Text = "Ок";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Location = new Point(77, 346);
            button6.Name = "button6";
            button6.Size = new Size(130, 23);
            button6.TabIndex = 29;
            button6.Text = "Точка пересечения ";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 540);
            Controls.Add(button6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private RadioButton DotRadioButton;
        private RadioButton LineRadioButton;
        private RadioButton PolygonRadioButton;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private GroupBox groupBox2;
        private Button button2;
        private GroupBox groupBox3;
        private TextBox textBox3;
        private Button button3;
        private Label label3;
        private GroupBox groupBox4;
        private TextBox textBox4;
        private Button button4;
        private Label label4;
        private Button button6;
    }
}