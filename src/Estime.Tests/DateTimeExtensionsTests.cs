using System;
using Estime.Web.Util;
using NUnit.Framework;

namespace Estime.Tests
{
	[TestFixture]
	public class DateTimeExtensionsTests
	{
		[TestCase(0, 0)]
		[TestCase(7, 0)]
		[TestCase(8, 15)]
		[TestCase(15, 15)]
		[TestCase(22, 15)]
		[TestCase(23, 30)]
		[TestCase(30, 30)]
		[TestCase(37, 30)]
		[TestCase(38, 45)]
		[TestCase(45, 45)]
		[TestCase(52, 45)]
		[TestCase(53, 0)]
		public void Unit_Scenario_ExpectedBehavior(int minute, int expectedMinute)
		{
			var date = new DateTime(2011, 12, 31, 23, minute, 0);

			var result = date.GetNearestMinute();

			Assert.AreEqual(expectedMinute, result.Minute);
		}
	}
}