using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForActualTech.Models;
using TestTaskForActualTech.Interfaces;

namespace TestTaskForActualTech.Presenters
{
	class MainPresentor: IPresentor
	{
		OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Мвидео\Desktop\TestTaskForActualTech\wsDB.mdb"); // строка подключения к БД
		OleDbDataAdapter wsLoadAdapter;

		DataSet ds = new DataSet();
		DataTable wsTable;

		List<WebSite> WSList;

		IEnumerable<WebSite> wsListtoView;

		private readonly IView _view;

		bool CheckingWSWorkStatus;

		public void LoadData()
		{
			//load data from db
			wsLoadAdapter = new OleDbDataAdapter("SELECT * FROM CheckingWS", connection);
			wsLoadAdapter.Fill(ds, "WebSites");
		}
		public void UpdateTable(OleDbDataAdapter adapter)
		{
			//updating data collection after some action
			OleDbCommandBuilder updateCommand = new OleDbCommandBuilder(adapter);
			adapter.Update(ds.Tables["WebSites"]);
		}
		public void FilingTable()
		{
			//copy data from datatable to List<>

			wsTable = ds.Tables["WebSites"];

			var getlistquery = from wsList in wsTable.AsEnumerable()
							   orderby wsList.ItemArray[0]
							   select wsList;

			DataRow[] wsdataRows = getlistquery.ToArray();

			WSList = new List<WebSite>();

			for (int i = 0; i < wsdataRows.Length; i++)
			{
				WSList.Add(new WebSite((string)wsdataRows[i]["wsName"],
					(string)wsdataRows[i]["wsUrl"],
					(int)wsdataRows[i]["wsUpdateTime"], this)
				{ id = (int)wsdataRows[i]["wsID"]});
			}
		}
		public MainPresentor(IView _view)
		{
			LoadData();
			FilingTable();
			ds.Tables["WebSites"].PrimaryKey = new DataColumn[] { ds.Tables["WebSites"].Columns[0] };
			ds.Tables["WebSites"].Columns[0].AutoIncrement = true;

			wsListtoView = WSList.AsEnumerable<WebSite>();
			_view.webSites = wsListtoView;

			this._view = _view;

			Task.Run(() => CheckingWebSites());
		}
		public void AddNewWebSite(string Name, string Url, int updtime)
		{
			StopCheckingWS();

			DataRow row = ds.Tables["WebSites"].NewRow();

			row["wsName"] = Name;
			row["wsUrl"] = Url;
			row["wsUpdateTime"] = updtime;

			ds.Tables["WebSites"].Rows.Add(row);

			UpdateTable(wsLoadAdapter);
			FilingTable();

			wsListtoView = WSList.AsEnumerable<WebSite>();
			this._view.webSites = wsListtoView;
			this._view.ShowData();
			Task.Run(()=> CheckingWebSites());
		}
		public void CheckingWebSites()
		{
			CheckingWSWorkStatus = true;
			while (CheckingWSWorkStatus)
				if (WSList.ToArray().Length > 0)
				{
					Parallel.For(0, WSList.ToArray().Length, i =>
					{
						WSList.ToArray()[i].IsWSavailable();
					});
				}
		}
		public void StopCheckingWS()
		{
			CheckingWSWorkStatus = false;
		}
		public void DeleteWS(int selectedid)
		{
			StopCheckingWS();
			DataRow dr;
			for (int i = 0; i < ds.Tables["WebSites"].Rows.Count; i++)
			{
				dr = ds.Tables["WebSites"].Rows[i];
				if ((int)dr[0] == selectedid)
				{
					dr.Delete();
				}
			}
			UpdateTable(wsLoadAdapter);
			FilingTable();
			wsListtoView = WSList.AsEnumerable<WebSite>();
			this._view.webSites = wsListtoView;
			this._view.ShowData();
			Task.Run(() => CheckingWebSites());
		}
		public string[] SelectWS(IWebSite selectedWS)
		{
			string[] selectedData = new string[4];
			selectedData[0] = selectedWS.id.ToString();
			selectedData[1] = selectedWS.Name;
			selectedData[2] = selectedWS.Url;
			selectedData[3] = selectedWS.updatetime.ToString();

			return selectedData;
		}
		public void AcceptChanges(int wsid, string newname, string newurl, int newtime)
		{
			StopCheckingWS();
			DataRow dr = ds.Tables["WebSites"].Select("wsID = " + wsid.ToString()).FirstOrDefault();
			if (dr != null)
			{
				dr[1] = newname;
				dr[2] = newurl;
				dr[3] = newtime;
			}
			UpdateTable(wsLoadAdapter);
			FilingTable();
			wsListtoView = WSList.AsEnumerable<WebSite>();
			this._view.webSites = wsListtoView;
			this._view.ShowData();
			Task.Run(() => CheckingWebSites());
		}
		public void CallShowDataAfterChanges()
		{
			this._view.ShowData();
		}
	}
}
