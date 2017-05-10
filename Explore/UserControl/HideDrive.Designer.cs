namespace Explore.GUI
{
    partial class HideDrive
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxDrive = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUnhideDrive = new System.Windows.Forms.Button();
            this.btnHideDrive = new System.Windows.Forms.Button();
            this.dataGridViewDrive = new System.Windows.Forms.DataGridView();
            this.Drive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediaType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Used = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbPhanTram = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrive)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxDrive);
            this.groupBox5.Location = new System.Drawing.Point(28, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(279, 57);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Drive";
            // 
            // comboBoxDrive
            // 
            this.comboBoxDrive.FormattingEnabled = true;
            this.comboBoxDrive.Location = new System.Drawing.Point(7, 20);
            this.comboBoxDrive.Name = "comboBoxDrive";
            this.comboBoxDrive.Size = new System.Drawing.Size(266, 21);
            this.comboBoxDrive.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.btnUnhideDrive);
            this.groupBox6.Controls.Add(this.btnHideDrive);
            this.groupBox6.Location = new System.Drawing.Point(28, 111);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(279, 72);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Set Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // btnUnhideDrive
            // 
            this.btnUnhideDrive.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUnhideDrive.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnUnhideDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnhideDrive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUnhideDrive.Location = new System.Drawing.Point(144, 19);
            this.btnUnhideDrive.Name = "btnUnhideDrive";
            this.btnUnhideDrive.Size = new System.Drawing.Size(129, 44);
            this.btnUnhideDrive.TabIndex = 0;
            this.btnUnhideDrive.Text = "Unhide Drive";
            this.btnUnhideDrive.UseVisualStyleBackColor = false;
            this.btnUnhideDrive.Click += new System.EventHandler(this.btnUnhideDrive_Click);
            // 
            // btnHideDrive
            // 
            this.btnHideDrive.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnHideDrive.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnHideDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideDrive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHideDrive.Location = new System.Drawing.Point(6, 18);
            this.btnHideDrive.Name = "btnHideDrive";
            this.btnHideDrive.Size = new System.Drawing.Size(121, 45);
            this.btnHideDrive.TabIndex = 1;
            this.btnHideDrive.Text = "Hide Drive";
            this.btnHideDrive.UseVisualStyleBackColor = false;
            this.btnHideDrive.Click += new System.EventHandler(this.btnHideDrive_Click);
            // 
            // dataGridViewDrive
            // 
            this.dataGridViewDrive.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewDrive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewDrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Drive,
            this.MediaType,
            this.Capacity,
            this.Used,
            this.FreeSpace,
            this.Status});
            this.dataGridViewDrive.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewDrive.Name = "dataGridViewDrive";
            this.dataGridViewDrive.ReadOnly = true;
            this.dataGridViewDrive.RowHeadersVisible = false;
            this.dataGridViewDrive.RowTemplate.ReadOnly = true;
            this.dataGridViewDrive.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDrive.Size = new System.Drawing.Size(582, 118);
            this.dataGridViewDrive.TabIndex = 13;
            this.dataGridViewDrive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDrive_CellClick);
            // 
            // Drive
            // 
            this.Drive.DataPropertyName = "Drive";
            this.Drive.HeaderText = "Drive";
            this.Drive.Name = "Drive";
            this.Drive.ReadOnly = true;
            this.Drive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MediaType
            // 
            this.MediaType.DataPropertyName = "MediaType";
            this.MediaType.HeaderText = "Media Type";
            this.MediaType.Name = "MediaType";
            this.MediaType.ReadOnly = true;
            this.MediaType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Capacity
            // 
            this.Capacity.DataPropertyName = "Capacity";
            this.Capacity.HeaderText = "Capacity";
            this.Capacity.Name = "Capacity";
            this.Capacity.ReadOnly = true;
            this.Capacity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Used
            // 
            this.Used.DataPropertyName = "Used";
            this.Used.HeaderText = "Used";
            this.Used.Name = "Used";
            this.Used.ReadOnly = true;
            this.Used.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FreeSpace
            // 
            this.FreeSpace.DataPropertyName = "FreeSpace";
            this.FreeSpace.HeaderText = "FreeSpace";
            this.FreeSpace.Name = "FreeSpace";
            this.FreeSpace.ReadOnly = true;
            this.FreeSpace.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBoxLog);
            this.groupBox7.Location = new System.Drawing.Point(324, 48);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(298, 135);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Log History";
            // 
            // listBoxLog
            // 
            this.listBoxLog.ForeColor = System.Drawing.Color.Blue;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(6, 19);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(286, 108);
            this.listBoxLog.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.progressBar.Location = new System.Drawing.Point(28, 18);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(554, 15);
            this.progressBar.TabIndex = 15;
            // 
            // lbPhanTram
            // 
            this.lbPhanTram.AutoSize = true;
            this.lbPhanTram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhanTram.Location = new System.Drawing.Point(596, 16);
            this.lbPhanTram.Name = "lbPhanTram";
            this.lbPhanTram.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbPhanTram.Size = new System.Drawing.Size(30, 17);
            this.lbPhanTram.TabIndex = 16;
            this.lbPhanTram.Text = "0%";
            this.lbPhanTram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewDrive);
            this.groupBox1.Location = new System.Drawing.Point(28, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 143);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logic Disk";
            // 
            // HideDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbPhanTram);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Name = "HideDrive";
            this.Size = new System.Drawing.Size(652, 346);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrive)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxDrive;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUnhideDrive;
        private System.Windows.Forms.Button btnHideDrive;
        private System.Windows.Forms.DataGridView dataGridViewDrive;

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbPhanTram;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drive;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediaType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Used;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
