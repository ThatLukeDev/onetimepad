namespace otp
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
            this.content = new System.Windows.Forms.TextBox();
            this.dimension = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.start = new System.Windows.Forms.Button();
            this.valuesps = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 0);
            this.content.Multiline = true;
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(800, 450);
            this.content.TabIndex = 0;
            // 
            // dimension
            // 
            this.dimension.Dock = System.Windows.Forms.DockStyle.Left;
            this.dimension.Location = new System.Drawing.Point(0, 0);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(100, 20);
            this.dimension.TabIndex = 1;
            this.dimension.Text = "20x20x2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.valuesps);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.dimension);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 2;
            // 
            // start
            // 
            this.start.Dock = System.Windows.Forms.DockStyle.Right;
            this.start.Location = new System.Drawing.Point(581, 0);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(219, 100);
            this.start.TabIndex = 2;
            this.start.Text = "Go";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // valuesps
            // 
            this.valuesps.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesps.Location = new System.Drawing.Point(100, 0);
            this.valuesps.Name = "valuesps";
            this.valuesps.Size = new System.Drawing.Size(481, 20);
            this.valuesps.TabIndex = 3;
            this.valuesps.Text = "1 values per movement (1-4)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.content);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox content;
        private System.Windows.Forms.TextBox dimension;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox valuesps;
    }
}

