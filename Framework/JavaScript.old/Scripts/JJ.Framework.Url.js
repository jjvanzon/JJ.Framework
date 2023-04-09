// WARNING: File is always overwritten. Edit it in JJ.Framework.JavaScript.

var JJ = JJ || {};
JJ.Framework = JJ.Framework || {};
JJ.Framework.Url = JJ.Framework.Url || {};

JJ.Framework.Url.setParameter = function (url, parameterName, parameterValue) {
    // Remove original parameter
    var regExp = new RegExp("\\W(" + parameterName + "=[^&\?$]*)");
    url = url.replace(regExp, "");

    // Add separator character
    if (url.indexOf("?") === -1) {
        url += "?";
    }
    else {
        url += "&";
    }

    // Add new parameter
    url += parameterName + "=" + parameterValue;

    return url;
};
