     __                 
    /  \        _____________________ 
    |  |       /                     \
    @  @       | Welcome, Stranger!  |
    || ||      | I'm here to make    |
    || ||   <--| your life of coding |
    |\_/|      | a little easier.    |
    \___/      \_____________________/

This is the base project that contains various extension methods. They are defined in the Global Scope meaning they 
are immediately available for usage after installing the package. Many of the function are just proxys to framework methods
which enable your code to be easier to read.

# Clippy

## Installation
install from [Nuget](https://www.nuget.org)

    Install-Package Clippy

## Extensions
### String

```C#
// HtmlDecode
"&gt;div&lt;".HtmlDecode(); // => "<div>"

// StripHtml
"<h1>Hello</h1>".StripHtml(); // => "Hello"
	
// AddQueryStringParameter
"/quagmire"
	.AddQueryStringParameter("foo", "no")
	.AddQueryStringParameter("bar", "yes"); // => "/quagmire?foo=no&bar=yes"
	
// ToFirstUpper
"brian".ToFirstUpper(); // => "Brian"

// IsNullOrWhiteSpace
"  ".IsNullOrWhiteSpace(); // => true

// Reverse
"hello".Reverse(); // => "olleh"

// IsValidUrl
"http://www.github.com".IsValidUrl(); // => true

// ToSlug
"Not Suîtable For Å slug".ToSlug(); // => "not-suitable-for-a-slug"

// Truncate
"Most certainly a way to long string".Truncate(20); // => "Most certainly a wa..."
"Most certainly a way to long string".Truncate(20, cutInWhitespace: true); // => "Most certainly a..."
```

### Caching

```C#
// Removing all items in the cache
MemoryCache.Default.Clear();
```

### Enumerate

```C#
// Each
enumerable.Each((item) => item.Something()); // Executes the provided Action for each item.

// Times
5.Times((index) => Console.Write(index)); // Executes the Action the specified times.

// Random
var randomItem = enumerabe.Random(); // Returns a randomly selected item from the collection.

// HasDuplicates
var collection = new [] { "foo", "bar", "foo" };
collection.HasDuplicates(); // => true
```

### File size
Provides human readable formatting to file sizes.
```C#
// bytes to readable (decimal comma/point depending on current thread culture)
1024.ToKiloFileSize(); // => "1.02 kB"
1024.ToKibiFileSize(); // => "1 KiB"
// provide custom formatting
2000000.ToKibiFileSize("0.0000"); // "1.9073 MiB"
// also available on FileInfo
var file = new FileInfo(someFilePath);
file.KibiFileSize();
file.KiloFileSize();
```