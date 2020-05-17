namespace FaceDetection
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHaar = new System.Windows.Forms.Button();
            this.picCamer = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCNN = new System.Windows.Forms.Button();
            this.btnLbp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCamer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHaar
            // 
            this.btnHaar.Location = new System.Drawing.Point(36, 67);
            this.btnHaar.Name = "btnHaar";
            this.btnHaar.Size = new System.Drawing.Size(97, 23);
            this.btnHaar.TabIndex = 1;
            this.btnHaar.Text = "Haar人脸识别";
            this.btnHaar.UseVisualStyleBackColor = true;
            this.btnHaar.Click += new System.EventHandler(this.OnHaarFaceDetection);
            // 
            // picCamer
            // 
            this.picCamer.Location = new System.Drawing.Point(6, 20);
            this.picCamer.Name = "picCamer";
            this.picCamer.Size = new System.Drawing.Size(560, 479);
            this.picCamer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCamer.TabIndex = 1;
            this.picCamer.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picCamer);
            this.groupBox1.Location = new System.Drawing.Point(192, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 509);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "视频区域";
            // 
            // btnCNN
            // 
            this.btnCNN.Location = new System.Drawing.Point(36, 21);
            this.btnCNN.Name = "btnCNN";
            this.btnCNN.Size = new System.Drawing.Size(97, 23);
            this.btnCNN.TabIndex = 0;
            this.btnCNN.Text = "CNN人脸识别";
            this.btnCNN.UseVisualStyleBackColor = true;
            this.btnCNN.Click += new System.EventHandler(this.OnCNNFaceDetection);
            // 
            // btnLbp
            // 
            this.btnLbp.Location = new System.Drawing.Point(36, 108);
            this.btnLbp.Name = "btnLbp";
            this.btnLbp.Size = new System.Drawing.Size(97, 23);
            this.btnLbp.TabIndex = 2;
            this.btnLbp.Text = "Lbp人脸识别";
            this.btnLbp.UseVisualStyleBackColor = true;
            this.btnLbp.Click += new System.EventHandler(this.OnLbpFaceDetection);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnLbp);
            this.Controls.Add(this.btnCNN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHaar);
            this.Name = "FrmMain";
            this.Text = "人脸识别";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picCamer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHaar;
        private System.Windows.Forms.PictureBox picCamer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCNN;
        private System.Windows.Forms.Button btnLbp;
    }
}

