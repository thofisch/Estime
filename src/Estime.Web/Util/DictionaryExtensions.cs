using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Estime.Web.Util
{
	public static class DictionaryExtensions
	{
		public static string ToJson<TKey, TValue>(this Dictionary<TKey, TValue> hash)
		{
			var sb = new StringBuilder();
			using(var sw = new StringWriter(sb))
			{
				new JsonSerializer().Serialize(sw, hash);

				return sw.ToString();
			}
		}
	}
}