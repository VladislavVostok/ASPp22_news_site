
namespace Blogp22AspNetCore.Services
{
	public class Some : ISome
	{
		private readonly ILogger<Some> _logger;
		public Some(ILogger<Some> logger)
		{
			_logger = logger;

		}

		public DateTime getDateTime()
		{
			_logger.LogInformation("Расчет времени!");

			return DateTime.Now;
		}
	}
}
