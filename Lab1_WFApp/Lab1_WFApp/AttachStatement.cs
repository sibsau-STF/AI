using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_WFApp
{
	public partial class AttachStatement : Form
	{
		public Statement Result;
		public AttachStatement (IEnumerable<Statement> statements)
		{
			InitializeComponent();
			statementsBox.Items.AddRange(statements.ToArray());
		}

		private void noBtn_Click (object sender, EventArgs e)
		{
			this.Close();
		}

		private void yesBtn_Click (object sender, EventArgs e)
		{
			Result = (Statement)statementsBox.SelectedItem;
			Result = trueBox.Checked ? Result : -Result;
			this.Close();
		}
	}
}
