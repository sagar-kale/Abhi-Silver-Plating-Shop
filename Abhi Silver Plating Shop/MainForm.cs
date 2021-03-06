using Abhi_Silver_Plating_Shop.Utils;
using MaterialSkin;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Abhi_Silver_Plating_Shop
{
    public partial class MainForm : Form
    {
        readonly MaterialSkinManager manager;
        public MainForm()
        {
            InitializeComponent();
            manager = MaterialSkinManager.Instance;
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.Pink200,
                TextShade.WHITE
                );
            manager.EnforceBackcolorOnAllComponents = false;
            this.Text = Utility.appName;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void fileMenuClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Model.LoginInfo.UserRole == AppConstants.USER)
            {
                menuUser.Enabled = false;
            }
            menuStrip1.Renderer = new MenuRenderer();
        }

        private void menuCustomer_Click(object sender, EventArgs e)
        {
            new CustomerForm().Show();
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            new ItemForm().Show();
        }

        private void menuRate_Click(object sender, EventArgs e)
        {
            new UnitForm().Show();
        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            new UserForm().Show();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<OrderForm>().Count() == 1)
            {
                Application.OpenForms.OfType<OrderForm>().First().Close();
            }
            new OrderForm().Show();
            Cursor.Current = Cursors.WaitCursor;
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ReportForm>().Count() == 1)
            {
                Application.OpenForms.OfType<ReportForm>().First().Close();
            }
            new ReportForm().Show();
        }

        private class MenuRenderer : ToolStripProfessionalRenderer
        {
            public MenuRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Yellow; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.Yellow; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelected
            {
                get { return Color.Gold; }
            }
        }
    }
}
