// WARNING: File is always overwritten. Edit it in JJ.Framework.JavaScript.

// Depends on JJ.Framework.Assert
// Depends on JJ.Framework.Check
// Depends on JJ.Framework.Cookie
// Depends on jQuery.

// Referencing this script will directly make the page remember its scroll position when you get back to it.

$(document).ready(function () {
    var scrollPosition = JJ.Framework.Cookie.tryGet("scrollPosition");
    if (scrollPosition !== null)
    {
        $(document).scrollTop(scrollPosition);
    }
});

$(window).unload(function () {
    var scrollPosition = $(document).scrollTop();
    JJ.Framework.Cookie.set("scrollPosition", scrollPosition);
});