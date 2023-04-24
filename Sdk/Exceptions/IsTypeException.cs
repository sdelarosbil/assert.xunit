#if XUNIT_NULLABLE
#nullable enable
#endif

using System;

namespace Xunit.Sdk
{
	/// <summary>
	/// Exception thrown when the value is unexpectedly not of the exact given type.
	/// </summary>
#if XUNIT_VISIBILITY_INTERNAL
	internal
#else
	public
#endif
	class IsTypeException : XunitException
	{
		IsTypeException(string message) :
			base(message)
		{ }

		/// <summary>
		/// Creates a new instance of the <see cref="IsTypeException"/> class to be thrown
		/// when an object did not exactly match the given type
		/// </summary>
		/// <param name="expectedTypeName">The expected type name</param>
		/// <param name="actualTypeName">The actual type name</param>
		public static IsTypeException ForMismatchedType(
			string expectedTypeName,
#if XUNIT_NULLABLE
			string? actualTypeName) =>
#else
			string actualTypeName) =>
#endif
				new IsTypeException(
					"Assert.IsType() Failure: Value is " + (actualTypeName == null ? "null" : "not the exact type") + Environment.NewLine +
					"Expected: " + expectedTypeName + Environment.NewLine +
					"Actual:   " + (actualTypeName ?? "null")
				);
	}
}
