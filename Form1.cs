using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTaskForActualTech.Interfaces;
using TestTaskForActualTech.Presenters;

namespace TestTaskForActualTech
{
	public partial class Form1 : Form, IView
	{
		private MainPresentor presentor;
		public int selectedWebSiteId { get; set; }
		public Form1()
		{
			InitializeComponent();
			this.Text = "Monitoring WebSites";
			presentor = new MainPresentor(this);
		}
		public IEnumerable<IWebSite> webSites { get; set; }
		public void ShowData()
		{
			CheckinWSListBox.Items.Clear();
			for (int i = 0; i < webSites.ToArray().Length; i++)
			{
				CheckinWSListBox.Items.Add("" + webSites.ToArray()[i].Name + "\t" + webSites.ToArray()[i].IsAwailable.ToString());
			}
		}
		private void AddWSButton_Click(object sender, EventArgs e)
		{
			presentor.AddNewWebSite(WSNameTB.Text, WSURLTB.Text, Convert.ToInt32(TimeIntervalTB.Text));
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			presentor.StopCheckingWS();
		}

		private void DeleteWSButton_Click(object sender, EventArgs e)
		{
			presentor.DeleteWS(selectedWebSiteId);
			WSNameTB.Text = "";
			WSURLTB.Text = "";
			TimeIntervalTB.Text = "";
			SaveWSButton.Enabled = false;
			DeleteWSButton.Enabled = false;
		}

		private void CheckinWSListBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string[] selectedata = new string[4];
			int index = this.CheckinWSListBox.IndexFromPoint(e.Location);
			if (index != System.Windows.Forms.ListBox.NoMatches)
			{
				selectedata = presentor.SelectWS(webSites.ToArray()[index]);
				WSNameTB.Text = selectedata[1];
				WSURLTB.Text = selectedata[2];
				TimeIntervalTB.Text = selectedata[3];
				selectedWebSiteId = Convert.ToInt32(selectedata[0]);
				SaveWSButton.Enabled = true;
				DeleteWSButton.Enabled = true;
			}
		}

		private void SaveWSButton_Click(object sender, EventArgs e)
		{
			presentor.AcceptChanges(selectedWebSiteId, WSNameTB.Text, WSURLTB.Text, Convert.ToInt32(TimeIntervalTB.Text));
			SaveWSButton.Enabled = false;
			DeleteWSButton.Enabled = false;
			WSNameTB.Text = "";
			WSURLTB.Text = "";
			TimeIntervalTB.Text = "";
		}
	}
}
