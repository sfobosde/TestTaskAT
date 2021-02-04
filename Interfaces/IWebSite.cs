using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForActualTech.Interfaces
{
	public interface IWebSite
	{

		int id { get; set; }
		string Name { get; set; }
		string Url { get; set; }
		int updatetime { get; set; }
		bool IsAwailable { get; set; }

		void IsWSavailable();
	}
}
