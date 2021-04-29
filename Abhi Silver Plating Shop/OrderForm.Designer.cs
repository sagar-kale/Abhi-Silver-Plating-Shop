
namespace Abhi_Silver_Plating_Shop
{
    partial class OrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.orderGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.itemCombo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInWeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOutWeight = new System.Windows.Forms.TextBox();
            this.txtFine = new System.Windows.Forms.TextBox();
            this.txtLabourRate = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblInWeight = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAmt = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblFine = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtOrderId = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAddCust = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.btnAddItem = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.txtTotalAmt = new MaterialSkin.Controls.MaterialTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblOutWeight = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Item:";
            // 
            // orderGridView
            // 
            this.orderGridView.AllowUserToAddRows = false;
            this.orderGridView.AllowUserToDeleteRows = false;
            this.orderGridView.AllowUserToResizeColumns = false;
            this.orderGridView.AllowUserToResizeRows = false;
            this.orderGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.orderGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.orderGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.orderGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.orderGridView.ColumnHeadersHeight = 29;
            this.orderGridView.FilterAndSortEnabled = true;
            this.orderGridView.Location = new System.Drawing.Point(373, 183);
            this.orderGridView.MultiSelect = false;
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.ReadOnly = true;
            this.orderGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orderGridView.RowHeadersWidth = 51;
            this.orderGridView.RowTemplate.Height = 29;
            this.orderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderGridView.ShowEditingIcon = false;
            this.orderGridView.Size = new System.Drawing.Size(981, 402);
            this.orderGridView.TabIndex = 29;
            this.orderGridView.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.orderGridView_FilterStringChanged);
            this.orderGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderGridView_CellContentClick);
            // 
            // itemCombo
            // 
            this.itemCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.itemCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.itemCombo.FormattingEnabled = true;
            this.itemCombo.Location = new System.Drawing.Point(117, 201);
            this.itemCombo.Name = "itemCombo";
            this.itemCombo.Size = new System.Drawing.Size(148, 28);
            this.itemCombo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 105);
            this.panel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(574, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Manage Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1320, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(399, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "MANGALMURTI VIBRATOR SHOP";
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
            this.btnAdd.Location = new System.Drawing.Point(16, 663);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 34);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdd.UseAccentColor = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.BackColor = System.Drawing.Color.Crimson;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.Depth = 0;
            this.btnEdit.DrawShadows = true;
            this.btnEdit.HighEmphasis = true;
            this.btnEdit.Icon = null;
            this.btnEdit.Location = new System.Drawing.Point(128, 663);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 34);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnEdit.UseAccentColor = true;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = false;
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.Depth = 0;
            this.btnClear.DrawShadows = true;
            this.btnClear.HighEmphasis = true;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(239, 663);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnClear.UseAccentColor = true;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 747);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 21);
            this.panel2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(801, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 27);
            this.label4.TabIndex = 27;
            this.label4.Text = "Order List";
            // 
            // customerCombo
            // 
            this.customerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.customerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(119, 263);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(148, 28);
            this.customerCombo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Customer:";
            // 
            // txtInWeight
            // 
            this.txtInWeight.Location = new System.Drawing.Point(118, 317);
            this.txtInWeight.Name = "txtInWeight";
            this.txtInWeight.Size = new System.Drawing.Size(213, 27);
            this.txtInWeight.TabIndex = 3;
            this.txtInWeight.Text = "0";
            this.txtInWeight.TextChanged += new System.EventHandler(this.txtInWeight_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "In Weight:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Out Weight:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 417);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Fine(wt):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Rate (Rs.):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 514);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "Date:";
            // 
            // txtOutWeight
            // 
            this.txtOutWeight.Location = new System.Drawing.Point(118, 366);
            this.txtOutWeight.Name = "txtOutWeight";
            this.txtOutWeight.Size = new System.Drawing.Size(213, 27);
            this.txtOutWeight.TabIndex = 4;
            this.txtOutWeight.Text = "0";
            this.txtOutWeight.TextChanged += new System.EventHandler(this.txtOutWeight_TextChanged);
            // 
            // txtFine
            // 
            this.txtFine.Enabled = false;
            this.txtFine.Location = new System.Drawing.Point(118, 414);
            this.txtFine.Name = "txtFine";
            this.txtFine.Size = new System.Drawing.Size(213, 27);
            this.txtFine.TabIndex = 5;
            this.txtFine.Text = "0";
            // 
            // txtLabourRate
            // 
            this.txtLabourRate.Enabled = false;
            this.txtLabourRate.Location = new System.Drawing.Point(118, 464);
            this.txtLabourRate.Name = "txtLabourRate";
            this.txtLabourRate.Size = new System.Drawing.Size(213, 27);
            this.txtLabourRate.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Controls.Add(this.lblInWeight);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(373, 622);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 107);
            this.panel3.TabIndex = 45;
            // 
            // lblInWeight
            // 
            this.lblInWeight.AutoSize = true;
            this.lblInWeight.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInWeight.ForeColor = System.Drawing.Color.White;
            this.lblInWeight.Location = new System.Drawing.Point(26, 45);
            this.lblInWeight.Name = "lblInWeight";
            this.lblInWeight.Size = new System.Drawing.Size(113, 34);
            this.lblInWeight.TabIndex = 46;
            this.lblInWeight.Text = "Weight";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 23);
            this.label12.TabIndex = 46;
            this.label12.Text = "Total In Weight";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.ForestGreen;
            this.panel4.Controls.Add(this.lblAmt);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(893, 622);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 107);
            this.panel4.TabIndex = 46;
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAmt.ForeColor = System.Drawing.Color.White;
            this.lblAmt.Location = new System.Drawing.Point(26, 45);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(124, 34);
            this.lblAmt.TabIndex = 46;
            this.lblAmt.Text = "Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 23);
            this.label15.TabIndex = 46;
            this.label15.Text = "Orders Amount";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Controls.Add(this.lblFine);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Location = new System.Drawing.Point(1147, 622);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(207, 107);
            this.panel5.TabIndex = 47;
            // 
            // lblFine
            // 
            this.lblFine.AutoSize = true;
            this.lblFine.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFine.ForeColor = System.Drawing.Color.White;
            this.lblFine.Location = new System.Drawing.Point(24, 45);
            this.lblFine.Name = "lblFine";
            this.lblFine.Size = new System.Drawing.Size(71, 34);
            this.lblFine.TabIndex = 46;
            this.lblFine.Text = "Fine";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 23);
            this.label17.TabIndex = 46;
            this.label17.Text = "Total Fine";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "";
            this.dateTimePicker.Location = new System.Drawing.Point(118, 509);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(213, 27);
            this.dateTimePicker.TabIndex = 7;
            // 
            // txtOrderId
            // 
            this.txtOrderId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderId.Depth = 0;
            this.txtOrderId.Enabled = false;
            this.txtOrderId.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrderId.Hint = "Order Id";
            this.txtOrderId.Location = new System.Drawing.Point(15, 126);
            this.txtOrderId.MaxLength = 50;
            this.txtOrderId.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOrderId.Multiline = false;
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(315, 50);
            this.txtOrderId.TabIndex = 48;
            this.txtOrderId.Text = "";
            // 
            // btnAddCust
            // 
            this.btnAddCust.Depth = 0;
            this.btnAddCust.Icon = global::Abhi_Silver_Plating_Shop.Properties.Resources.add_customer;
            this.btnAddCust.Location = new System.Drawing.Point(287, 251);
            this.btnAddCust.Mini = true;
            this.btnAddCust.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(40, 51);
            this.btnAddCust.TabIndex = 51;
            this.btnAddCust.Text = "Add";
            this.btnAddCust.UseVisualStyleBackColor = true;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Depth = 0;
            this.btnAddItem.Icon = global::Abhi_Silver_Plating_Shop.Properties.Resources.add_item;
            this.btnAddItem.Location = new System.Drawing.Point(287, 189);
            this.btnAddItem.Mini = true;
            this.btnAddItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(40, 51);
            this.btnAddItem.TabIndex = 52;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalAmt.Depth = 0;
            this.txtTotalAmt.Enabled = false;
            this.txtTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTotalAmt.Hint = "Total Amount (Rs.)";
            this.txtTotalAmt.Location = new System.Drawing.Point(16, 567);
            this.txtTotalAmt.MaxLength = 50;
            this.txtTotalAmt.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTotalAmt.Multiline = false;
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.Size = new System.Drawing.Size(315, 50);
            this.txtTotalAmt.TabIndex = 53;
            this.txtTotalAmt.Text = "0";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Teal;
            this.panel6.Controls.Add(this.lblOutWeight);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Location = new System.Drawing.Point(628, 622);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(207, 107);
            this.panel6.TabIndex = 54;
            // 
            // lblOutWeight
            // 
            this.lblOutWeight.AutoSize = true;
            this.lblOutWeight.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutWeight.ForeColor = System.Drawing.Color.White;
            this.lblOutWeight.Location = new System.Drawing.Point(24, 45);
            this.lblOutWeight.Name = "lblOutWeight";
            this.lblOutWeight.Size = new System.Drawing.Size(113, 34);
            this.lblOutWeight.TabIndex = 46;
            this.lblOutWeight.Text = "Weight";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(169, 23);
            this.label14.TabIndex = 46;
            this.label14.Text = "Total Out Weight";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(373, 597);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 20);
            this.label13.TabIndex = 55;
            this.label13.Text = "Created :";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCreated.Location = new System.Drawing.Point(444, 597);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(39, 20);
            this.lblCreated.TabIndex = 56;
            this.lblCreated.Text = "date";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUpdate.Location = new System.Drawing.Point(744, 597);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(39, 20);
            this.lblUpdate.TabIndex = 58;
            this.lblUpdate.Text = "date";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(628, 597);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 20);
            this.label19.TabIndex = 57;
            this.label19.Text = "Last Updated :";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txtTotalAmt);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnAddCust);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtLabourRate);
            this.Controls.Add(this.txtFine);
            this.Controls.Add(this.txtOutWeight);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customerCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.orderGridView);
            this.Controls.Add(this.itemCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private Zuby.ADGV.AdvancedDataGridView orderGridView;
        private System.Windows.Forms.ComboBox itemCombo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox customerCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOutWeight;
        private System.Windows.Forms.TextBox txtFine;
        private System.Windows.Forms.TextBox txtLabourRate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblInWeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblFine;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private MaterialSkin.Controls.MaterialTextBox txtOrderId;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAddCust;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAddItem;
        private MaterialSkin.Controls.MaterialTextBox txtTotalAmt;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblOutWeight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label label19;
    }
}