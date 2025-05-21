using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LangHub.Core.Files;

/// <summary>
/// Provides extension methods for registering LangHub core services.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds LangHub core services including configuration support.
	/// </summary>
	/// <param name="services">The service collection to add services to.</param>
	/// <param name="configPath">The path to the config.json file.</param>
	public static IServiceCollection AddLangHubCoreServices(this IServiceCollection services, string configPath)
	{
		services.AddSingleton<ConfigService>(sp =>
		{
			var logger = sp.GetRequiredService<ILogger<ConfigService>>();
			return new ConfigService(configPath, logger);
		});

		return services;
	}
}