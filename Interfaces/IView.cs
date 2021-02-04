using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForActualTech.Models;
using TestTaskForActualTech.Interfaces;
using System.Data;

namespace TestTaskForActualTech.Interfaces
{
	public interface IView
	{
		IEnumerable<IWebSite> webSites { get; set; }
		int selectedWebSiteId { get; set; }
		void ShowData();
	}
}
