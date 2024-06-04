namespace Nova_UI
{
    partial class Nova_UI
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.max_y_bar = new System.Windows.Forms.TrackBar();
            this.max_x_bar = new System.Windows.Forms.TrackBar();
            this.max_y = new System.Windows.Forms.TextBox();
            this.max_x = new System.Windows.Forms.TextBox();
            this.min_x = new System.Windows.Forms.TextBox();
            this.min_y = new System.Windows.Forms.TextBox();
            this.min_x_bar = new System.Windows.Forms.TrackBar();
            this.min_y_bar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_y_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_x_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_x_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_y_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(623, 896);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 31);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(749, 899);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 28);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(298, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1310, 807);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // max_y_bar
            // 
            this.max_y_bar.Location = new System.Drawing.Point(95, 349);
            this.max_y_bar.Maximum = 100;
            this.max_y_bar.Name = "max_y_bar";
            this.max_y_bar.Size = new System.Drawing.Size(172, 45);
            this.max_y_bar.TabIndex = 4;
            this.max_y_bar.Value = 10;
            this.max_y_bar.ValueChanged += new System.EventHandler(this.max_y_bar_ValueChanged);
            // 
            // max_x_bar
            // 
            this.max_x_bar.Location = new System.Drawing.Point(95, 280);
            this.max_x_bar.Maximum = 100;
            this.max_x_bar.Name = "max_x_bar";
            this.max_x_bar.Size = new System.Drawing.Size(172, 45);
            this.max_x_bar.TabIndex = 5;
            this.max_x_bar.Value = 20;
            this.max_x_bar.ValueChanged += new System.EventHandler(this.max_x_bar_ValueChanged);
            // 
            // max_y
            // 
            this.max_y.BackColor = System.Drawing.SystemColors.Menu;
            this.max_y.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.max_y.Location = new System.Drawing.Point(25, 361);
            this.max_y.Name = "max_y";
            this.max_y.Size = new System.Drawing.Size(64, 14);
            this.max_y.TabIndex = 6;
            this.max_y.Text = "max_y";
            // 
            // max_x
            // 
            this.max_x.BackColor = System.Drawing.SystemColors.Menu;
            this.max_x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.max_x.Location = new System.Drawing.Point(25, 293);
            this.max_x.Name = "max_x";
            this.max_x.Size = new System.Drawing.Size(60, 14);
            this.max_x.TabIndex = 7;
            this.max_x.Text = "max_x";
            // 
            // min_x
            // 
            this.min_x.BackColor = System.Drawing.SystemColors.Menu;
            this.min_x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.min_x.Location = new System.Drawing.Point(25, 91);
            this.min_x.Name = "min_x";
            this.min_x.Size = new System.Drawing.Size(64, 14);
            this.min_x.TabIndex = 8;
            this.min_x.Text = "min_x";
            // 
            // min_y
            // 
            this.min_y.BackColor = System.Drawing.SystemColors.Menu;
            this.min_y.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.min_y.Location = new System.Drawing.Point(25, 161);
            this.min_y.Name = "min_y";
            this.min_y.Size = new System.Drawing.Size(60, 14);
            this.min_y.TabIndex = 9;
            this.min_y.Text = "min_y";
            // 
            // min_x_bar
            // 
            this.min_x_bar.Location = new System.Drawing.Point(95, 91);
            this.min_x_bar.Maximum = 100;
            this.min_x_bar.Minimum = -10;
            this.min_x_bar.Name = "min_x_bar";
            this.min_x_bar.Size = new System.Drawing.Size(172, 45);
            this.min_x_bar.TabIndex = 10;
            this.min_x_bar.Value = -1;
            this.min_x_bar.ValueChanged += new System.EventHandler(this.min_x_bar_ValueChanged);
            // 
            // min_y_bar
            // 
            this.min_y_bar.Location = new System.Drawing.Point(95, 142);
            this.min_y_bar.Maximum = 100;
            this.min_y_bar.Minimum = -10;
            this.min_y_bar.Name = "min_y_bar";
            this.min_y_bar.Size = new System.Drawing.Size(172, 45);
            this.min_y_bar.TabIndex = 11;
            this.min_y_bar.Value = -1;
            this.min_y_bar.ValueChanged += new System.EventHandler(this.min_y_bar_ValueChanged);
            // 
            // Nova_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 939);
            this.Controls.Add(this.min_y_bar);
            this.Controls.Add(this.min_x_bar);
            this.Controls.Add(this.min_y);
            this.Controls.Add(this.min_x);
            this.Controls.Add(this.max_x);
            this.Controls.Add(this.max_y);
            this.Controls.Add(this.max_x_bar);
            this.Controls.Add(this.max_y_bar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Nova_UI";
            this.Text = "Nova_UI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Nova_UI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_y_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_x_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_x_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_y_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar max_y_bar;
        private System.Windows.Forms.TrackBar max_x_bar;
        private System.Windows.Forms.TextBox max_y;
        private System.Windows.Forms.TextBox max_x;
        private System.Windows.Forms.TextBox min_x;
        private System.Windows.Forms.TextBox min_y;
        private System.Windows.Forms.TrackBar min_x_bar;
        private System.Windows.Forms.TrackBar min_y_bar;
    }
}

