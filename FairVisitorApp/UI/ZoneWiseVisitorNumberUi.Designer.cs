namespace FairVisitorApp.UI
{
    partial class ZoneTypeWiseVisitorNumberUi
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
            this.zoneTypeWiseVisitorListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zoneTypeWiseVisitorListView
            // 
            this.zoneTypeWiseVisitorListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoneTypeWiseVisitorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.zoneTypeWiseVisitorListView.FullRowSelect = true;
            this.zoneTypeWiseVisitorListView.Location = new System.Drawing.Point(44, 40);
            this.zoneTypeWiseVisitorListView.Name = "zoneTypeWiseVisitorListView";
            this.zoneTypeWiseVisitorListView.Size = new System.Drawing.Size(385, 205);
            this.zoneTypeWiseVisitorListView.TabIndex = 0;
            this.zoneTypeWiseVisitorListView.UseCompatibleStateImageBehavior = false;
            this.zoneTypeWiseVisitorListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Zone";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Number of Visitor";
            this.columnHeader3.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "total";
            // 
            // totalTextBox
            // 
            this.totalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalTextBox.Location = new System.Drawing.Point(329, 261);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalTextBox.TabIndex = 2;
            // 
            // ZoneTypeWiseVisitorNumberUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 342);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoneTypeWiseVisitorListView);
            this.Name = "ZoneTypeWiseVisitorNumberUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zone Type Wise Visitor Number";
            this.Load += new System.EventHandler(this.ZoneTypeWiseVisitorNumberUi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView zoneTypeWiseVisitorListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}