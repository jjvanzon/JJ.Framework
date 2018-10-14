// WARNING: File is always overwritten. Edit it in JJ.Framework.JavaScript.

// TODO: For every method in JJ.Framework.Assert there must be a corresponding method here,
// because you'll need it at some point.

var JJ = JJ || {};
JJ.Framework = JJ.Framework || {};
JJ.Framework.Check = JJ.Framework.Check || {};

JJ.Framework.Check.isDefined = function (value) {
    return typeof value !== "undefined";
}

JJ.Framework.Check.isString = function (value) {
    // TODO: Apparently this is not full-proof:
    // http://stackoverflow.com/questions/1303646/check-whether-variable-is-number-or-string-in-javascript
    return typeof value === "string";
}

JJ.Framework.Check.isNumber = function (value) {
    // TODO: Test
    return typeof value === "Number";
}

JJ.Framework.Check.isDate = function (value) {
    // TODO: Test
    return typeof value === "Date";
}

JJ.Framework.Check.isNullOrEmpty = function (value) {
    if (value === null) return true;
    // TODO: This sucks. Check should be delegated to Assert, but this would make Check dependent on Assert, but assert is also dependent on check.
    if (!JJ.Framework.Check.isString(value)) throw name + " is not a String.";
    if (value === "") return true;
    return false;
}