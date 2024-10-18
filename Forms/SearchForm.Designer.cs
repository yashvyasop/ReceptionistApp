namespace ReceptionistApp
{
    partial class SearchForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnDob = new System.Windows.Forms.ColumnHeader();
            this.listViewAppointments = new System.Windows.Forms.ListView();
            this.columnDateTime = new System.Windows.Forms.ColumnHeader();
            this.columnReason = new System.Windows.Forms.ColumnHeader();

            this.SuspendLayout();

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 0;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(318, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;

            // listViewResults
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnId,
                this.columnName,
                this.columnDob
            });
            this.columnId.Text = "ID";
            this.columnId.Width = 50;
            this.columnName.Text = "Name";
            this.columnName.Width = 200;
            this.columnDob.Text = "Date of Birth";
            this.columnDob.Width = 150;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.Location = new System.Drawing.Point(12, 38);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(500, 200);
            this.listViewResults.TabIndex = 2;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;

            // listViewAppointments
            this.listViewAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnDateTime,
                this.columnReason
            });
            this.columnDateTime.Text = "Date and Time";
            this.columnDateTime.Width = 150;
            this.columnReason.Text = "Reason";
            this.columnReason.Width = 350;
            this.listViewAppointments.FullRowSelect = true;
            this.listViewAppointments.Location = new System.Drawing.Point(12, 244);
            this.listViewAppointments.Name = "listViewAppointments";
            this.listViewAppointments.Size = new System.Drawing.Size(500, 200);
            this.listViewAppointments.TabIndex = 3;
            this.listViewAppointments.UseCompatibleStateImageBehavior = false;
            this.listViewAppointments.View = System.Windows.Forms.View.Details;

            // SearchForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 456);
            this.Controls.Add(this.listViewAppointments);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "SearchForm";
            this.Text = "Search Patients";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnDob;
        private System.Windows.Forms.ListView listViewAppointments;
        private System.Windows.Forms.ColumnHeader columnDateTime;
        private System.Windows.Forms.ColumnHeader columnReason;
    }
}