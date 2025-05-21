namespace LangHub.Core.Config.Sections;

/// <summary>
/// Represents the configuration settings for the LangHub system, loaded from config.json.
/// Includes embedded comments as readonly properties to guide users editing the file.
/// </summary>
public class LangHubConfig
{
	// ======= Comments for JSON readability =======

	/// <summary>
	/// Main file-level comment.
	/// </summary>
	public string? _comment => "This file controls LangHub translation settings. Edit carefully.";

	/// <summary>
	/// Explains the dictionaryPath setting.
	/// </summary>
	public string? _dictionaryPathComment => "Path to the directory containing the base dictionary files.";

	/// <summary>
	/// Explains the oldDictionaryBackupPath setting.
	/// </summary>
	public string? _oldDictionaryBackupPathComment => "Where to save backups of previous dictionaries before overwriting.";

	/// <summary>
	/// Explains the targetDirectory setting.
	/// </summary>
	public string? _targetDirectoryComment => "Output directory where translated files will be saved.";

	/// <summary>
	/// Explains the logDirectory setting.
	/// </summary>
	public string? _logDirectoryComment => "Folder where logs will be stored.";

	/// <summary>
	/// Explains the ignoredLanguages setting.
	/// </summary>
	public string? _ignoredLanguagesComment => "Languages to exclude from translation (e.g., ['fr', 'de']).";

	/// <summary>
	/// Explains the serverTimeoutSeconds setting.
	/// </summary>
	public string? _serverTimeoutSecondsComment => "Timeout (in seconds) to wait for a translation server response.";

	/// <summary>
	/// Explains the maxParallelRequests setting.
	/// </summary>
	public string? _maxParallelRequestsComment => "Maximum number of concurrent translation requests.";

	// ======= Actual configuration values =======

	/// <summary>
	/// Path to the directory containing the source dictionary files.
	/// </summary>
	public string? DictionaryPath { get; set; }

	/// <summary>
	/// Path where backups of older dictionary files will be saved.
	/// </summary>
	public string? OldDictionaryBackupPath { get; set; }

	/// <summary>
	/// Directory where translated output files will be stored.
	/// </summary>
	public string? TargetDirectory { get; set; }

	/// <summary>
	/// Directory where logs and diagnostics will be stored.
	/// </summary>
	public string? LogDirectory { get; set; }

	/// <summary>
	/// Array of language codes (e.g., "fr", "de") that should be skipped during translation.
	/// </summary>
	public string[] IgnoredLanguages { get; set; } = Array.Empty<string>();

	/// <summary>
	/// Timeout duration (in seconds) when waiting for a response from a translation server.
	/// </summary>
	public int ServerTimeoutSeconds { get; set; } = 10;

	/// <summary>
	/// Maximum number of translation requests to run in parallel.
	/// </summary>
	public int MaxParallelRequests { get; set; } = 5;

	/// <summary>
	/// Volitelný seznam zdrojů pro překlad s vlastními nastaveními.
	/// </summary>
	public List<ITranslationSource> Sources { get; set; } = [];
}