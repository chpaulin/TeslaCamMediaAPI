using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using TeslaCamMediaAPI.Extensions;

namespace TeslaCamMediaAPI.Test
{
	[TestClass]
	public class DateTimeUnixTimestampExtensionsTests
	{
		[TestClass]
		public class ToUnixTimestamp
		{
			[TestMethod]
			public void Should_return_correct_timestamp()
			{
				//Arrange
				var date = new DateTime(2020, 1, 7, 17, 25, 21, DateTimeKind.Utc);
				var expectedTimestamp = 1578417921;

				//Act
				var result = date.ToUnixTimestamp();
	
				//Assert
				result.ShouldBe(expectedTimestamp);
			}
		}

		[TestClass]
		public class ConvertFromUnixTimestamp
		{
			[TestMethod]
			public void Should_return_correct_date()
			{
				//Arrange				
				var timestamp = 1578417921;
				var expectedDate = new DateTime(2020, 1, 7, 17, 25, 21, DateTimeKind.Utc);

				//Act
				var result = DateTimeUnixTimestampExtensions.ConvertFromUnixTimestamp(timestamp);

				//Assert
				result.ShouldBe(expectedDate);
			}
		}

		
	}
}
