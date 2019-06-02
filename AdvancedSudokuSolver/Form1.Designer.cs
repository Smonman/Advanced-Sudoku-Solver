namespace AdvancedSudokuSolver
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
            this.tabControl_input = new System.Windows.Forms.TabControl();
            this.tabPage_text = new System.Windows.Forms.TabPage();
            this.tabPage_numbers = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_start = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox_liveUpdate = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_elapsed = new System.Windows.Forms.Label();
            this.listBox_history = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tabControl_input.SuspendLayout();
            this.tabPage_text.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_input
            // 
            this.textBox_input.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_input.Location = new System.Drawing.Point(3, 3);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(353, 314);
            this.textBox_input.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox_input, "paste your solveable sudoku in here. Replace all the empty spots with a zero.");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl_input);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // tabControl_input
            // 
            this.tabControl_input.Controls.Add(this.tabPage_text);
            this.tabControl_input.Controls.Add(this.tabPage_numbers);
            this.tabControl_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_input.Location = new System.Drawing.Point(3, 17);
            this.tabControl_input.Name = "tabControl_input";
            this.tabControl_input.SelectedIndex = 0;
            this.tabControl_input.Size = new System.Drawing.Size(367, 346);
            this.tabControl_input.TabIndex = 1;
            this.tabControl_input.SelectedIndexChanged += new System.EventHandler(this.TabControl_input_SelectedIndexChanged);
            // 
            // tabPage_text
            // 
            this.tabPage_text.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_text.Controls.Add(this.textBox_input);
            this.tabPage_text.Location = new System.Drawing.Point(4, 22);
            this.tabPage_text.Name = "tabPage_text";
            this.tabPage_text.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_text.Size = new System.Drawing.Size(359, 320);
            this.tabPage_text.TabIndex = 0;
            this.tabPage_text.Text = "Text";
            // 
            // tabPage_numbers
            // 
            this.tabPage_numbers.Location = new System.Drawing.Point(4, 22);
            this.tabPage_numbers.Name = "tabPage_numbers";
            this.tabPage_numbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_numbers.Size = new System.Drawing.Size(359, 320);
            this.tabPage_numbers.TabIndex = 1;
            this.tabPage_numbers.Text = "Numbers";
            this.tabPage_numbers.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(382, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 366);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(6, 43);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(370, 23);
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
            this.checkBox_liveUpdate.Location = new System.Drawing.Point(9, 17);
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
            this.label_elapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_elapsed.AutoSize = true;
            this.label_elapsed.Location = new System.Drawing.Point(7, 231);
            this.label_elapsed.Name = "label_elapsed";
            this.label_elapsed.Size = new System.Drawing.Size(69, 13);
            this.label_elapsed.TabIndex = 5;
            this.label_elapsed.Text = "Time Elapsed";
            // 
            // listBox_history
            // 
            this.listBox_history.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_history.BackColor = System.Drawing.SystemColors.Control;
            this.listBox_history.FormattingEnabled = true;
            this.listBox_history.HorizontalScrollbar = true;
            this.listBox_history.Location = new System.Drawing.Point(382, 17);
            this.listBox_history.Name = "listBox_history";
            this.listBox_history.Size = new System.Drawing.Size(373, 225);
            this.listBox_history.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_liveUpdate);
            this.groupBox3.Controls.Add(this.label_elapsed);
            this.groupBox3.Controls.Add(this.listBox_history);
            this.groupBox3.Controls.Add(this.button_start);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(758, 247);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 631);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(758, 372);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 631);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(780, 670);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Advanced Sudoku Solver";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.tabControl_input.ResumeLayout(false);
            this.tabPage_text.ResumeLayout(false);
            this.tabPage_text.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControl_input;
        private System.Windows.Forms.TabPage tabPage_text;
        private System.Windows.Forms.TabPage tabPage_numbers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

