// WARNING: File is always overwritten. Edit it in JJ.Framework.JavaScript.

// Depends on JJ.Framework.Assert
// Depends on JJ.Framework.Check

// TODO: Add functionality to work with the path and domain attributes of a cookie.

var JJ = JJ || {};
JJ.Framework = JJ.Framework || {};
JJ.Framework.Cookie = JJ.Framework.Cookie || {};

JJ.Framework.Cookie.tryGet = function (name) {
    JJ.Framework.Assert.notNullOrEmpty(name, "name");

    var cookiesString = document.cookie;
    if (!JJ.Framework.Check.isNullOrEmpty(cookiesString)) {
        var splitCookiesString = cookiesString.split(";");
        for (var i = 0; i < splitCookiesString.length; i++) {
            var cookieString = splitCookiesString[i];
            var splitCookieString = cookieString.split("=");
            var name2 = splitCookieString[0];
            var value = splitCookieString[1];
            if (name2 === name) {
                return value;
            }
        }
    }

    return null;
}

JJ.Framework.Cookie.set = function (name, value, expirationDate, expirationDays) {
    JJ.Framework.Assert.notNullOrEmpty(name, "name");
    JJ.Framework.Assert.isDefined(value, "value");

    var cookie = escape(name) + "=" + escape(value) + ";"; // TODO: Check if the escape function will work with non-string values.

    if (JJ.Framework.Check.isDefined(expirationDate) &&
        JJ.Framework.Check.isDefined(expirationDays)){
        throw "Define either expirationDate or expirationDays, but not both.";
    }

    // TODO: The use of the expirationDate and expirationDays parameters has never been tested.

    if (JJ.Framework.Check.isDefined(expirationDate)) {
        JJ.Framework.Assert.isDate(expirationDate, "expirationDate");
        cookie = cookie + ";expires=" + expirationDate.toGMTString();
    }

    if (JJ.Framework.Check.isDefined(expirationDays)) {
        JJ.Framework.Assert.notNegative(expirationDays, "expirationDays");
        cookie = cookie + ";expires=" + expirationDays;
    }

    document.cookie = cookie;
}

JJ.Framework.Cookie.delete = function (name) {
    JJ.Framework.Cookie.set(name, "");
}

// You will probably never use this, but just see it as example code then.
JJ.Framework.Cookie.parse = function () {
    var parsedCookies = new Array();
    var cookiesString = document.cookie;
    var splitCookiesString = cookiesString.split(";");
    for (var i = 0; i < splitCookiesString.length; i++) {
        var cookieString = splitCookiesString[i];
        var splitCookieString = cookieString.split("=");
        var parsedCookie = { name: splitCookieString[0], value: splitCookieString[1] };
        parsedCookies[i] = parsedCookie;
    }
    return parsedCookies;
}