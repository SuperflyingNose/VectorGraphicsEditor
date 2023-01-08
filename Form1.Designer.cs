namespace VectorGraphicsEditor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panel1.Location = new System.Drawing.Point(5, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 505);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "╱";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DrawLine);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "▭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DrawRect);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "Выбор цвета линии";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ChangeLineColor);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(478, 11);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(169, 28);
            this.button4.TabIndex = 4;
            this.button4.Text = "Выбор цвета заливки";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ChangeFillColor);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(654, 12);
            this.textBox1.MinimumSize = new System.Drawing.Size(4, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 28);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(718, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 28);
            this.button5.TabIndex = 6;
            this.button5.Text = "Задать ширину линии";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ChangeLineWidth);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(84, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 28);
            this.button6.TabIndex = 7;
            this.button6.Text = "◯";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.DrawEllipse);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(151, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 28);
            this.button7.TabIndex = 8;
            this.button7.Text = "Сгруппировать";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(278, 14);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(20, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(993, 12);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(28, 28);
            this.UndoButton.TabIndex = 10;
            this.UndoButton.Text = "←";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(1027, 12);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(28, 28);
            this.RedoButton.TabIndex = 11;
            this.RedoButton.Text = "→\t";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1085, 601);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel1_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
    }
}

