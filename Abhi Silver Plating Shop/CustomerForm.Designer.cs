
namespace Abhi_Silver_Plating_Shop
{
    partial class CustomerForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.txtCustName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustAddr = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustMob = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 83);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1056, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(327, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Customers";
            // 
            // customerGridView
            // 
            this.customerGridView.AllowUserToAddRows = false;
            this.customerGridView.AllowUserToDeleteRows = false;
            this.customerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.customerGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Location = new System.Drawing.Point(479, 173);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.ReadOnly = true;
            this.customerGridView.RowHeadersWidth = 51;
            this.customerGridView.RowTemplate.Height = 29;
            this.customerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGridView.Size = new System.Drawing.Size(595, 309);
            this.customerGridView.TabIndex = 3;
            this.customerGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerGridView_CellContentClick);
            // 
            // txtCustName
            // 
            this.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustName.Depth = 0;
            this.txtCustName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustName.ForeColor = System.Drawing.Color.Crimson;
            this.txtCustName.Hint = "Customer Name";
            this.txtCustName.Location = new System.Drawing.Point(53, 173);
            this.txtCustName.MaxLength = 50;
            this.txtCustName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustName.Multiline = false;
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(278, 50);
            this.txtCustName.TabIndex = 4;
            this.txtCustName.Text = "";
            // 
            // txtCustAddr
            // 
            this.txtCustAddr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustAddr.Depth = 0;
            this.txtCustAddr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustAddr.ForeColor = System.Drawing.Color.Crimson;
            this.txtCustAddr.Hint = "Address";
            this.txtCustAddr.Location = new System.Drawing.Point(53, 229);
            this.txtCustAddr.MaxLength = 50;
            this.txtCustAddr.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustAddr.Multiline = false;
            this.txtCustAddr.Name = "txtCustAddr";
            this.txtCustAddr.Size = new System.Drawing.Size(278, 50);
            this.txtCustAddr.TabIndex = 5;
            this.txtCustAddr.Text = "";
            // 
            // txtCustEmail
            // 
            this.txtCustEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustEmail.Depth = 0;
            this.txtCustEmail.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustEmail.ForeColor = System.Drawing.Color.Crimson;
            this.txtCustEmail.Hint = "Email";
            this.txtCustEmail.Location = new System.Drawing.Point(53, 285);
            this.txtCustEmail.MaxLength = 50;
            this.txtCustEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustEmail.Multiline = false;
            this.txtCustEmail.Name = "txtCustEmail";
            this.txtCustEmail.Size = new System.Drawing.Size(278, 50);
            this.txtCustEmail.TabIndex = 6;
            this.txtCustEmail.Text = "";
            // 
            // txtCustMob
            // 
            this.txtCustMob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustMob.Depth = 0;
            this.txtCustMob.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustMob.ForeColor = System.Drawing.Color.Crimson;
            this.txtCustMob.Hint = "Mobile";
            this.txtCustMob.Location = new System.Drawing.Point(53, 341);
            this.txtCustMob.MaxLength = 50;
            this.txtCustMob.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustMob.Multiline = false;
            this.txtCustMob.Name = "txtCustMob";
            this.txtCustMob.Size = new System.Drawing.Size(278, 50);
            this.txtCustMob.TabIndex = 7;
            this.txtCustMob.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = false;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BackColor = System.Drawing.Color.Crimson;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Depth = 0;
            this.btnAdd.DrawShadows = true;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(51, 421);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 34);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.UseAccentColor = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.BackColor = System.Drawing.Color.Crimson;
            this.materialButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialButton1.Depth = 0;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(147, 421);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(88, 34);
            this.materialButton1.TabIndex = 9;
            this.materialButton1.Text = "Edit";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = true;
            this.materialButton1.UseVisualStyleBackColor = false;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.BackColor = System.Drawing.Color.Crimson;
            this.materialButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialButton2.Depth = 0;
            this.materialButton2.DrawShadows = true;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(241, 421);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(88, 34);
            this.materialButton2.TabIndex = 10;
            this.materialButton2.Text = "DELETE";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = true;
            this.materialButton2.UseVisualStyleBackColor = false;
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSize = false;
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.BackColor = System.Drawing.Color.Crimson;
            this.materialButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialButton3.Depth = 0;
            this.materialButton3.DrawShadows = true;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(147, 467);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.Size = new System.Drawing.Size(88, 34);
            this.materialButton3.TabIndex = 11;
            this.materialButton3.Text = "Home";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = true;
            this.materialButton3.UseVisualStyleBackColor = false;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 585);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCustMob);
            this.Controls.Add(this.txtCustEmail);
            this.Controls.Add(this.txtCustAddr);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.customerGridView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemForm";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView customerGridView;
        private MaterialSkin.Controls.MaterialTextBox txtCustName;
        private MaterialSkin.Controls.MaterialTextBox txtCustAddr;
        private MaterialSkin.Controls.MaterialTextBox txtCustEmail;
        private MaterialSkin.Controls.MaterialTextBox txtCustMob;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private System.Windows.Forms.Label label2;
    }
}