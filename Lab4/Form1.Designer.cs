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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
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
            button1.Location = new Point(75, 498);
            button1.Name = "button1";
            button1.Size = new Size(105, 30);
            button1.TabIndex = 21;
            button1.Text = "Очистить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 540);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private RadioButton DotRadioButton;
        private RadioButton LineRadioButton;
        private RadioButton PolygonRadioButton;
        private Button button1;
    }
}