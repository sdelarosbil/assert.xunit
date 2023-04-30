#if XUNIT_NULLABLE
#nullable enable
#endif

using System;

namespace Xunit.Sdk
{
	/// <summary>
	/// The base assert exception class. It marks itself with <see cref="IAssertionException"/> which is how
	/// the framework differentiates between assertion fails and general exceptions.
	/// </summary>
#if XUNIT_VISIBILITY_INTERNAL
	internal
#else
	public
#endif
	partial class XunitException : Exception, IAssertionException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="XunitException"/> class.
		/// </summary>
		/// <param name="userMessage">The user message to be displayed</param>
		/// <param name="innerException">The inner exception</param>
		public XunitException(
#if XUNIT_NULLABLE
			string? userMessage,
			Exception? innerException = null) :
#else
			string userMessage,
			Exception innerException = null) :
#endif
				base(userMessage, innerException)
		{ }

		/// <inheritdoc/>
		public override string ToString()
		{
			var className = GetType().ToString();
			var message = Message;
			string result;

			if (message == null || message.Length <= 0)
				result = className;
			else
				result = $"{className}: {message}";

			var stackTrace = StackTrace;
			if (stackTrace != null)
				result = $"{result}{Environment.NewLine}{stackTrace}";

			return result;
		}
	}
}
