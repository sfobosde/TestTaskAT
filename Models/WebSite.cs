using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestTaskForActualTech.Interfaces;

namespace TestTaskForActualTech.Models
{
	class WebSite: IWebSite
	{
		public delegate void OnChangingAv();
		public event OnChangingAv ChangingAv;
		public int id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public int updatetime { get; set; }
		public bool IsAwailable { get; set; }
		WebRequest request;
		public WebSite(string Name, string Url, int updtime, IPresentor _presentor)
		{
			this.Name = Name;
			this.Url = Url;
			this.updatetime = updtime;
			request = WebRequest.Create(Url);
			ChangingAv += _presentor.CallShowDataAfterChanges;
		}
		public void IsWSavailable()
		{
			request.Timeout = updatetime;
			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				if(	IsAwailable == false && ChangingAv != null)
				{
					IsAwailable = true;
					ChangingAv();
				}
			}
			catch
			{
				if (IsAwailable == true && ChangingAv != null)
				{
					IsAwailable = false;
					ChangingAv();
				}
			}
		}
	}
}
