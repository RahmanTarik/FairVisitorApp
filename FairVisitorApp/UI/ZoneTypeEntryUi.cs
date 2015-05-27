using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairVisitorApp.BLL;
using FairVisitorApp.Model;

namespace FairVisitorApp.UI
{
    public partial class ZoneTypeEntryUi : Form
    {
        public ZoneTypeEntryUi()
        {
            InitializeComponent();
        }
        ZoneManager zoneManager = new ZoneManager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            Zone aZone = new Zone();
            aZone.Name = zoneTypeTextBox.Text;
            if (aZone.Name == String.Empty)
            {
                MessageBox.Show("Please Enter Zone Type First !!");
            }
            else
            {
                MessageBox.Show(zoneManager.Save(aZone));
                zoneTypeTextBox.Clear();
            }
            
            LoadZone();
        }

        List<Zone> zoneList = new List<Zone>(); 
        private void ZoneTypeEntryUi_Load(object sender, EventArgs e)
        {
            zoneList.Clear();
            LoadZone();
        }

        private void LoadZone()
        {
            zoneListView.Items.Clear();
            zoneList = zoneManager.GetAllZone();
            foreach (var zone in zoneList)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(zone.Name);
                item.Tag = zone;
                zoneListView.Items.Add(item);
            }
        }
    }
}
