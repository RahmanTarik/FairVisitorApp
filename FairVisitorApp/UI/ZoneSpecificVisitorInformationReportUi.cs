using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairVisitorApp.BLL;
using FairVisitorApp.Model;

namespace FairVisitorApp.UI
{
    public partial class ZoneSpecificVisitorInformationReportUi : Form
    {
        public ZoneSpecificVisitorInformationReportUi()
        {
            InitializeComponent();
        }

        private ZoneManager zoneManager = new ZoneManager();
        private List<Zone> zones = new List<Zone>();
        private VisitorManager manager = new VisitorManager();
        private List<Visitor> visitorList = new List<Visitor>();

        private void ZoneSpecificVisitorInformationReportUi_Load(object sender, EventArgs e)
        {
            zones.Clear();
            zoneComboBox.Items.Clear();
            zones = zoneManager.GetAllZone();
            zoneComboBox.DisplayMember = "Name";
            zoneComboBox.ValueMember = "Id";
            zoneComboBox.DataSource = zones;
            visitorList.Clear();
            visitorList = manager.GetAllVisitor();
            LoadVisitor(visitorList);

        }

        private string fileName = "All Data";
        private void showButton_Click(object sender, EventArgs e)
        {
            int zoneId = int.Parse(zoneComboBox.SelectedValue.ToString());
            fileName = zoneComboBox.Text;
            //MessageBox.Show(fileName);
            visitorList.Clear();
            visitorList = manager.GetVisitorByZoneId(zoneId);
            LoadVisitor(visitorList);
        }

        private void LoadVisitor(List<Visitor> allVisitors)
        {
            zoneSpecificVisitorListVIew.Items.Clear();
            foreach (var visitor in allVisitors)
            {
                ListViewItem item = new ListViewItem(visitor.Name);
                item.SubItems.Add(visitor.Email);
                item.SubItems.Add(visitor.ContactNumber);
                item.Tag = visitor;
                zoneSpecificVisitorListVIew.Items.Add(item);
            }
            totalTextBox.Text = visitorList.Count.ToString();
        }

        private void Export2Excel(ListView lv, string prmBookName, string prmPath)
        {

            try
            {
                if (lv.Items.Count == 0)
                {
                    MessageBox.Show("No items to export",
                        "System Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string[] st = new string[lv.Columns.Count];
                DirectoryInfo di = new DirectoryInfo(prmPath);
                if (di.Exists == false) di.Create();
                StreamWriter sw = new StreamWriter(prmPath + prmBookName + ".xls", false);
                sw.AutoFlush = true;
                for (int col = 0; col < lv.Columns.Count; col++)
                {
                    sw.Write("\t" + lv.Columns[col].Text.ToString());
                }
                int rowIndex = 1;
                int row = 0;
                string st1 = "";
                for (row = 0; row < lv.Items.Count; row++)
                {
                    if (rowIndex <= lv.Items.Count)
                        rowIndex++;
                    if (row == 0) st1 = "\n";
                    else st1 = "";
                    for (int col = 0; col < lv.Columns.Count; col++)
                    {
                        st1 = st1 + "\t"  + lv.Items[row].SubItems[col].Text.ToString();
                    }
                    sw.WriteLine(st1);
                }
                sw.Close();
                FileInfo fil = new FileInfo(prmPath + prmBookName + ".xls");
                if (fil.Exists == true)
                    MessageBox.Show("Done !!! \n" +
                                    "File Location: " + prmPath + prmBookName,
                        "Export to Excel",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            Export2Excel(zoneSpecificVisitorListVIew,fileName,@"G:\Work\SEIP_Practice\FairVisitorApp\");
        }
    }
}