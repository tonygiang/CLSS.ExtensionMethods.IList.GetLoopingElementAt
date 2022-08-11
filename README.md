# CLSS.ExtensionMethods.IList.GetLoopingElementAt

### Problem

Looping a collection indefinitely is an operation that maps well to many use cases (such as AI behavior phases, sequentially looping slideshow, infinite scrolling background,  etc...). And while the CLSS package [`IEnumerator.LoopNext`](https://www.nuget.org/packages/CLSS.ExtensionMethods.IEnumerator.LoopNext/) provided a solution for this problem with wide compatibility, some limitation has to be in place for the sake of compatibility. It can only loop an enumerator in the ascending order, as is the nature of enumeration.

With [`IList`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist?view=net-6.0) and [`IList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1?view=net-6.0) types, we have more information to work with. Use cases for looping in descending order emerge and are not addressed by `IEnumerator.LoopNext`. Writing descending loop by hand is not as obvious as it may sound and can stump your train of thought.

```
using CLSS;

var numbers = new int[] { 0, 1, 2, 3 };
// Take arbitrary number in a descending loop
int takeNumber = 10;
foreach (int i = 0; i > -takeNumber; --i)
{
  // this is a correct solution, but may stump you just by reading
  int resolvedIndex = ((i % numbers.Length) + numbers.Length) % numbers.Length;
  DoSomethingWith(numbers[resolvedIndex]);
}
```

### Solution

`GetLoopingElementAt` is an extension method for all `Ilist` and `IList<T>` types that resolves a integer number it takes in as a cyclic index number and returns the element at the resulting index. By spelling out what it's doing on the method name, it gives you a better code comprehension.

```
using CLSS;

var numbers = new int[] { 0, 1, 2, 3 };
numbers.GetLoopingElementAt(-1); // returns 3
numbers.GetLoopingElementAt(5); // returns 1
```

`GetLoopingElementAt` resolves positive and negative numbers into a valid index. Looping over a list is as simple as picking a starting point and go as low or high as you want. Increment to loop the list in ascending order, decrement to loop the list in descending order.

This package also comes with a `ResolveLoopingIndex` extension method to only receive the result of cyclically resolving a number into a valid index of the source list.

**Note**: `GetLoopingElementAt` and `ResolveLoopingIndex` work on all types implementing the [`IList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1) interface, *including raw C# array*.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).