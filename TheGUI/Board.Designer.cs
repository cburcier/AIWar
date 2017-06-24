namespace TheGUI
{
    partial class Board
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
            this.ControlsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.BoardPicture = new System.Windows.Forms.PictureBox();
            this.ControlsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlsLayout
            // 
            this.ControlsLayout.Controls.Add(this.btnRun);
            this.ControlsLayout.Controls.Add(this.btnPause);
            this.ControlsLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ControlsLayout.Location = new System.Drawing.Point(0, 0);
            this.ControlsLayout.Name = "ControlsLayout";
            this.ControlsLayout.Size = new System.Drawing.Size(200, 483);
            this.ControlsLayout.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(3, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 54);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(3, 63);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 49);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // BoardPicture
            // 
            this.BoardPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardPicture.Location = new System.Drawing.Point(200, 0);
            this.BoardPicture.Name = "BoardPicture";
            this.BoardPicture.Size = new System.Drawing.Size(1062, 483);
            this.BoardPicture.TabIndex = 1;
            this.BoardPicture.TabStop = false;
            this.BoardPicture.SizeChanged += new System.EventHandler(this.BoardPicture_SizeChanged);
            this.BoardPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPicture_Paint);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 483);
            this.Controls.Add(this.BoardPicture);
            this.Controls.Add(this.ControlsLayout);
            this.Name = "Board";
            this.Text = "BoardControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Board_FormClosing);
            this.ControlsLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BoardPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ControlsLayout;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.PictureBox BoardPicture;
    }
}

