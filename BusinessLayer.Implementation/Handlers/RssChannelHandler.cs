using System.Xml;
using AutoMapper;
using System.ServiceModel.Syndication;
using BusinessLayer.CohesiveObjects.HandlerObjects;
using BusinessLayer.CohesiveObjects.Interfaces;

namespace BusinessLayer.Implementation.Handlers
{
	public class RssChannelHandler : ISource
	{
		public RssChannel Load(string url)
		{
			SyndicationFeed feed;

			var settings = new XmlReaderSettings {DtdProcessing = DtdProcessing.Parse};

			using (var reader = XmlReader.Create(url, settings))
			{
				feed = SyndicationFeed.Load(reader);
			}

			return Mapper.Map<SyndicationFeed, RssChannel>(feed);
		}
	}
}
