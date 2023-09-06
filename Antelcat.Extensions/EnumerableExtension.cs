using System.Collections;
using System.Runtime.CompilerServices;

namespace Antelcat.Extensions;

public static class EnumerableExtension {
	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		foreach (var item in source)
		{
			action(item);
		}
	}

	public static void Reset<T>(this IList<T> source, IEnumerable<T> data)
	{
		source.Clear();

		foreach (var item in data)
		{
			source.Add(item);
		}
	}

	public static IList<T> AddRange<T>(this IList<T> source, IEnumerable<T> data)
	{
		foreach (var item in data)
		{
			source.Add(item);
		}

		return source;
	}

	public static void RemoveWhere<T>(this IList<T> source, Predicate<T> predicate)
	{
		for (var i = 0; i < source.Count; i++) 
		{
			if (predicate(source[i])) 
			{
				source.RemoveAt(i);
				i--;
			}
		}
	}
	
	/// <summary>
	/// Python: enumerator
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <param name="startIndex"></param>
	/// <param name="step"></param>
	/// <returns></returns>
	public static IEnumerable<ValueTuple<int, T>> WithIndex<T>(
		this IEnumerable<T> enumerable, 
		int startIndex = 0,
		int step = 1) {
		
		foreach (var item in enumerable) {
			yield return (startIndex, item);
			startIndex += step;
		}
	}

	public static IEnumerable<T> Reversed<T>(this IList<T> list) {
		for (var i = list.Count - 1; i >= 0; i--) {
			yield return list[i]; 
		}
	}

	public static int FindIndexOf<T>(this IList<T> list, Predicate<T> predicate) {
		for (var i = 0; i < list.Count; i++) {
			if (predicate(list[i])) {
				return i;
			}
		}

		return -1;
	}
	
	/// <summary>
	/// 完全枚举一个 <see cref="IEnumerable"/>，并丢弃所有元素
	/// </summary>
	/// <param name="enumerable"></param>
	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static void Discard(this IEnumerable enumerable) {
		foreach (var _ in enumerable) { }
	}
	
	/// <summary>
	/// 完全枚举一个 <see cref="IEnumerable{T}"/>，并丢弃所有元素
	/// </summary>
	/// <param name="enumerable"></param>
	/// <typeparam name="T"></typeparam>
	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static void Discard<T>(this IEnumerable<T> enumerable) {
		foreach (var _ in enumerable) { }
	}
}