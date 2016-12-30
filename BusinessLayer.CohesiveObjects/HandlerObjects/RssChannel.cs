using System.Collections.Generic;

namespace BusinessLayer.CohesiveObjects.HandlerObjects
{
	public class RssChannel
	{
		public string Title { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public IEnumerable<RssItem> Items { get; set; }
	}
}
