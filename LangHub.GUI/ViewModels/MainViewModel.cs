namespace LangHub.GUI.ViewModels;

/// <summary>
/// Main iew model for the application.
/// </summary>
public class MainViewModel : ViewModelBase
{
	/// <summary>
	/// The greeting text.
	/// </summary>
	public static string Greeting
	{
		get
		{
			return "Welcome to Avalonia!";
		}
	}
}