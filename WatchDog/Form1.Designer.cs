namespace WatchDog
{
    partial class Frm
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
            this.lb_BytesReceivedPerSec = new System.Windows.Forms.Label();
            this.lb_BytesReceivedAvg = new System.Windows.Forms.Label();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_threshold = new System.Windows.Forms.TextBox();
            this.lb_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_BytesReceivedPerSec
            // 
            this.lb_BytesReceivedPerSec.AutoSize = true;
            this.lb_BytesReceivedPerSec.Location = new System.Drawing.Point(20, 20);
            this.lb_BytesReceivedPerSec.Name = "lb_BytesReceivedPerSec";
            this.lb_BytesReceivedPerSec.Size = new System.Drawing.Size(117, 12);
            this.lb_BytesReceivedPerSec.TabIndex = 0;
            this.lb_BytesReceivedPerSec.Text = "BytesReceivedPerSec：";
            // 
            // lb_BytesReceivedAvg
            // 
            this.lb_BytesReceivedAvg.AutoSize = true;
            this.lb_BytesReceivedAvg.Location = new System.Drawing.Point(20, 45);
            this.lb_BytesReceivedAvg.Name = "lb_BytesReceivedAvg";
            this.lb_BytesReceivedAvg.Size = new System.Drawing.Size(106, 12);
            this.lb_BytesReceivedAvg.TabIndex = 0;
            this.lb_BytesReceivedAvg.Text = "BytesReceivedAvg：";
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(20, 126);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(345, 336);
            this.tb_log.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Threshold：";
            // 
            // tb_threshold
            // 
            this.tb_threshold.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tb_threshold.Location = new System.Drawing.Point(85, 94);
            this.tb_threshold.MaxLength = 10;
            this.tb_threshold.Name = "tb_threshold";
            this.tb_threshold.Size = new System.Drawing.Size(99, 22);
            this.tb_threshold.TabIndex = 2;
            this.tb_threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_threshold_KeyPress);
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.Location = new System.Drawing.Point(21, 75);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(44, 12);
            this.lb_Status.TabIndex = 0;
            this.lb_Status.Text = "Status：";
            // 
            // Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 473);
            this.Controls.Add(this.tb_threshold);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Status);
            this.Controls.Add(this.lb_BytesReceivedAvg);
            this.Controls.Add(this.lb_BytesReceivedPerSec);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qBittorrent Watch Dog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_BytesReceivedPerSec;
        private System.Windows.Forms.Label lb_BytesReceivedAvg;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_threshold;
        private System.Windows.Forms.Label lb_Status;
    }
}

