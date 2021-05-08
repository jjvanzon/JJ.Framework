JJ.Framework.Xml.Linq
=====================

Aims to make working with XML easier. May convert XML to an object graph and back. Details might be taken into account that might be required by (WCF) SOAP services: namespacing and nil-handling for instance.

Uses System.Xml.Linq internally. Was created, when JJ.Framework.Xml (based on System.Xml) would not work on all platforms, most notably on Windows Phone 8.

At first it was the same as JJ.Framework.Xml, except it used a different underlying XML API. See the README of JJ.Framework.Xml.