Jan-Joost van Zon, 2016-12-12

JJ.Framework contains reusable software components written in C# that are extensions or replacements of parts of the Microsoft .NET Framework. In this framework I and our team put any reusable code not related to a particular business domain. There is a separate assembly for each part of .NET that is extended or a separate assembly for each technical aspect. That allows us to be specific about which parts of .NET and other API's we make our applications dependent on, which is a good plan for platform compatibility.

In the documentation I describe a way of working and design patterns I use at home and in our team at work.

I started programming this framework at home in 2013. Some code is even ported from my previous code base that I started in 2010. I have also used a variation of this code at work in a team of 7 that I lead.

I apologize in advance. The quality of this framework should have been improved before publishing. Some more unit testing is needed, a couple of bad ideas should be gotten rid of and some bugs should be solved. I only publish it now, so it gets the legal status of being open source. I do not accept the responsibility of keeping it totally bug free.