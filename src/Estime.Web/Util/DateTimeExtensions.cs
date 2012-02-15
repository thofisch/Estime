using System;

namespace Estime.Web.Util
{
	public static class DateTimeExtensions
	{
		public static DateTime GetNearestMinute(this DateTime date, int nearestMinute = 15)
		{
			nearestMinute = Math.Min(30, Math.Max(1, nearestMinute));

			var minute = date.Minute;
			if( minute>0 )
			{
				var nearest = minute / nearestMinute * nearestMinute;
				var remainder = minute % nearestMinute;
				if( remainder>nearestMinute / 2 )
				{
					nearest += nearestMinute;
				}
				minute = nearest;
			}

			return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0).AddMinutes(minute);
		}
	}
}