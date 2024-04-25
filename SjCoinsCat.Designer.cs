namespace SjCoins撸猫
{
    partial class SjCoinsCat
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
            this.btnPic = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rb = new System.Windows.Forms.RichTextBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPic
            // 
            this.btnPic.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPic.Location = new System.Drawing.Point(124, 15);
            this.btnPic.Margin = new System.Windows.Forms.Padding(2);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(71, 35);
            this.btnPic.TabIndex = 7;
            this.btnPic.Text = "自动撸猫";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Visible = false;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(22, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始撸猫";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb
            // 
            this.rb.Location = new System.Drawing.Point(22, 55);
            this.rb.Name = "rb";
            this.rb.Size = new System.Drawing.Size(332, 226);
            this.rb.TabIndex = 8;
            this.rb.Text = "";
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(236, 21);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 9;
            this.bt_start.Text = "打开游戏";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // SjCoinsCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 306);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.rb);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "SjCoinsCat";
            this.Text = "Catizen自动撸猫    v1.0.0.0";
            this.Load += new System.EventHandler(this.SjCoinsCat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rb;
        private System.Windows.Forms.Button bt_start;
    }
}