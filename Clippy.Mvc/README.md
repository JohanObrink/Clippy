     __                 
    /  \        _____________________ 
    |  |       /                     \
    @  @       | Welcome, Stranger!  |
    || ||      | I'm here to make    |
    || ||   <--| your life of coding |
    |\_/|      | a little easier.    |
    \___/      \_____________________/


This project contains helpers, new action results etc. for ASP.NET MVC

# Clippy.Mvc

## Installation
install from [Nuget](https://www.nuget.org)

    Install-Package Clippy.Mvc

## Usage

### Action Results
**JsonOrJsonpResult** is a substitute for [JsonResult](http://msdn.microsoft.com/en-us/library/system.web.mvc.jsonresult(v=vs.108.aspx) 
that automatically renders as [JSONP](http://en.wikipedia.org/wiki/JSONP) if the request contains the parameter *callback*. 

It also uses [Json.Net](http://james.newtonking.com/pages/json-net.aspx) for serialization and lets you tap into the serialization 
process.

```C#
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// simple usage
public ActionResult Index()
{
    var data = new { Foo = "bar" };
    return new JsonOrJsonpResult 
	{
	    Data = data
	};
}
// changing the serialization
public ActionResult Create()
{
    var data = new { Foo = "bar" };
	return new JsonOrJsonpResult
	{
	    Data = data,
		SerializationSettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Include
		}
	};
}
```

### Html Helpers
#### Gravatar
```C#
@Html.Gravatar("example@example.com")
@Html.Gravatar(email: "example@example.com", fallback: "http://example.com/image.png", size: 200)
```