using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairVisitorApp.BLL;
using FairVisitorApp.Model;

namespace FairVisitorApp.UI
{
    public partial class VisitorEntryUi : Form
    {
        public VisitorEntryUi()
        {
            InitializeComponent();
        }

        ZoneManager zoneManager = new ZoneManager();
        VisitorManager visitorManager = new VisitorManager();
        List<Zone> zones = new List<Zone>();
        private void VisitorEntryUi_Load(object sender, EventArgs e)
        {
            zones.Clear();
            zones = zoneManager.GetAllZone();
            zoneComboBoxDataGridView.DataSource = zones;
            zoneComboBoxDataGridView.ColumnHeadersVisible = false;
            zoneComboBoxDataGridView.RowHeadersVisible = false;
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            zoneComboBoxDataGridView.Columns[0].Visible = false;
            zoneComboBoxDataGridView.Columns[2].Visible = false;
            zoneComboBoxDataGridView.Columns[1].Width = 200;
            zoneComboBoxDataGridView.Columns.Insert(0, checkBoxColumn);

            for (int i = 0; i < zoneComboBoxDataGridView.Rows.Count; i++)
            {
                zoneComboBoxDataGridView.Rows[i].Cells["checkBoxColumn"].Value = true;
            }

            }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int id = visitorManager.GetLastId();
            int visitorId = id + 1;

            Visitor aVisitor = new Visitor();
            aVisitor.Id = visitorId;
            aVisitor.Name = nameTextBox.Text;
            aVisitor.Email = emailTextBox.Text;
            aVisitor.ContactNumber = contactNumberTextBox.Text;
            if (aVisitor.Name != String.Empty && aVisitor.Email != String.Empty && aVisitor.ContactNumber != String.Empty)
            {
                if (aVisitor.Email.Contains("@") && aVisitor.Email.Contains(".com"))
                {
                    bool isChecked = IsBoxChecked();
                    if (isChecked)
                    {
                        bool IsSuccess = visitorManager.Save(aVisitor);
                        if (IsSuccess)
                        {
                            foreach (DataGridViewRow row in zoneComboBoxDataGridView.Rows)
                            {
                                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                                if (isSelected)
                                {
                                    int zoneId = (int)row.Cells["Id"].Value;
                                    visitorManager.InsertVisitorZone(visitorId, zoneId);
                                }
                            }
                            MessageBox.Show("Visitor Saved ");
                            ClearTextFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to Saved Visitor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Zone Type");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a Valid Email ");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Details");
            }

        }

        private bool IsBoxChecked()
        {
            foreach (DataGridViewRow row in zoneComboBoxDataGridView.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    return true;
                }
            }
            return false;
        }

        private void ClearTextFields()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            contactNumberTextBox.Clear();
        }

    }
}
