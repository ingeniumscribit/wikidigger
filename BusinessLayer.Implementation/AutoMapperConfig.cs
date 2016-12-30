using System.Linq;
using System.ServiceModel.Syndication;
using AutoMapper;
using BusinessLayer.CohesiveObjects.HandlerObjects;

namespace BusinessLayer.Implementation
{
	public static class AutoMapperConfig
	{
		public static void InitializeBusinessLayer(IMapperConfigurationExpression config)
		{
			config.CreateMap<SyndicationItem, RssItem>()
				.ForMember(t=>t.Title, o => o.MapFrom(x=>x.Title.Text))
				.ForMember(t => t.Description, o => o.MapFrom(x => x.Summary.Text))
				.ForMember(t => t.Link, o => o.MapFrom(x => x.Links.FirstOrDefault().GetUrl()))
				.ForMember(t => t.PublishDate, o => o.MapFrom(x => x.PublishDate));

			config.CreateMap<SyndicationFeed, RssChannel>()
				.ForMember(t => t.Description, o => o.MapFrom(x => x.Description.Text))
				.ForMember(t => t.Title, o => o.MapFrom(x => x.Title.Text))
				.ForMember(t => t.Link, o => o.MapFrom(x => x.Links.FirstOrDefault().GetUrl()))
				.ForMember(t => t.Image, o => o.MapFrom(x => x.ImageUrl))
				.ForMember(t => t.Items, o => o.MapFrom(x => x.Items));
		}

		private static string GetUrl(this SyndicationLink link)
		{
			return link?.Uri.ToString() ?? string.Empty;
		}

	}
}
