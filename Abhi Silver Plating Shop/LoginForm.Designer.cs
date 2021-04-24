
namespace Abhi_Silver_Plating_Shop
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHading = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbkShowPwd = new System.Windows.Forms.CheckBox();
            this.lblClear = new System.Windows.Forms.Label();
            this.txtPwd = new MaterialSkin.Controls.MaterialTextBox();
            this.txtUsr = new MaterialSkin.Controls.MaterialTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHading
            // 
            this.lblHading.AutoSize = true;
            this.lblHading.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHading.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHading.Location = new System.Drawing.Point(73, 29);
            this.lblHading.Name = "lblHading";
            this.lblHading.Size = new System.Drawing.Size(88, 38);
            this.lblHading.TabIndex = 6;
            this.lblHading.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.Crimson;
            this.btnLogin.Location = new System.Drawing.Point(21, 238);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(198, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.ckbkShowPwd);
            this.panel1.Controls.Add(this.lblClear);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.txtUsr);
            this.panel1.Controls.Add(this.lblHading);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(130, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 332);
            this.panel1.TabIndex = 8;
            // 
            // ckbkShowPwd
            // 
            this.ckbkShowPwd.AutoSize = true;
            this.ckbkShowPwd.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckbkShowPwd.ForeColor = System.Drawing.Color.DarkBlue;
            this.ckbkShowPwd.Location = new System.Drawing.Point(76, 286);
            this.ckbkShowPwd.Name = "ckbkShowPwd";
            this.ckbkShowPwd.Size = new System.Drawing.Size(145, 24);
            this.ckbkShowPwd.TabIndex = 8;
            this.ckbkShowPwd.Text = "Show Password";
            this.ckbkShowPwd.UseVisualStyleBackColor = true;
            this.ckbkShowPwd.CheckedChanged += new System.EventHandler(this.ckbkShowPwd_CheckedChanged);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClear.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClear.Location = new System.Drawing.Point(21, 287);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(49, 20);
            this.lblClear.TabIndex = 7;
            this.lblClear.Text = "Clear";
            this.lblClear.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPwd.Depth = 0;
            this.txtPwd.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPwd.ForeColor = System.Drawing.Color.White;
            this.txtPwd.Hint = "Enter Password";
            this.txtPwd.Location = new System.Drawing.Point(21, 155);
            this.txtPwd.MaxLength = 50;
            this.txtPwd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPwd.Multiline = false;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Password = true;
            this.txtPwd.Size = new System.Drawing.Size(198, 50);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.Text = "";
            // 
            // txtUsr
            // 
            this.txtUsr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsr.Depth = 0;
            this.txtUsr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsr.Hint = "Enter Username";
            this.txtUsr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtUsr.Location = new System.Drawing.Point(21, 86);
            this.txtUsr.MaxLength = 50;
            this.txtUsr.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsr.Multiline = false;
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(198, 50);
            this.txtUsr.TabIndex = 1;
            this.txtUsr.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "ABHI PLATING SHOP";
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.BackColor = System.Drawing.Color.Transparent;
            this.lblCancel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCancel.ForeColor = System.Drawing.Color.Crimson;
            this.lblCancel.Location = new System.Drawing.Point(476, 0);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(35, 38);
            this.lblCancel.TabIndex = 9;
            this.lblCancel.Text = "X";
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Abhi_Silver_Plating_Shop.Properties.Resources.brandi_redd_aJTiW00qqtI_unsplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(512, 463);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHading;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialTextBox txtPwd;
        private MaterialSkin.Controls.MaterialTextBox txtUsr;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.CheckBox ckbkShowPwd;
    }
}

