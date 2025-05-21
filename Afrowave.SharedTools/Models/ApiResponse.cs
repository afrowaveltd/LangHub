namespace Afrowave.SharedTools.Models
{
	/// <summary>
	/// Represents a standardized API response wrapper for any result type.
	/// </summary>
	/// <typeparam name="T">The type of the returned data.</typeparam>
	public class ApiResponse<T>
	{
		/// <summary>
		/// Indicates whether the operation was successful.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Indicates whether the operation succeeded but contains a warning.
		/// </summary>
		public bool Warning { get; set; }

		/// <summary>
		/// A human-readable message describing the result.
		/// </summary>
		public string Message { get; set; } = string.Empty;

		/// <summary>
		/// The actual result data, if any. Can be null when Success is false.
		/// </summary>
#pragma warning disable CS8618
		public T Data { get; set; }

		/// <summary>
		/// ApiResponse method to create a success response with data and message.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static ApiResponse<T> SuccessResponse(T data, string message)
		{
			return new ApiResponse<T>
			{
				Success = true,
				Data = data,
				Message = message
			};
		}

		/// <summary>
		/// Api Response method to create a failure response with a message.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static ApiResponse<T> Fail(string message)
		{
			return new ApiResponse<T>
			{
				Success = false,
				Message = message,
			};
		}

		/// <summary>
		/// Api Response method to create a success response with no data and a message.
		/// </summary>
		/// <returns></returns>
		public static ApiResponse<T> EmptySuccess()
		{
			return new ApiResponse<T>
			{
				Success = true,
			};
		}

		/// <summary>
		/// Operation succeeded but contains a warning.
		/// </summary>
		/// <param name="data">Response payload</param>
		/// <param name="warningMessage">Warning message</param>
		/// <returns></returns>
		public static ApiResponse<T> SuccessWithWarning(T data, string warningMessage)
		{
			return new ApiResponse<T>
			{
				Success = true,
				Warning = true,
				Data = data,
				Message = warningMessage
			};
		}
	}
}