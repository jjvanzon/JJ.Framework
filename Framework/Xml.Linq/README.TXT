JJ.Framework.Xml.Linq was created, when JJ.Framework.Xml would not work on all platforms, most notably on Windows Phone 8.

At first it was the same as JJ.Framework.Xml, except it used a different underlying XML API. See the README.TXT of JJ.Framework.Xml.

But this project takes it further by not only being able to convert XML to an object, but also convert an object back to XML, with any detail a WCF SOAP protocol needs: namespacing, nil-handling, you name it.