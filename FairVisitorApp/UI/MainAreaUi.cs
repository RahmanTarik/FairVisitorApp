using System.Windows.Forms;

namespace FairVisitorApp.UI
{
    public partial class MainAreaUi : Form
    {
        public MainAreaUi()
        {
            InitializeComponent();
        }

        private void visitorEntryToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            VisitorEntryUi visitorEntryUi = new VisitorEntryUi();
            visitorEntryUi.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }
        
        private void zoneSpecificVisitorDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ZoneSpecificVisitorInformationReportUi zoneSpecificVisitorInformationReportUi = new ZoneSpecificVisitorInformationReportUi();
            zoneSpecificVisitorInformationReportUi.Show();
        }

        private void zoneWiseVisitorNumbersToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ZoneTypeWiseVisitorNumberUi zoneTypeWiseVisitorNumberUi = new ZoneTypeWiseVisitorNumberUi();
            zoneTypeWiseVisitorNumberUi.Show();
        }

        private void zoneTypeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ZoneTypeEntryUi zoneTypeEntryUi = new ZoneTypeEntryUi();
            zoneTypeEntryUi.Show();
        }

        
    }
}
