namespace PROGRAMMING_ASSIGNMENT_8
{
    partial class timeKeepingLogin
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
            this.employeeName = new System.Windows.Forms.Label();
            this.textBoxEmployeeName = new System.Windows.Forms.TextBox();
            this.textBoxSupervisorName = new System.Windows.Forms.TextBox();
            this.supervisorName = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelWeekNumber = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numericWeekNumber = new System.Windows.Forms.NumericUpDown();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ColumnClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmployeeBillingLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeekendHolidayVacation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeekNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Location = new System.Drawing.Point(26, 16);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(84, 13);
            this.employeeName.TabIndex = 0;
            this.employeeName.Text = "Employee Name";
            // 
            // textBoxEmployeeName
            // 
            this.textBoxEmployeeName.Location = new System.Drawing.Point(117, 8);
            this.textBoxEmployeeName.Name = "textBoxEmployeeName";
            this.textBoxEmployeeName.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmployeeName.TabIndex = 1;
            this.textBoxEmployeeName.TextChanged += new System.EventHandler(this.textBoxEmployeeName_TextChanged);
            // 
            // textBoxSupervisorName
            // 
            this.textBoxSupervisorName.Location = new System.Drawing.Point(117, 34);
            this.textBoxSupervisorName.Name = "textBoxSupervisorName";
            this.textBoxSupervisorName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSupervisorName.TabIndex = 3;
            this.textBoxSupervisorName.TextChanged += new System.EventHandler(this.textBoxSupervisorName_TextChanged);
            // 
            // supervisorName
            // 
            this.supervisorName.AutoSize = true;
            this.supervisorName.Location = new System.Drawing.Point(26, 42);
            this.supervisorName.Name = "supervisorName";
            this.supervisorName.Size = new System.Drawing.Size(88, 13);
            this.supervisorName.TabIndex = 2;
            this.supervisorName.Text = "Supervisor Name";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(421, 354);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(131, 33);
            this.buttonSubmit.TabIndex = 12;
            this.buttonSubmit.Text = "Submit ";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(26, 459);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(115, 13);
            this.labelTotal.TabIndex = 5;
            this.labelTotal.Text = "Payroll information:";
            // 
            // labelWeekNumber
            // 
            this.labelWeekNumber.AutoSize = true;
            this.labelWeekNumber.Location = new System.Drawing.Point(26, 68);
            this.labelWeekNumber.Name = "labelWeekNumber";
            this.labelWeekNumber.Size = new System.Drawing.Size(76, 13);
            this.labelWeekNumber.TabIndex = 6;
            this.labelWeekNumber.Text = "Week Number";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnClient,
            this.ColumnContract,
            this.ColumnProject,
            this.ColumnEmployeeBillingLevel,
            this.ColumnMon,
            this.ColumnTue,
            this.ColumnWed,
            this.ColumnThurs,
            this.ColumnFri,
            this.ColumnSat,
            this.ColumnSun});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(29, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(934, 201);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // numericWeekNumber
            // 
            this.numericWeekNumber.Location = new System.Drawing.Point(117, 60);
            this.numericWeekNumber.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.numericWeekNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWeekNumber.Name = "numericWeekNumber";
            this.numericWeekNumber.Size = new System.Drawing.Size(100, 20);
            this.numericWeekNumber.TabIndex = 9;
            this.numericWeekNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWeekNumber.ValueChanged += new System.EventHandler(this.numericWeekNumber_ValueChanged);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDays,
            this.ColumnTotal,
            this.ColumnWeekendHolidayVacation});
            this.dataGridView3.Location = new System.Drawing.Point(710, 284);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(253, 223);
            this.dataGridView3.TabIndex = 11;
            // 
            // ColumnClient
            // 
            this.ColumnClient.HeaderText = "Client";
            this.ColumnClient.Name = "ColumnClient";
            this.ColumnClient.ReadOnly = true;
            // 
            // ColumnContract
            // 
            this.ColumnContract.HeaderText = "Contract";
            this.ColumnContract.Name = "ColumnContract";
            // 
            // ColumnProject
            // 
            this.ColumnProject.HeaderText = "Project";
            this.ColumnProject.Name = "ColumnProject";
            // 
            // ColumnEmployeeBillingLevel
            // 
            this.ColumnEmployeeBillingLevel.HeaderText = "Employee Billing Level";
            this.ColumnEmployeeBillingLevel.Name = "ColumnEmployeeBillingLevel";
            // 
            // ColumnMon
            // 
            this.ColumnMon.HeaderText = "Monday";
            this.ColumnMon.Name = "ColumnMon";
            this.ColumnMon.Width = 70;
            // 
            // ColumnTue
            // 
            this.ColumnTue.HeaderText = "Tuesday";
            this.ColumnTue.Name = "ColumnTue";
            this.ColumnTue.Width = 70;
            // 
            // ColumnWed
            // 
            this.ColumnWed.HeaderText = "Wednesday";
            this.ColumnWed.Name = "ColumnWed";
            this.ColumnWed.Width = 70;
            // 
            // ColumnThurs
            // 
            this.ColumnThurs.HeaderText = "Thursday";
            this.ColumnThurs.Name = "ColumnThurs";
            this.ColumnThurs.Width = 70;
            // 
            // ColumnFri
            // 
            this.ColumnFri.HeaderText = "Friday";
            this.ColumnFri.Name = "ColumnFri";
            this.ColumnFri.Width = 70;
            // 
            // ColumnSat
            // 
            this.ColumnSat.HeaderText = "Saturday";
            this.ColumnSat.Name = "ColumnSat";
            this.ColumnSat.Width = 70;
            // 
            // ColumnSun
            // 
            this.ColumnSun.HeaderText = "Sunday";
            this.ColumnSun.Name = "ColumnSun";
            this.ColumnSun.Width = 70;
            // 
            // ColumnDays
            // 
            this.ColumnDays.HeaderText = "Day";
            this.ColumnDays.Name = "ColumnDays";
            this.ColumnDays.ReadOnly = true;
            this.ColumnDays.Width = 70;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.HeaderText = "Total";
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            this.ColumnTotal.Width = 70;
            // 
            // ColumnWeekendHolidayVacation
            // 
            this.ColumnWeekendHolidayVacation.HeaderText = "weekend holiday vacation";
            this.ColumnWeekendHolidayVacation.Name = "ColumnWeekendHolidayVacation";
            this.ColumnWeekendHolidayVacation.Width = 70;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(29, 476);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(675, 256);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // timeKeepingLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 744);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.numericWeekNumber);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelWeekNumber);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxSupervisorName);
            this.Controls.Add(this.supervisorName);
            this.Controls.Add(this.textBoxEmployeeName);
            this.Controls.Add(this.employeeName);
            this.Name = "timeKeepingLogin";
            this.Text = "Timekeeping";
            this.Load += new System.EventHandler(this.timeKeepingLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeekNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.TextBox textBoxEmployeeName;
        private System.Windows.Forms.TextBox textBoxSupervisorName;
        private System.Windows.Forms.Label supervisorName;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelWeekNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericWeekNumber;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmployeeBillingLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFri;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnWeekendHolidayVacation;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

