JJ = JJ || { }
JJ.Framework = JJ.Framework || { }
JJ.Framework.JavaScript = JJ.Framework.Javascript || { }
JJ.Framework.JavaScript.Cookies = JJ.Framework.JavaScript.Cookies || {}

JJ.Framework.JavaScript.Cookies.tryGet = function (name) {
    if (typeof name === "undefined") throw "name is undefined.";
    if (name == null) throw "name cannot be null.";
    if (typeof name !== "String") throw "name is not a String.";
    if (name == "") throw "name cannot be empty.";

    // TODO: Regex might be faster.
    var cookiesString = document.cookie;
    var splitCookiesString = cookiesString.split(";");
    for (var i = 0; i < splitCookiesString.length; i++) {
        var cookieString = splitCookiesString[i];
        var splitCookieString = cookieString.split("=");
        var name = splitCookieString[0];
        var value = splitCookieString[1];
        if (name == name) {
            return value;
        }
    }

    return null;
}

JJ.Framework.JavaScript.Cookies.set = function (name, value, expirationDate, expirationDays) {
    if (typeof name === "undefined") throw "name is undefined.";
    if (name == null) throw "name cannot be null.";
    if (typeof name !== "String") throw "name is not a String.";
    if (name == "") throw "name cannot be empty.";

    if (typeof value === "undefined") throw "value is undefined.";

    var cookie = name + "=" + value + ";";

    if (typeof expirationDate !== "undefined" && typeof expirationDays !== "undefined") {
        throw "Define either expirationDate or expirationDays, but not both.";
    }

    if (typeof expirationDate !== "undefined") {
        if (expirationDate == null) throw "experiationDate cannot be null.";
        if (typeof expirationDate !== "Date") throw "expirationDate is not a Date.";
        cookie = cookie + ";expires=" + expirationDate.toGMTString();
    }

    if (typeof expirationDays !== "undefined") {
        if (expirationDays == null) throw "expirationDays cannot be null.";
        if (typeof expirationDays !== "Number") throw "expirationDays is not of type Number.";
        if (expirationDays < 0) throw "expirationDays cannot be negative.";
        cookie = cookie + ";expires=" + expirationDays;
    }

    document.cookie = cookie;
}

JJ.Framework.JavaScript.Cookies.delete = function (name) {
    JJ.Framework.JavaScript.Cookies.set(name, "");
}

// You will probably never use this, but just see it as example code then.
JJ.Framework.JavaScript.Cookies.parse = function () {
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