using System;
using System.IO;
using System.Text.Json.Serialization;
using TeslaCamMediaAPI.Extensions;

namespace TeslaCamMediaAPI.Model
{
	public class Recording
	{
		public Recording(DateTime creationTime, string baseUrl)
		{
			CreationTime = creationTime;

			FrontViewSource = new Uri($"{baseUrl}/media/recordings/{Id}/front.mp4", UriKind.Absolute);
			RearViewSource = new Uri($"{baseUrl}/media/recordings/{Id}/rear.mp4", UriKind.Absolute);
			LeftViewSource = new Uri($"{baseUrl}/media/recordings/{Id}/left.mp4", UriKind.Absolute);
			RightViewSource = new Uri($"{baseUrl}/media/recordings/{Id}/right.mp4", UriKind.Absolute);
		}

		public DateTime CreationTime { get; set; }

		public long Id => CreationTime.ToUnixTimestamp();

		public Uri FrontViewSource
		{
			get; set;
		}

		public Uri RearViewSource
		{
			get; set;
		}

		public Uri LeftViewSource
		{
			get; set;
		}

		public Uri RightViewSource
		{
			get; set;
		}

		public override string ToString()
		{
			return CreationTime.ToString();
		}
	}
}