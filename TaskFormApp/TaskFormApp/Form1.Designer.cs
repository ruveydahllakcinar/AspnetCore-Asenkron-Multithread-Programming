namespace TaskFormApp
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
            this.btnreadfile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btncounter = new System.Windows.Forms.Button();
            this.txtBoxCounter = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnreadfile
            // 
            this.btnreadfile.Location = new System.Drawing.Point(27, 37);
            this.btnreadfile.Name = "btnreadfile";
            this.btnreadfile.Size = new System.Drawing.Size(95, 35);
            this.btnreadfile.TabIndex = 0;
            this.btnreadfile.Text = "Dosya oku";
            this.btnreadfile.UseVisualStyleBackColor = true;
            this.btnreadfile.Click += new System.EventHandler(this.btnreadfile_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(139, 114);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(165, 183);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btncounter
            // 
            this.btncounter.Location = new System.Drawing.Point(418, 43);
            this.btncounter.Name = "btncounter";
            this.btncounter.Size = new System.Drawing.Size(117, 44);
            this.btncounter.TabIndex = 2;
            this.btncounter.Text = "Sayac Arttır";
            this.btncounter.UseVisualStyleBackColor = true;
            this.btncounter.Click += new System.EventHandler(this.btncounter_Click);
            // 
            // txtBoxCounter
            // 
            this.txtBoxCounter.Location = new System.Drawing.Point(408, 127);
            this.txtBoxCounter.Name = "txtBoxCounter";
            this.txtBoxCounter.Size = new System.Drawing.Size(188, 20);
            this.txtBoxCounter.TabIndex = 3;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(572, 229);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(155, 138);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.txtBoxCounter);
            this.Controls.Add(this.btncounter);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnreadfile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnreadfile;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btncounter;
        private System.Windows.Forms.TextBox txtBoxCounter;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

