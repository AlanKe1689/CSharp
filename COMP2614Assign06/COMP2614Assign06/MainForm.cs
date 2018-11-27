using BusinessLib.Business;
using BusinessLib.Common;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP2614Assign06
{
    public partial class MainForm : Form
    {
        private ViewModel clientViewModel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                labelTotalYtdSales.Text = string.Empty;
                labelCreditHoldCount.Text = string.Empty;
                labelRecordCount.Text = string.Empty;
                GetInformation();
                clientViewModel = new ViewModel(ClientValidation.GetCustomer());
                SetBindings();
                SetupDataGridView();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetBindings()
        {
            dataGridViewClient.AutoGenerateColumns = false;
            dataGridViewClient.DataSource = clientViewModel.Clients;
        }

        private void SetupDataGridView()
        {
            dataGridViewClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClient.MultiSelect = false;
            dataGridViewClient.AllowUserToAddRows = false;
            dataGridViewClient.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewClient.AllowUserToOrderColumns = false;
            dataGridViewClient.AllowUserToResizeColumns = false;
            dataGridViewClient.AllowUserToResizeRows = false;
            dataGridViewClient.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            DataGridViewTextBoxColumn clientCode = new DataGridViewTextBoxColumn();
            clientCode.Name = "clientCode";
            clientCode.DataPropertyName = "ClientCode";
            clientCode.HeaderText = "Client Code";
            clientCode.Width = 60;
            clientCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            clientCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clientCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(clientCode);

            DataGridViewTextBoxColumn companyName = new DataGridViewTextBoxColumn();
            companyName.Name = "companyName";
            companyName.DataPropertyName = "CompanyName";
            companyName.HeaderText = "Company Name";
            companyName.Width = 120;
            companyName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            companyName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            companyName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(companyName);

            DataGridViewTextBoxColumn address1 = new DataGridViewTextBoxColumn();
            address1.Name = "address1";
            address1.DataPropertyName = "Address1";
            address1.HeaderText = "Address 1";
            address1.Width = 120;
            address1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            address1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            address1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(address1);

            DataGridViewTextBoxColumn address2 = new DataGridViewTextBoxColumn();
            address2.Name = "address2";
            address2.DataPropertyName = "Address2";
            address2.HeaderText = "Address 2";
            address2.Width = 120;
            address2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            address2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            address2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(address2);

            DataGridViewTextBoxColumn city = new DataGridViewTextBoxColumn();
            city.Name = "city";
            city.DataPropertyName = "City";
            city.HeaderText = "City";
            city.Width = 70;
            city.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            city.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            city.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(city);

            DataGridViewTextBoxColumn province = new DataGridViewTextBoxColumn();
            province.Name = "province";
            province.DataPropertyName = "Province";
            province.HeaderText = "Province";
            province.Width = 60;
            province.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            province.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            province.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(province);

            DataGridViewTextBoxColumn postalCode = new DataGridViewTextBoxColumn();
            postalCode.Name = "postalCode";
            postalCode.DataPropertyName = "PostalCode";
            postalCode.HeaderText = "Postal Code";
            postalCode.Width = 70;
            postalCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            postalCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            postalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(postalCode);

            DataGridViewTextBoxColumn ytdSales = new DataGridViewTextBoxColumn();
            ytdSales.Name = "ytdSales";
            ytdSales.DataPropertyName = "YTDSales";
            ytdSales.HeaderText = "YTD Sales";
            ytdSales.Width = 60;
            ytdSales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdSales.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(ytdSales);

            DataGridViewCheckBoxColumn creditHold = new DataGridViewCheckBoxColumn();
            creditHold.Name = "creditHold";
            creditHold.DataPropertyName = "CreditHold";
            creditHold.HeaderText = "Credit Hold";
            creditHold.Width = 70;
            creditHold.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(creditHold);

            DataGridViewTextBoxColumn notes = new DataGridViewTextBoxColumn();
            notes.Name = "notes";
            notes.DataPropertyName = "Notes";
            notes.HeaderText = "Notes";
            notes.Width = 120;
            notes.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            notes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClient.Columns.Add(notes);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewClient.CurrentRow.Index;
                clientViewModel.SetDisplayClients(clientViewModel.Clients[index]);

                EditDialog dialog = new EditDialog();
                dialog.clientViewModel = clientViewModel;
                dialog.isEdit = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    clientViewModel.Clients = ClientValidation.GetCustomer();
                    dataGridViewClient.DataSource = clientViewModel.Clients;
                    dataGridViewClient.Rows[index].Selected = true;
                }
                dialog.Dispose();
                GetInformation();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClient_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewClient.CurrentRow.Index;
                clientViewModel.SetDisplayClients(clientViewModel.Clients[index]);

                EditDialog dialog = new EditDialog();
                dialog.clientViewModel = clientViewModel;
                dialog.isEdit = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    clientViewModel.Clients = ClientValidation.GetCustomer();
                    dataGridViewClient.DataSource = clientViewModel.Clients;
                    dataGridViewClient.Rows[index].Selected = true;
                }
                dialog.Dispose();
                GetInformation();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewClient.CurrentRow.Index;
                clientViewModel.SetDisplayClients(new Customer());
                EditDialog dialog = new EditDialog();
                dialog.clientViewModel = clientViewModel;
                dialog.isEdit = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    clientViewModel.Clients = ClientValidation.GetCustomer();
                    dataGridViewClient.DataSource = clientViewModel.Clients;
                    dataGridViewClient.Rows[index].Selected = true;
                }
                dialog.Dispose();
                GetInformation();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxConfirmDelete.Checked)
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this client?", "Delete Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        DeleteClient();
                    }
                }
                else
                {
                    DeleteClient();
                }
                GetInformation();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteClient()
        {
            int index = dataGridViewClient.CurrentRow.Index;
            ClientValidation.DeleteClient(clientViewModel.Clients[index]);
            clientViewModel.Clients = ClientValidation.GetCustomer();
            dataGridViewClient.DataSource = clientViewModel.Clients;
        }

        private void GetInformation()
        {
            ClientCollection clients = Repository.ReadClient();
            labelTotalYtdSales.Text = "Total YTD Sales: $" + clients.TotalYTDSales();
            labelCreditHoldCount.Text = "Credit Hold Count: " + clients.CreditHoldCount();
            labelRecordCount.Text = "Record Count: " + clients.Count();
        }
    }
}
