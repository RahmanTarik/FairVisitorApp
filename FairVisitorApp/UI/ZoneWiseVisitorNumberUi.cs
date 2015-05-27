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
    public partial class ZoneTypeWiseVisitorNumberUi : Form
    {
        ZoneManager manager = new ZoneManager();
        public ZoneTypeWiseVisitorNumberUi()
        {
            InitializeComponent();
        }

        List<Zone> zoneList = new List<Zone>(); 
        private void ZoneTypeWiseVisitorNumberUi_Load(object sender, EventArgs e)
        {
            int count = 0;
            zoneList.Clear();
            zoneList = manager.GetZoneWiseTotalVisitor();
            zoneTypeWiseVisitorListView.Items.Clear();
            foreach (var zone in zoneList)
            {
                ListViewItem item = new ListViewItem(zone.Name);
                item.SubItems.Add(zone.NumberOfVisitor.ToString());
                count += zone.NumberOfVisitor;
                zoneTypeWiseVisitorListView.Items.Add(item);

            }
            totalTextBox.Text = count.ToString();
        }
    }
}
