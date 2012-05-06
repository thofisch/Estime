using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Estime.Web.Models;
using FileHelpers;

namespace Estime.Web.Controllers
{
	public class WareController : SessionController
	{
		public ActionResult Import()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Import(HttpPostedFileBase file)
		{
			if( file.ContentLength>0 )
			{
				using(var sr = new StreamReader(file.InputStream))
				{
					var engine = new DelimitedFileEngine<WareCatalogItem>(Encoding.UTF8);
					var items = engine.ReadStream(sr);
					var existingWares = Session.QueryOver<Ware>().List();
					var wareMap = existingWares.ToDictionary(x => x.Sku);

					foreach(var item in items)
					{
						if( wareMap.ContainsKey(item.Sku) )
						{
							var ware = wareMap[item.Sku];
							ware.Name = item.Name;
						}
						else
						{
							var ware = new Ware {Sku = item.Sku, Name = item.Name};
							Session.Save(ware);
						}
					}
				}
			}

			return RedirectToAction("Import");
		}
	}

	[DelimitedRecord(";")]
	public class WareCatalogItem
	{
		public string Sku;
		public string Name;
	}
}