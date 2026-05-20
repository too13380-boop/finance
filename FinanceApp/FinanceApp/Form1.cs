using System;
using System.Data;
using System.Windows.Forms;

namespace FinanceApp
{
    public partial class Form1 : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int selectedId = -1;

        public Form1()
        {
            InitializeComponent();
            LoadTransactions();
            UpdateStats();
        }

        private void LoadTransactions()
        {
            string type = cmbFilterType.SelectedItem?.ToString();
            string category = txtFilterCategory.Text;
            string dateFrom = chkNoDateFilter.Checked ? null : dtpFilterFrom.Value.ToString("yyyy-MM-dd");
            string dateTo = chkNoDateFilter.Checked ? null : dtpFilterTo.Value.ToString("yyyy-MM-dd");

            DataTable dt = db.GetAllTransactions(type, category, dateFrom, dateTo);
            dgvTransactions.DataSource = dt;

            // Настройка заголовков и преобразование типа
            if (dt.Columns.Contains("id")) dgvTransactions.Columns["id"].HeaderText = "ID";
            if (dt.Columns.Contains("date")) dgvTransactions.Columns["date"].HeaderText = "Дата";
            if (dt.Columns.Contains("type"))
            {
                dgvTransactions.Columns["type"].HeaderText = "Тип";
                foreach (DataGridViewRow row in dgvTransactions.Rows)
                    if (row.Cells["type"].Value?.ToString() == "income")
                        row.Cells["type"].Value = "Доход";
                    else if (row.Cells["type"].Value?.ToString() == "expense")
                        row.Cells["type"].Value = "Расход";
            }
            if (dt.Columns.Contains("category")) dgvTransactions.Columns["category"].HeaderText = "Категория";
            if (dt.Columns.Contains("amount")) dgvTransactions.Columns["amount"].HeaderText = "Сумма";
            if (dt.Columns.Contains("description")) dgvTransactions.Columns["description"].HeaderText = "Описание";

            UpdateStats();
        }

        private void UpdateStats()
        {
            string type = cmbFilterType.SelectedItem?.ToString();
            string category = txtFilterCategory.Text;
            string dateFrom = chkNoDateFilter.Checked ? null : dtpFilterFrom.Value.ToString("yyyy-MM-dd");
            string dateTo = chkNoDateFilter.Checked ? null : dtpFilterTo.Value.ToString("yyyy-MM-dd");

            var stats = db.GetStats(type, category, dateFrom, dateTo);
            lblBalance.Text = $"Баланс: {stats.balance:F2} ₽";
            lblIncome.Text = $"Доходы: {stats.totalIncome:F2} ₽";
            lblExpense.Text = $"Расходы: {stats.totalExpense:F2} ₽";
            lblCount.Text = $"Кол-во: {stats.count}";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DateTime.TryParse(txtDate.Text, out DateTime date))
                { MessageBox.Show("Неверная дата"); return; }
                if (cmbType.SelectedItem == null)
                { MessageBox.Show("Выберите тип"); return; }
                if (string.IsNullOrWhiteSpace(txtCategory.Text))
                { MessageBox.Show("Введите категорию"); return; }
                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
                { MessageBox.Show("Сумма должна быть положительным числом"); return; }

                string type = cmbType.SelectedItem.ToString() == "Доход" ? "income" : "expense";
                db.AddTransaction(date, type, txtCategory.Text, amount, txtDescription.Text);
                LoadTransactions();
                ClearForm();
                MessageBox.Show("Транзакция добавлена", "Успех");
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) { MessageBox.Show("Выберите транзакцию"); return; }
            try
            {
                if (!DateTime.TryParse(txtDate.Text, out DateTime date))
                { MessageBox.Show("Неверная дата"); return; }
                if (cmbType.SelectedItem == null)
                { MessageBox.Show("Выберите тип"); return; }
                if (string.IsNullOrWhiteSpace(txtCategory.Text))
                { MessageBox.Show("Введите категорию"); return; }
                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
                { MessageBox.Show("Сумма должна быть положительным числом"); return; }

                string type = cmbType.SelectedItem.ToString() == "Доход" ? "income" : "expense";
                db.UpdateTransaction(selectedId, date, type, txtCategory.Text, amount, txtDescription.Text);
                LoadTransactions();
                ClearForm();
                MessageBox.Show("Транзакция обновлена", "Успех");
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) { MessageBox.Show("Выберите транзакцию"); return; }
            if (MessageBox.Show("Удалить выбранную транзакцию?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    db.DeleteTransaction(selectedId);
                    LoadTransactions();
                    ClearForm();
                    MessageBox.Show("Транзакция удалена", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        private void DgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                var row = dgvTransactions.SelectedRows[0];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                txtDate.Text = row.Cells["date"].Value?.ToString();
                string type = row.Cells["type"].Value?.ToString();
                cmbType.SelectedItem = (type == "Доход") ? "Доход" : "Расход";
                txtCategory.Text = row.Cells["category"].Value?.ToString();
                txtAmount.Text = row.Cells["amount"].Value?.ToString();
                txtDescription.Text = row.Cells["description"].Value?.ToString();
            }
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void BtnResetFilter_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedIndex = 0;
            txtFilterCategory.Clear();
            chkNoDateFilter.Checked = true;
            dtpFilterFrom.Value = DateTime.Now;
            dtpFilterTo.Value = DateTime.Now;
            LoadTransactions();
        }

        private void ClearForm()
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cmbType.SelectedIndex = 0;
            txtCategory.Clear();
            txtAmount.Clear();
            txtDescription.Clear();
            selectedId = -1;
        }
    }
}