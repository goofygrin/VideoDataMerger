namespace VideoDataMerger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.slider = new System.Windows.Forms.TrackBar();
            this.txtStartFrame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndFrame = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentFrame = new System.Windows.Forms.Label();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.lblCurrentPoint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndPoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartPoint = new System.Windows.Forms.TextBox();
            this.mapSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblLatG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLongG = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.aviFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.csvFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnChooseVideo = new System.Windows.Forms.Button();
            this.btnChooseGPS = new System.Windows.Forms.Button();
            this.lblVideoFileName = new System.Windows.Forms.Label();
            this.lblGPSFile = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.pbSource ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.slider ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.pbMap ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.mapSlider ) ).BeginInit();
            this.SuspendLayout();
            // 
            // pbSource
            // 
            this.pbSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSource.Location = new System.Drawing.Point( 12, 35 );
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size( 320, 240 );
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // slider
            // 
            this.slider.Location = new System.Drawing.Point( 12, 281 );
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size( 320, 45 );
            this.slider.TabIndex = 1;
            this.slider.Scroll += new System.EventHandler( this.slider_Scroll );
            // 
            // txtStartFrame
            // 
            this.txtStartFrame.Location = new System.Drawing.Point( 12, 332 );
            this.txtStartFrame.Name = "txtStartFrame";
            this.txtStartFrame.Size = new System.Drawing.Size( 100, 20 );
            this.txtStartFrame.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point( 12, 313 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 61, 13 );
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Frame";
            this.label1.Click += new System.EventHandler( this.label1_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Location = new System.Drawing.Point( 232, 313 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 58, 13 );
            this.label2.TabIndex = 5;
            this.label2.Text = "End Frame";
            this.label2.Click += new System.EventHandler( this.label2_Click );
            // 
            // txtEndFrame
            // 
            this.txtEndFrame.Location = new System.Drawing.Point( 232, 332 );
            this.txtEndFrame.Name = "txtEndFrame";
            this.txtEndFrame.Size = new System.Drawing.Size( 100, 20 );
            this.txtEndFrame.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 139, 313 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 73, 13 );
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Frame";
            // 
            // lblCurrentFrame
            // 
            this.lblCurrentFrame.AutoSize = true;
            this.lblCurrentFrame.Location = new System.Drawing.Point( 139, 332 );
            this.lblCurrentFrame.Name = "lblCurrentFrame";
            this.lblCurrentFrame.Size = new System.Drawing.Size( 13, 13 );
            this.lblCurrentFrame.TabIndex = 7;
            this.lblCurrentFrame.Text = "0";
            // 
            // pbMap
            // 
            this.pbMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMap.Location = new System.Drawing.Point( 383, 35 );
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size( 320, 240 );
            this.pbMap.TabIndex = 8;
            this.pbMap.TabStop = false;
            // 
            // lblCurrentPoint
            // 
            this.lblCurrentPoint.AutoSize = true;
            this.lblCurrentPoint.Location = new System.Drawing.Point( 510, 332 );
            this.lblCurrentPoint.Name = "lblCurrentPoint";
            this.lblCurrentPoint.Size = new System.Drawing.Size( 13, 13 );
            this.lblCurrentPoint.TabIndex = 15;
            this.lblCurrentPoint.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 510, 313 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 68, 13 );
            this.label5.TabIndex = 14;
            this.label5.Text = "Current Point";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point( 603, 313 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 53, 13 );
            this.label6.TabIndex = 13;
            this.label6.Text = "End Point";
            this.label6.Click += new System.EventHandler( this.label6_Click );
            // 
            // txtEndPoint
            // 
            this.txtEndPoint.Location = new System.Drawing.Point( 603, 332 );
            this.txtEndPoint.Name = "txtEndPoint";
            this.txtEndPoint.Size = new System.Drawing.Size( 100, 20 );
            this.txtEndPoint.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point( 383, 313 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 56, 13 );
            this.label7.TabIndex = 11;
            this.label7.Text = "Start Point";
            this.label7.Click += new System.EventHandler( this.label7_Click );
            // 
            // txtStartPoint
            // 
            this.txtStartPoint.Location = new System.Drawing.Point( 383, 332 );
            this.txtStartPoint.Name = "txtStartPoint";
            this.txtStartPoint.Size = new System.Drawing.Size( 100, 20 );
            this.txtStartPoint.TabIndex = 10;
            // 
            // mapSlider
            // 
            this.mapSlider.Location = new System.Drawing.Point( 383, 281 );
            this.mapSlider.Name = "mapSlider";
            this.mapSlider.Size = new System.Drawing.Size( 320, 45 );
            this.mapSlider.TabIndex = 9;
            this.mapSlider.Scroll += new System.EventHandler( this.mapSlider_Scroll );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 709, 61 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 38, 13 );
            this.label4.TabIndex = 16;
            this.label4.Text = "Speed";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point( 709, 74 );
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size( 13, 13 );
            this.lblSpeed.TabIndex = 17;
            this.lblSpeed.Text = "0";
            // 
            // lblLatG
            // 
            this.lblLatG.AutoSize = true;
            this.lblLatG.Location = new System.Drawing.Point( 708, 100 );
            this.lblLatG.Name = "lblLatG";
            this.lblLatG.Size = new System.Drawing.Size( 13, 13 );
            this.lblLatG.TabIndex = 19;
            this.lblLatG.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point( 708, 87 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 33, 13 );
            this.label9.TabIndex = 18;
            this.label9.Text = "Lat G";
            // 
            // lblLongG
            // 
            this.lblLongG.AutoSize = true;
            this.lblLongG.Location = new System.Drawing.Point( 709, 126 );
            this.lblLongG.Name = "lblLongG";
            this.lblLongG.Size = new System.Drawing.Size( 13, 13 );
            this.lblLongG.TabIndex = 21;
            this.lblLongG.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point( 709, 113 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 42, 13 );
            this.label10.TabIndex = 20;
            this.label10.Text = "Long G";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point( 709, 48 );
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size( 13, 13 );
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point( 709, 35 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 30, 13 );
            this.label11.TabIndex = 22;
            this.label11.Text = "Time";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point( 322, 364 );
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size( 75, 23 );
            this.btnMerge.TabIndex = 24;
            this.btnMerge.Text = "Go";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler( this.btnMerge_Click );
            // 
            // aviFileDialog
            // 
            this.aviFileDialog.DefaultExt = "*.avi";
            this.aviFileDialog.Filter = "AVI Files|*.avi";
            // 
            // csvFileDialog
            // 
            this.csvFileDialog.Filter = "CSV Files|*.csv";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 12, 13 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 37, 13 );
            this.label8.TabIndex = 25;
            this.label8.Text = "Video:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point( 383, 13 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 58, 13 );
            this.label12.TabIndex = 26;
            this.label12.Text = "GPS Data:";
            // 
            // btnChooseVideo
            // 
            this.btnChooseVideo.Location = new System.Drawing.Point( 55, 8 );
            this.btnChooseVideo.Name = "btnChooseVideo";
            this.btnChooseVideo.Size = new System.Drawing.Size( 52, 23 );
            this.btnChooseVideo.TabIndex = 27;
            this.btnChooseVideo.Text = "Choose";
            this.btnChooseVideo.UseVisualStyleBackColor = true;
            this.btnChooseVideo.Click += new System.EventHandler( this.btnChooseVideo_Click );
            // 
            // btnChooseGPS
            // 
            this.btnChooseGPS.Location = new System.Drawing.Point( 447, 8 );
            this.btnChooseGPS.Name = "btnChooseGPS";
            this.btnChooseGPS.Size = new System.Drawing.Size( 52, 23 );
            this.btnChooseGPS.TabIndex = 28;
            this.btnChooseGPS.Text = "Choose";
            this.btnChooseGPS.UseVisualStyleBackColor = true;
            this.btnChooseGPS.Click += new System.EventHandler( this.btnChooseGPS_Click );
            // 
            // lblVideoFileName
            // 
            this.lblVideoFileName.AutoSize = true;
            this.lblVideoFileName.Location = new System.Drawing.Point( 114, 13 );
            this.lblVideoFileName.Name = "lblVideoFileName";
            this.lblVideoFileName.Size = new System.Drawing.Size( 80, 13 );
            this.lblVideoFileName.TabIndex = 29;
            this.lblVideoFileName.Text = "No file selected";
            // 
            // lblGPSFile
            // 
            this.lblGPSFile.AutoSize = true;
            this.lblGPSFile.Location = new System.Drawing.Point( 505, 13 );
            this.lblGPSFile.Name = "lblGPSFile";
            this.lblGPSFile.Size = new System.Drawing.Size( 80, 13 );
            this.lblGPSFile.TabIndex = 31;
            this.lblGPSFile.Text = "No file selected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 770, 399 );
            this.Controls.Add( this.lblGPSFile );
            this.Controls.Add( this.lblVideoFileName );
            this.Controls.Add( this.btnChooseGPS );
            this.Controls.Add( this.btnChooseVideo );
            this.Controls.Add( this.label12 );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.btnMerge );
            this.Controls.Add( this.lblTime );
            this.Controls.Add( this.label11 );
            this.Controls.Add( this.lblLongG );
            this.Controls.Add( this.label10 );
            this.Controls.Add( this.lblLatG );
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.lblSpeed );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.lblCurrentPoint );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.txtEndPoint );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.txtStartPoint );
            this.Controls.Add( this.mapSlider );
            this.Controls.Add( this.pbMap );
            this.Controls.Add( this.lblCurrentFrame );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.txtEndFrame );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.txtStartFrame );
            this.Controls.Add( this.slider );
            this.Controls.Add( this.pbSource );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Video & GPS Merger";
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.pbSource ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.slider ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.pbMap ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.mapSlider ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.TextBox txtStartFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentFrame;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Label lblCurrentPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartPoint;
        private System.Windows.Forms.TrackBar mapSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblLatG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLongG;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.OpenFileDialog aviFileDialog;
        private System.Windows.Forms.OpenFileDialog csvFileDialog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnChooseVideo;
        private System.Windows.Forms.Button btnChooseGPS;
        private System.Windows.Forms.Label lblVideoFileName;
        private System.Windows.Forms.Label lblGPSFile;
    }
}