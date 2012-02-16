using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Estime.Web.Util
{
	public static class StringExtensions
	{
		private static readonly Regex QuantityRegex = new Regex(@"^(\d+)x", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public static string GetInitials(this string s)
		{
			var parts = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			return string.Join("", parts.Select(x => x[0]));
		}

		public static Tuple<int, string> GetQuantityAndName(this string s)
		{
			var quantity = 1;
			var match = QuantityRegex.Match(s);
			if( match.Success )
			{
				var value = match.Groups[0].Value;
				var x = value.TrimEnd("xX".ToCharArray());
				quantity = int.Parse(x);
				s = s.Substring(value.Length).Trim();
			}

			return new Tuple<int, string>(quantity, s);
		}
	}
}