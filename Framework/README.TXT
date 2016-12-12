Jan-Joost van Zon, 2016-12-12

JJ.Framework contains reusable software components written in C# that are extensions or replacements of parts of the Microsoft .NET Framework. In this framework we put any reusable code not related to a particular business domain. There is a separate assembly for each part of .NET that is extended or other technical aspect. That allows us to be specific about which parts of .NET we make our application dependent on.

In the documentation I describe a way of working and design patterns I use at home and in our team at work.

I started programming this framework at home in 2013. I have also used a variation on it at work in a team of 7 that I lead.

I apologize in advance. The quality of this framework should have been improved before publishing. Some more unit testing is needed, a couple of bad ideas should be gotten rid of and some bugs should be solved. I only publish it now, so it gets the legal status of being open source.

We do not often encounter bugs, but if we do, we just fix them. And if we are missing something, we just extend it. We kept it incomplete, as to not burden ourselves with building a complete framework, before getting anything else done.

