using Estime.Web.Util;
using NUnit.Framework;

namespace Estime.Tests
{
	[TestFixture]
	public class StringExtensionsTests
	{
		[Test]
		public void GetInitials_FirstNameOnly_OneLetter()
		{
			var initials = "Thomas".GetInitials();

			Assert.AreEqual("T", initials);
		}

		[Test]
		public void GetInitials_FullName_FirstLetters()
		{
			var initials = "Thomas Wittrup Fischer".GetInitials();

			Assert.AreEqual("TWF", initials);
		}

		[Test]
		public void GetQuantityAndName_NoQuantitySpecified_OneAndName()
		{
			var result = "Monitor".GetQuantityAndName();

			Assert.AreEqual(1, result.Item1);
			Assert.AreEqual("Monitor", result.Item2);
		}

		[Test]
		public void GetQuantityAndName_QuantitySpecified_QuantityAndName()
		{
			var result = "5xMonitor".GetQuantityAndName();

			Assert.AreEqual(5, result.Item1);
			Assert.AreEqual("Monitor", result.Item2);
		}

		[Test]
		public void GetQuantityAndName_QuantitySpacedSpecified_QuantityAndName()
		{
			var result = "5x Monitor".GetQuantityAndName();

			Assert.AreEqual(5, result.Item1);
			Assert.AreEqual("Monitor", result.Item2);
		}

		[Test]
		public void GetQuantityAndName_NameSpaced_QuantityAndName()
		{
			var result = "5 x Monitor".GetQuantityAndName();

			Assert.AreEqual(1, result.Item1);
			Assert.AreEqual("5 x Monitor", result.Item2);
		}
	}
}