// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IEnumerableLooping
  {
    /// <summary>
    /// Resolves the specified looping index in the range of the source
    /// <see cref="IList{T}"/> and returns the resulting valid index from that.
    /// Looping index is resolved as the positive remainder of the looping index
    /// divided by the element count of the source <see cref="IList{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements of
    /// <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IList{T}"/> to constrain index number
    /// in.</param>
    /// <param name="loopingIndex">The looping index to resolve.</param>
    /// <returns>The valid index for the source <see cref="IList{T}"/>
    /// resolved from the looping index.</returns>
    public static int ResolveLoopingIndex<T>(this IList<T> source,
      int loopingIndex)
    { return ((loopingIndex % source.Count) + source.Count) % source.Count; }

    /// <summary>
    /// Resolves the specified looping index in the range of the source
    /// <see cref="IList{T}"/> into a valid index and returns the element at
    /// that index.
    /// Looping index is resolved as the positive remainder of the looping index
    /// divided by the element count of the source <see cref="IList{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// <inheritdoc cref="ResolveLoopingIndex{T}(IList{T}, int)"
    /// path="/typeparam[@name='T']"/></typeparam>
    /// <param name="source">An <see cref="IList{T}"/> to return an element
    /// from.</param>
    /// <param name="loopingIndex">
    /// <inheritdoc cref="ResolveLoopingIndex{T}(IList{T}, int)"
    /// path="/param[@name='loopingIndex']"/></param>
    /// <returns>The element at the valid index resolved from the looping index.
    /// </returns>
    public static T GetLoopingElementAt<T>(this IList<T> source,
      int loopingIndex)
    { return source[source.ResolveLoopingIndex(loopingIndex)]; }

    /// <summary>
    /// Resolves the specified looping index in the range of the source
    /// <see cref="IList"/> and returns the resulting valid index from that.
    /// Looping index is resolved as the positive remainder of the looping index
    /// divided by the element count of the source <see cref="IList"/>.
    /// </summary>
    /// <param name="source">An <see cref="IList"/> to constrain index number
    /// in.</param>
    /// <param name="loopingIndex">
    /// <inheritdoc cref="ResolveLoopingIndex{T}(IList{T}, int)"
    /// path="/param[@name='loopingIndex']"/></param>
    /// <returns>The valid index for the source <see cref="IList"/>
    /// resolved from the looping index.</returns>
    public static int ResolveLoopingIndex(this IList source,
      int loopingIndex)
    { return ((loopingIndex % source.Count) + source.Count) % source.Count; }

    /// <summary>
    /// Resolves the specified looping index in the range of the source
    /// <see cref="IList"/> into a valid index and returns the element at
    /// that index.
    /// Looping index is resolved as the positive remainder of the looping index
    /// divided by the element count of the source <see cref="IList"/>.
    /// </summary>
    /// <param name="source">An <see cref="IList"/> to return an element
    /// from.</param>
    /// <param name="loopingIndex">
    /// <inheritdoc cref="ResolveLoopingIndex{T}(IList{T}, int)"
    /// path="/param[@name='loopingIndex']"/></param>
    /// <returns>
    /// <inheritdoc cref="GetLoopingElementAt{T}(IList{T}, int)"
    /// path="/returns"/></returns>
    public static object GetLoopingElementAt(this IList source,
      int loopingIndex)
    { return source[source.ResolveLoopingIndex(loopingIndex)]; }
  }
}
