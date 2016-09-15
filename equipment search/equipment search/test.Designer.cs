namespace equipment_search
{
    partial class test
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.testDataSet1 = new equipment_search.testDataSet1();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTableAdapter = new equipment_search.testDataSet1TableAdapters.equipmentTableAdapter();
            this.majorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.majorTableAdapter = new equipment_search.testDataSet1TableAdapters.majorTableAdapter();
            this.equipmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // testDataSet1
            // 
            this.testDataSet1.DataSetName = "testDataSet1";
            this.testDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataMember = "equipment";
            this.equipmentBindingSource.DataSource = this.testDataSet1;
            // 
            // equipmentTableAdapter
            // 
            this.equipmentTableAdapter.ClearBeforeFill = true;
            // 
            // majorBindingSource
            // 
            this.majorBindingSource.DataMember = "major";
            this.majorBindingSource.DataSource = this.testDataSet1;
            // 
            // majorTableAdapter
            // 
            this.majorTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentBindingSource1
            // 
            this.equipmentBindingSource1.DataMember = "equipment";
            this.equipmentBindingSource1.DataSource = this.testDataSet1;
            // 
            // equipmentBindingSource2
            // 
            this.equipmentBindingSource2.DataMember = "equipment";
            this.equipmentBindingSource2.DataSource = this.testDataSet1;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 574);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private testDataSet1 testDataSet1;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private testDataSet1TableAdapters.equipmentTableAdapter equipmentTableAdapter;
        private System.Windows.Forms.BindingSource majorBindingSource;
        private testDataSet1TableAdapters.majorTableAdapter majorTableAdapter;
        private System.Windows.Forms.BindingSource equipmentBindingSource1;
        private System.Windows.Forms.BindingSource equipmentBindingSource2;
    }
}