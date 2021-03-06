﻿namespace AdvancedSudokuSolver
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
			if(disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_start = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox_liveUpdate = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_elapsed = new System.Windows.Forms.Label();
            this.listBox_history = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_input
            // 
            this.textBox_input.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_input.Location = new System.Drawing.Point(3, 17);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(270, 256);
            this.textBox_input.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox_input, "paste your solveable sudoku in here. Replace all the empty spots with a zero.");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_input);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(296, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 276);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(6, 43);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(267, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.toolTip1.SetToolTip(this.button_start, "Starts the solving process.");
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkBox_liveUpdate
            // 
            this.checkBox_liveUpdate.AutoSize = true;
            this.checkBox_liveUpdate.Location = new System.Drawing.Point(6, 20);
            this.checkBox_liveUpdate.Name = "checkBox_liveUpdate";
            this.checkBox_liveUpdate.Size = new System.Drawing.Size(82, 17);
            this.checkBox_liveUpdate.TabIndex = 1;
            this.checkBox_liveUpdate.Text = "Live update";
            this.toolTip1.SetToolTip(this.checkBox_liveUpdate, "If checked the sudoku will show up ever step. This option increases the total tim" +
        "e a lot.");
            this.checkBox_liveUpdate.UseVisualStyleBackColor = true;
            // 
            // label_elapsed
            // 
            this.label_elapsed.AutoSize = true;
            this.label_elapsed.Location = new System.Drawing.Point(296, 295);
            this.label_elapsed.Name = "label_elapsed";
            this.label_elapsed.Size = new System.Drawing.Size(0, 13);
            this.label_elapsed.TabIndex = 5;
            // 
            // listBox_history
            // 
            this.listBox_history.BackColor = System.Drawing.SystemColors.Control;
            this.listBox_history.FormattingEnabled = true;
            this.listBox_history.HorizontalScrollbar = true;
            this.listBox_history.Location = new System.Drawing.Point(284, 14);
            this.listBox_history.Name = "listBox_history";
            this.listBox_history.Size = new System.Drawing.Size(270, 173);
            this.listBox_history.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_liveUpdate);
            this.groupBox3.Controls.Add(this.listBox_history);
            this.groupBox3.Controls.Add(this.button_start);
            this.groupBox3.Location = new System.Drawing.Point(12, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 204);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 507);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label_elapsed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Advanced Sudoku Solver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_input;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button_start;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.CheckBox checkBox_liveUpdate;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label_elapsed;
		private System.Windows.Forms.ListBox listBox_history;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

