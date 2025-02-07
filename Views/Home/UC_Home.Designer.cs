namespace GestionVehiculos_Ev_Final.Views.Home
{
    partial class UC_Home
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vistaVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gestionVehiculosDataSet = new GestionVehiculos_Ev_Final.GestionVehiculosDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gestionVehiculosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vistaVentasTableAdapter = new GestionVehiculos_Ev_Final.GestionVehiculosDataSetTableAdapters.VistaVentasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vistaVentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionVehiculosDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gestionVehiculosDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vistaVentasBindingSource
            // 
            this.vistaVentasBindingSource.DataMember = "VistaVentas";
            this.vistaVentasBindingSource.DataSource = this.gestionVehiculosDataSet;
            // 
            // gestionVehiculosDataSet
            // 
            this.gestionVehiculosDataSet.DataSetName = "GestionVehiculosDataSet";
            this.gestionVehiculosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(591, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 27);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar venta";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(276, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(305, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 396);
            this.panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.vistaVentasBindingSource;
            this.btnSave.LocalReport.DataSources.Add(reportDataSource2);
            this.btnSave.LocalReport.ReportEmbeddedResource = "GestionVehiculos_Ev_Final.Views.Home.SalesReport.rdlc";
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.ServerReport.BearerToken = null;
            this.btnSave.Size = new System.Drawing.Size(866, 396);
            this.btnSave.TabIndex = 0;
            // 
            // gestionVehiculosDataSetBindingSource
            // 
            this.gestionVehiculosDataSetBindingSource.DataSource = this.gestionVehiculosDataSet;
            this.gestionVehiculosDataSetBindingSource.Position = 0;
            // 
            // vistaVentasTableAdapter
            // 
            this.vistaVentasTableAdapter.ClearBeforeFill = true;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(866, 467);
            this.MinimumSize = new System.Drawing.Size(866, 467);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(866, 467);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vistaVentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionVehiculosDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gestionVehiculosDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private Microsoft.Reporting.WinForms.ReportViewer btnSave;
        private System.Windows.Forms.BindingSource gestionVehiculosDataSetBindingSource;
        private GestionVehiculosDataSet gestionVehiculosDataSet;
        private System.Windows.Forms.BindingSource vistaVentasBindingSource;
        private GestionVehiculosDataSetTableAdapters.VistaVentasTableAdapter vistaVentasTableAdapter;
        private System.Windows.Forms.Button btnSearch;
    }
}
