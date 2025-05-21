using LangHub.Core.Config.Sections;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace LangHub.Core.Files;

/// <summary>
/// Provides access to the LangHub configuration and watches for changes in the config.json file.
/// </summary>
public class ConfigService
{
	private readonly string _configFilePath;
	private readonly ILogger<ConfigService> _logger;
	private LangHubConfig? _currentConfig;
	private FileSystemWatcher? _watcher;

	/// <summary>
	/// Current configuration settings loaded from config.json.
	/// </summary>
	public LangHubConfig Current
	{
		get
		{
			return _currentConfig ?? throw new InvalidOperationException("Configuration not loaded.");
		}
	}

	/// <summary>
	/// Constructor for the ConfigService.
	/// </summary>
	/// <param name="configFilePath">Path to the configuration JSON file</param>
	/// <param name="logger">Logger</param>
	public ConfigService(string configFilePath, ILogger<ConfigService> logger)
	{
		_configFilePath = configFilePath;
		_logger = logger;

		LoadConfig();
		WatchFileChanges();
	}

	private void LoadConfig()
	{
		if(!File.Exists(_configFilePath))
		{
			_logger.LogWarning("Configuration file not found at {Path}. Creating default config.", _configFilePath);
			_currentConfig = new LangHubConfig();
			SaveConfig(); // optionally create the file
			return;
		}

		var json = File.ReadAllText(_configFilePath);
		_currentConfig = JsonSerializer.Deserialize<LangHubConfig>(json) ?? new LangHubConfig();
		_logger.LogInformation("Configuration loaded from {Path}.", _configFilePath);
	}

	private void SaveConfig()
	{
		var json = JsonSerializer.Serialize(_currentConfig, new JsonSerializerOptions { WriteIndented = true });
		File.WriteAllText(_configFilePath, json);
	}

	private void WatchFileChanges()
	{
		var directory = Path.GetDirectoryName(_configFilePath);
		var filename = Path.GetFileName(_configFilePath);

		if(directory is null || filename is null)
			return;

		_watcher = new FileSystemWatcher(directory, filename)
		{
			NotifyFilter = NotifyFilters.LastWrite,
			EnableRaisingEvents = true
		};

		_watcher.Changed += (_, _) =>
		{
			_logger.LogInformation("Detected config change. Reloading.");
			Thread.Sleep(250); // debounce
			LoadConfig();
		};
	}
}