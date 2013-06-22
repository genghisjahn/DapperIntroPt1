using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDapperHowTo
{
    public partial class frmNewItem : Form
    {
        public enum eItemType{
            Team =1,
            Player =2
        }
        public enum eActionType
        {
            Select=1,
            Insert=2,
            Update=3,
            Delete=4

        }
        public frmNewItem(eItemType eitem,eActionType eaction,string defaulttext="")
        {
            InitializeComponent();
            SetForm(eitem, eaction,defaulttext);
        }
        public string ItemText { get; private set; }
        private void SetForm(eItemType eitem, eActionType eaction,string defaulttext)
        {
            string formtext = @"Enter new {0} name:";
            switch(eitem){
                case eItemType.Team:
                    formtext = string.Format(formtext, "team");
                    break;
                case eItemType.Player:
                    formtext = string.Format(formtext, "player");
                    break;
            }
            if (eaction == eActionType.Update)
            {
                this.txtName.Text = defaulttext;
            }
            this.Text = formtext;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                this.DialogResult = DialogResult.OK;
                this.ItemText = this.txtName.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Try again.  You can't enter a blank.", "Tsk-tsk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool FormValid()
        {
            bool result = false;
            if (this.txtName.Text.Trim().Length > 0)
            {
                result = true;  
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.ItemText = "";
            this.Close();
        }      
    }
}
