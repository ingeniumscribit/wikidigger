using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.CohesiveObjects.HandlerObjects;
using BusinessLayer.CohesiveObjects.Interfaces;
using BusinessLayer.Implementation.Handlers;
using NUnit.Framework;

namespace BusinessLayer.Implementation.Test
{
	[TestFixture]
	internal class RssChannelHandlerTests
	{
		[SetUp]
		public void InitializeTests()
		{
			Mapper.Initialize(AutoMapperConfig.InitializeBusinessLayer);
		}

		[Test]
		[TestCase("https://news.tut.by/rss/index.rss")]
		public void Is_LoadChannel_Works(string url)
		{
			ISource source = new RssChannelHandler();

			var channel = source.Load(url);

			Assert.IsTrue(!string.IsNullOrEmpty(channel.Title));
			Assert.IsTrue(!string.IsNullOrEmpty(channel.Link));
			Assert.IsTrue(!string.IsNullOrEmpty(channel.Description));
			Assert.IsTrue(!string.IsNullOrEmpty(channel.Image));
			Assert.IsTrue(channel.Items.Any());
		}
	}
}
