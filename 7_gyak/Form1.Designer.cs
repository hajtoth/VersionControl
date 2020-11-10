namespace _7_gyak
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
            this.endyear_lbl = new System.Windows.Forms.Label();
            this.endyear_nUD = new System.Windows.Forms.NumericUpDown();
            this.population_lbl = new System.Windows.Forms.Label();
            this.population_txt = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.result_txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.endyear_nUD)).BeginInit();
            this.SuspendLayout();
            // 
            // endyear_lbl
            // 
            this.endyear_lbl.AutoSize = true;
            this.endyear_lbl.Location = new System.Drawing.Point(5, 12);
            this.endyear_lbl.Name = "endyear_lbl";
            this.endyear_lbl.Size = new System.Drawing.Size(58, 20);
            this.endyear_lbl.TabIndex = 0;
            this.endyear_lbl.Text = "Záróév";
            // 
            // endyear_nUD
            // 
            this.endyear_nUD.Location = new System.Drawing.Point(88, 12);
            this.endyear_nUD.Maximum = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.endyear_nUD.Minimum = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.endyear_nUD.Name = "endyear_nUD";
            this.endyear_nUD.Size = new System.Drawing.Size(120, 26);
            this.endyear_nUD.TabIndex = 1;
            this.endyear_nUD.Value = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            // 
            // population_lbl
            // 
            this.population_lbl.AutoSize = true;
            this.population_lbl.Location = new System.Drawing.Point(225, 12);
            this.population_lbl.Name = "population_lbl";
            this.population_lbl.Size = new System.Drawing.Size(105, 20);
            this.population_lbl.TabIndex = 2;
            this.population_lbl.Text = "Népesség fájl";
            // 
            // population_txt
            // 
            this.population_txt.Location = new System.Drawing.Point(341, 12);
            this.population_txt.Name = "population_txt";
            this.population_txt.Size = new System.Drawing.Size(100, 26);
            this.population_txt.TabIndex = 3;
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(484, 6);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 35);
            this.browse_btn.TabIndex = 4;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(591, 6);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 35);
            this.start_btn.TabIndex = 5;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            // 
            // result_txt
            // 
            this.result_txt.Location = new System.Drawing.Point(4, 47);
            this.result_txt.Multiline = true;
            this.result_txt.Name = "result_txt";
            this.result_txt.Size = new System.Drawing.Size(734, 172);
            this.result_txt.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 281);
            this.Controls.Add(this.result_txt);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.population_txt);
            this.Controls.Add(this.population_lbl);
            this.Controls.Add(this.endyear_nUD);
            this.Controls.Add(this.endyear_lbl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.endyear_nUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label endyear_lbl;
        private System.Windows.Forms.NumericUpDown endyear_nUD;
        private System.Windows.Forms.Label population_lbl;
        private System.Windows.Forms.TextBox population_txt;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.TextBox result_txt;
    }
}

