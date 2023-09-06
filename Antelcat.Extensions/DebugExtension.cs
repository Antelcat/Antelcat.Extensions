using System.Runtime.CompilerServices;

namespace Antelcat.Extensions; 

public static class DebugExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Debug<T>(this T target)
	{
#if DEBUG
		System.Diagnostics.Debugger.Break();
#endif
		return target;
	}
}
