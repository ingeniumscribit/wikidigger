using BusinessLayer.CohesiveObjects.HandlerObjects;

namespace BusinessLayer.CohesiveObjects.Interfaces
{
	public interface ISource
	{
		RssChannel Load(string url);
	}
}
