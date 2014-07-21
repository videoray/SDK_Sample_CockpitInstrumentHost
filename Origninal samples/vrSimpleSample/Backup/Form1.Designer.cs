namespace vrSimpleSample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.DepthLabel = new System.Windows.Forms.Label();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.PitchLabel = new System.Windows.Forms.Label();
            this.VerticalControl = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.VerticalThrustLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StarboardThrusterLabel = new System.Windows.Forms.Label();
            this.PortThrusterLabel = new System.Windows.Forms.Label();
            this.PortThrusterControl = new System.Windows.Forms.TrackBar();
            this.RollLabel = new System.Windows.Forms.Label();
            this.StarboardThrusterControl = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortThrusterControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StarboardThrusterControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // DepthLabel
            // 
            this.DepthLabel.AutoSize = true;
            this.DepthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepthLabel.Location = new System.Drawing.Point(15, 11);
            this.DepthLabel.Name = "DepthLabel";
            this.DepthLabel.Size = new System.Drawing.Size(138, 37);
            this.DepthLabel.TabIndex = 1;
            this.DepthLabel.Text = "Depth: 0";
            this.DepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.AutoSize = true;
            this.HeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingLabel.Location = new System.Drawing.Point(15, 135);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(172, 37);
            this.HeadingLabel.TabIndex = 2;
            this.HeadingLabel.Text = "Heading: 0";
            this.HeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PitchLabel
            // 
            this.PitchLabel.AutoSize = true;
            this.PitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PitchLabel.Location = new System.Drawing.Point(15, 61);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(124, 37);
            this.PitchLabel.TabIndex = 3;
            this.PitchLabel.Text = "Pitch: 0";
            this.PitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VerticalControl
            // 
            this.VerticalControl.Location = new System.Drawing.Point(217, 215);
            this.VerticalControl.Maximum = 100;
            this.VerticalControl.Minimum = -100;
            this.VerticalControl.Name = "VerticalControl";
            this.VerticalControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VerticalControl.Size = new System.Drawing.Size(45, 197);
            this.VerticalControl.TabIndex = 5;
            this.VerticalControl.TickFrequency = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vertical Thruster Control";
            // 
            // VerticalThrustLabel
            // 
            this.VerticalThrustLabel.AutoSize = true;
            this.VerticalThrustLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerticalThrustLabel.Location = new System.Drawing.Point(268, 301);
            this.VerticalThrustLabel.Name = "VerticalThrustLabel";
            this.VerticalThrustLabel.Size = new System.Drawing.Size(24, 25);
            this.VerticalThrustLabel.TabIndex = 7;
            this.VerticalThrustLabel.Text = "0";
            this.VerticalThrustLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Horizontal Thruster Control";
            // 
            // StarboardThrusterLabel
            // 
            this.StarboardThrusterLabel.AutoSize = true;
            this.StarboardThrusterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StarboardThrusterLabel.Location = new System.Drawing.Point(158, 301);
            this.StarboardThrusterLabel.Name = "StarboardThrusterLabel";
            this.StarboardThrusterLabel.Size = new System.Drawing.Size(24, 25);
            this.StarboardThrusterLabel.TabIndex = 9;
            this.StarboardThrusterLabel.Text = "0";
            this.StarboardThrusterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortThrusterLabel
            // 
            this.PortThrusterLabel.AutoSize = true;
            this.PortThrusterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortThrusterLabel.Location = new System.Drawing.Point(63, 301);
            this.PortThrusterLabel.Name = "PortThrusterLabel";
            this.PortThrusterLabel.Size = new System.Drawing.Size(24, 25);
            this.PortThrusterLabel.TabIndex = 10;
            this.PortThrusterLabel.Text = "0";
            this.PortThrusterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortThrusterControl
            // 
            this.PortThrusterControl.Location = new System.Drawing.Point(22, 215);
            this.PortThrusterControl.Maximum = 100;
            this.PortThrusterControl.Minimum = -100;
            this.PortThrusterControl.Name = "PortThrusterControl";
            this.PortThrusterControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.PortThrusterControl.Size = new System.Drawing.Size(45, 191);
            this.PortThrusterControl.TabIndex = 11;
            this.PortThrusterControl.TickFrequency = 5;
            // 
            // RollLabel
            // 
            this.RollLabel.AutoSize = true;
            this.RollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollLabel.Location = new System.Drawing.Point(15, 98);
            this.RollLabel.Name = "RollLabel";
            this.RollLabel.Size = new System.Drawing.Size(107, 37);
            this.RollLabel.TabIndex = 4;
            this.RollLabel.Text = "Roll: 0";
            this.RollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StarboardThrusterControl
            // 
            this.StarboardThrusterControl.Location = new System.Drawing.Point(117, 215);
            this.StarboardThrusterControl.Maximum = 100;
            this.StarboardThrusterControl.Minimum = -100;
            this.StarboardThrusterControl.Name = "StarboardThrusterControl";
            this.StarboardThrusterControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.StarboardThrusterControl.Size = new System.Drawing.Size(45, 191);
            this.StarboardThrusterControl.TabIndex = 12;
            this.StarboardThrusterControl.TickFrequency = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Starboard";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 506);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StarboardThrusterControl);
            this.Controls.Add(this.PortThrusterControl);
            this.Controls.Add(this.PortThrusterLabel);
            this.Controls.Add(this.StarboardThrusterLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VerticalThrustLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VerticalControl);
            this.Controls.Add(this.RollLabel);
            this.Controls.Add(this.PitchLabel);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.DepthLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SimpleSample";
            ((System.ComponentModel.ISupportInitialize)(this.VerticalControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortThrusterControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StarboardThrusterControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DepthLabel;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.TrackBar VerticalControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label VerticalThrustLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StarboardThrusterLabel;
        private System.Windows.Forms.Label PortThrusterLabel;
        private System.Windows.Forms.TrackBar PortThrusterControl;
        private System.Windows.Forms.Label RollLabel;
        private System.Windows.Forms.TrackBar StarboardThrusterControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

