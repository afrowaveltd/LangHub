namespace Afrowave.SharedTools.Models
{
	/// <summary>
	/// Represents the result of an operation without data.
	/// </summary>
	public class OperationResult
	{
		/// <summary>
		/// Indicates whether the operation was successful.
		/// </summary>
		public bool Success { get; set; } = true;

		/// <summary>
		/// Optional message describing the result.
		/// </summary>
		public string Message { get; set; } = string.Empty;

		/// <summary>
		/// Returns a successful operation result with optional message.
		/// </summary>
		public static OperationResult Ok(string? message = null)
		{
			return new OperationResult
			{
				Success = true,
				Message = message ?? string.Empty
			};
		}

		/// <summary>
		/// Returns a failed operation result with error message.
		/// </summary>
		public static OperationResult Fail(string message)
		{
			return new OperationResult
			{
				Success = false,
				Message = message
			};
		}
	}
}