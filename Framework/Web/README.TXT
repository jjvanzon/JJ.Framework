JJ.Framework.Web contains extensions or replacements for System.Web and other HTTP related parts of .NET.

It among other things contains helper methods for working with cookies more easily, and a helper for picking up the culture / language from your web request.

I do not like .NET's Uri class. It seems awkward and when you are thinking you retrieve a well-formatted URL string, you can find yourself with parameter values not being escaped and you have an actual invalid URL.

In JJ.Framework.Web I attempted to build a replacement. I do not promise it supports any kind of Uri possible, but the goal was to support the ones we are all used to on the internet.

Unfortunately it still contains bugs. For instance port numbers is something it does not understand, since I blindly interpret the colon (':') character as an indicator for the protocol (e.g. http://). Also: it refuses to add a slash at the beginning of url's related to the root (.e.g /MyFolder/MyDocument.txt) so you always end up adding it yourself.

Those issues still need to be addressed, but if they are, I feel it is a pretty neat API for URL's.
You have a UrlParser and a UrlBuilder for converting between string and UrlInfo, which is a structure laying out all the separate elements of the URL: parameters, values, protocol, path elements, etc:

var parser = new UrlParser();
UrlInfo info = parser.Parse("http://www.blabla.com/myfolder/mydoc?useprettyfont=true");
AssertHelper.AreEqual("useprettyfont", () => urlInfo.Parameters[0].Name);
AssertHelper.AreEqual("true", () => urlInfo.Parameters[0].Value);
string output = UrlBuilder.BuildUrl(info);
