using BusinessLib.Business;
using BusinessLib.Common;
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
    public partial class EditDialog : Form
    {
        public ViewModel clientViewModel;
        public bool isEdit;

        public EditDialog()
        {
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            try
            {
                SetBindings();

                if (isEdit)
                {
                    maskedTextBoxClientCode.ReadOnly = true;
                    textBoxCompanyName.Focus();
                }
                else
                {
                    maskedTextBoxClientCode.ReadOnly = false;
                    maskedTextBoxClientCode.Focus();
                }
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
            maskedTextBoxClientCode.DataBindings.Add("Text", clientViewModel, "ClientCode");
            textBoxCompanyName.DataBindings.Add("Text", clientViewModel, "CompanyName");
            textBoxAddress1.DataBindings.Add("Text", clientViewModel, "Address1");
            textBoxAddress2.DataBindings.Add("Text", clientViewModel, "Address2");
            textBoxCity.DataBindings.Add("Text", clientViewModel, "City");
            maskedTextBoxProvince.DataBindings.Add("Text", clientViewModel, "Province");
            maskedTextBoxPostalCode.DataBindings.Add("Text", clientViewModel, "PostalCode");
            textBoxYtdSales.DataBindings.Add("Text", clientViewModel, "YTDSales");
            checkBoxCreditHold.DataBindings.Add("Checked", clientViewModel, "CreditHold");
            textBoxNotes.DataBindings.Add("Text", clientViewModel, "Notes");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderClient.SetError(buttonOk, "");

                Customer client = clientViewModel.GetDisplayCustomer();
                int rowsAffected = 0;
                string errorMessage = null;

                if (isEdit)
                {
                    rowsAffected = ClientValidation.UpdateClient(client);
                }
                else
                {
                    rowsAffected = ClientValidation.CreateClient(client);
                }

                if (rowsAffected > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (rowsAffected == 0)
                    {
                        errorMessage = "No database changes were made.";
                    }
                    else
                    {
                        errorMessage = ClientValidation.ErrorMessage;
                    }
                    errorProviderClient.SetError(buttonOk, ClientValidation.ErrorMessage);
                }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
