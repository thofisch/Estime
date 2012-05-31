using System;
using System.Linq;

namespace Estime.Web.Util
{
	public class UniqueSkuGenerator
	{
		public string Generate()
		{
			var i = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current * (b + 1));
			return string.Format("{0:x}", i - DateTime.Now.Ticks);
		}
	}
}