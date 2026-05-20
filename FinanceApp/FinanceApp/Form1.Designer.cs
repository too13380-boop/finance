namespace FinanceApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            filterGroup = new GroupBox();
            cmbFilterType = new ComboBox();
            txtFilterCategory = new TextBox();
            dtpFilterFrom = new DateTimePicker();
            dtpFilterTo = new DateTimePicker();
            chkNoDateFilter = new CheckBox();
            btnApplyFilter = new Button();
            btnResetFilter = new Button();
            statsGroup = new GroupBox();
            lblBalance = new Label();
            lblIncome = new Label();
            lblExpense = new Label();
            lblCount = new Label();
            dgvTransactions = new DataGridView();
            inputGroup = new GroupBox();
            lblDate = new Label();
            txtDate = new TextBox();
            lblType = new Label();
            cmbType = new ComboBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            lblDesc = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            filterGroup.SuspendLayout();
            statsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            inputGroup.SuspendLayout();
            SuspendLayout();
            // 
            // filterGroup
            // 
            filterGroup.Controls.Add(cmbFilterType);
            filterGroup.Controls.Add(txtFilterCategory);
            filterGroup.Controls.Add(dtpFilterFrom);
            filterGroup.Controls.Add(dtpFilterTo);
            filterGroup.Controls.Add(chkNoDateFilter);
            filterGroup.Controls.Add(btnApplyFilter);
            filterGroup.Controls.Add(btnResetFilter);
            filterGroup.Location = new Point(10, 10);
            filterGroup.Name = "filterGroup";
            filterGroup.Size = new Size(960, 100);
            filterGroup.TabIndex = 0;
            filterGroup.TabStop = false;
            filterGroup.Text = "Фильтры";
            // 
            // cmbFilterType
            // 
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.Items.AddRange(new object[] { "Все", "Доход", "Расход" });
            cmbFilterType.Location = new Point(60, 25);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(100, 23);
            cmbFilterType.TabIndex = 0;
            cmbFilterType.SelectedIndex = 0;
            // 
            // txtFilterCategory
            // 
            txtFilterCategory.Location = new Point(250, 25);
            txtFilterCategory.Name = "txtFilterCategory";
            txtFilterCategory.Size = new Size(150, 23);
            txtFilterCategory.TabIndex = 1;
            // 
            // dtpFilterFrom
            // 
            dtpFilterFrom.Format = DateTimePickerFormat.Short;
            dtpFilterFrom.Location = new Point(500, 25);
            dtpFilterFrom.Name = "dtpFilterFrom";
            dtpFilterFrom.Size = new Size(100, 23);
            dtpFilterFrom.TabIndex = 2;
            // 
            // dtpFilterTo
            // 
            dtpFilterTo.Format = DateTimePickerFormat.Short;
            dtpFilterTo.Location = new Point(680, 25);
            dtpFilterTo.Name = "dtpFilterTo";
            dtpFilterTo.Size = new Size(100, 23);
            dtpFilterTo.TabIndex = 3;
            // 
            // chkNoDateFilter
            // 
            chkNoDateFilter.AutoSize = true;
            chkNoDateFilter.Checked = true;
            chkNoDateFilter.CheckState = CheckState.Checked;
            chkNoDateFilter.Location = new Point(800, 27);
            chkNoDateFilter.Name = "chkNoDateFilter";
            chkNoDateFilter.Size = new Size(137, 19);
            chkNoDateFilter.TabIndex = 4;
            chkNoDateFilter.Text = "Без фильтра по дате";
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(60, 60);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(120, 30);
            btnApplyFilter.TabIndex = 5;
            btnApplyFilter.Text = "Применить фильтр";
            btnApplyFilter.Click += BtnApplyFilter_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(200, 60);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(120, 30);
            btnResetFilter.TabIndex = 6;
            btnResetFilter.Text = "Сбросить фильтры";
            btnResetFilter.Click += BtnResetFilter_Click;
            // 
            // statsGroup
            // 
            statsGroup.Controls.Add(lblBalance);
            statsGroup.Controls.Add(lblIncome);
            statsGroup.Controls.Add(lblExpense);
            statsGroup.Controls.Add(lblCount);
            statsGroup.Location = new Point(10, 120);
            statsGroup.Name = "statsGroup";
            statsGroup.Size = new Size(960, 60);
            statsGroup.TabIndex = 1;
            statsGroup.TabStop = false;
            statsGroup.Text = "Статистика";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblBalance.Location = new Point(20, 25);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(106, 16);
            lblBalance.TabIndex = 0;
            lblBalance.Text = "Баланс: 0.00 ₽";
            // 
            // lblIncome
            // 
            lblIncome.AutoSize = true;
            lblIncome.Location = new Point(200, 25);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(85, 15);
            lblIncome.TabIndex = 1;
            lblIncome.Text = "Доходы: 0.00 ₽";
            // 
            // lblExpense
            // 
            lblExpense.AutoSize = true;
            lblExpense.Location = new Point(400, 25);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(89, 15);
            lblExpense.TabIndex = 2;
            lblExpense.Text = "Расходы: 0.00 ₽";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(600, 25);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(58, 15);
            lblCount.TabIndex = 3;
            lblCount.Text = "Кол-во: 0";
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.Location = new Point(10, 190);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(960, 300);
            dgvTransactions.TabIndex = 2;
            dgvTransactions.SelectionChanged += DgvTransactions_SelectionChanged;
            // 
            // inputGroup
            // 
            inputGroup.Controls.Add(lblDate);
            inputGroup.Controls.Add(txtDate);
            inputGroup.Controls.Add(lblType);
            inputGroup.Controls.Add(cmbType);
            inputGroup.Controls.Add(lblCategory);
            inputGroup.Controls.Add(txtCategory);
            inputGroup.Controls.Add(lblAmount);
            inputGroup.Controls.Add(txtAmount);
            inputGroup.Controls.Add(lblDesc);
            inputGroup.Controls.Add(txtDescription);
            inputGroup.Controls.Add(btnAdd);
            inputGroup.Controls.Add(btnUpdate);
            inputGroup.Controls.Add(btnDelete);
            inputGroup.Location = new Point(10, 500);
            inputGroup.Name = "inputGroup";
            inputGroup.Size = new Size(960, 120);
            inputGroup.TabIndex = 3;
            inputGroup.TabStop = false;
            inputGroup.Text = "Добавление / Редактирование";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(20, 30);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(35, 15);
            lblDate.TabIndex = 0;
            lblDate.Text = "Дата:";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(70, 27);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(200, 30);
            lblType.Name = "lblType";
            lblType.Size = new Size(31, 15);
            lblType.TabIndex = 2;
            lblType.Text = "Тип:";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Items.AddRange(new object[] { "Доход", "Расход" });
            cmbType.Location = new Point(240, 27);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(100, 23);
            cmbType.TabIndex = 3;
            cmbType.SelectedIndex = 0;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(370, 30);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(66, 15);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Категория:";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(440, 27);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(150, 23);
            txtCategory.TabIndex = 5;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(620, 30);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(48, 15);
            lblAmount.TabIndex = 6;
            lblAmount.Text = "Сумма:";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(680, 27);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 7;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Location = new Point(20, 65);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(65, 15);
            lblDesc.TabIndex = 8;
            lblDesc.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(90, 62);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(400, 23);
            txtDescription.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(520, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Добавить";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(630, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Обновить";
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(740, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Удалить";
            btnDelete.Click += BtnDelete_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1000, 650);
            Controls.Add(filterGroup);
            Controls.Add(statsGroup);
            Controls.Add(dgvTransactions);
            Controls.Add(inputGroup);
            Name = "Form1";
            Text = "Домашняя бухгалтерия";
            filterGroup.ResumeLayout(false);
            filterGroup.PerformLayout();
            statsGroup.ResumeLayout(false);
            statsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            inputGroup.ResumeLayout(false);
            inputGroup.PerformLayout();
            ResumeLayout(false);
        }

        // Поля формы
        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.TextBox txtFilterCategory;
        private System.Windows.Forms.DateTimePicker dtpFilterFrom;
        private System.Windows.Forms.DateTimePicker dtpFilterTo;
        private System.Windows.Forms.CheckBox chkNoDateFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnResetFilter;

        private System.Windows.Forms.GroupBox statsGroup;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.DataGridView dgvTransactions;

        private System.Windows.Forms.GroupBox inputGroup;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}