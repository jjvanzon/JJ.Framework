// WARNING: File is always overwritten. Edit it in JJ.Framework.JavaScript.

// Depends on JJ.Framework.Check

// This script defines functions to check the type of variables and do other checks
// and throw exceptions if conditions are not met.

// Ironically, these functions' name arguments are not checked for validity,
// because that would make this code look bad.

var JJ = JJ || {};
JJ.Framework = JJ.Framework || {};
JJ.Framework.Assert = JJ.Framework.Assert || {};

JJ.Framework.Assert.isDefined = function (value, name) {
	if (!JJ.Framework.Check.isDefined) throw name + " is undefined.";
}

JJ.Framework.Assert.isString = function (value, name) {
	JJ.Framework.Assert.isDefined(value, name);
	if (!JJ.Framework.Check.isString(value)) throw name + " is not a String.";
}

JJ.Framework.Assert.notNull = function (value, name) {
	JJ.Framework.Assert.isDefined(value, name);
	if (value === null) throw name + " cannot be null.";
}

JJ.Framework.Assert.notEmpty = function (value, name) {
	JJ.Framework.Assert.isString(value, name);
	if (value === "") throw name + " cannot be empty.";
}

JJ.Framework.Assert.notNullOrEmpty = function (value, name) {
	JJ.Framework.Assert.isString(value, name);
	if (value === null) throw name + " cannot be null.";
	if (value === "") throw name + " cannot be empty.";
}

JJ.Framework.Assert.isDate = function (value, name) {
	JJ.Framework.Assert.notNull(value, name);
	if (!JJ.Framework.Check.isDate(value)) throw name + " is not a Date.";
}

JJ.Framework.Assert.isNumber = function (value, name) {
	JJ.Framework.Assert.notNull(value, name);
	if (!JJ.Framework.Check.isNumber(value)) throw name + " is not of type Number.";
}

JJ.Framework.Assert.notNaN = function (value, name) {
	JJ.Framework.Assert.isNumber(value, name);
	if (isNaN(value)) throw name + " is NaN.";
}

JJ.Framework.Assert.notNegative = function (value, name) {
	JJ.Framework.Assert.isNumber(value, name);
	if (value < 0) throw name + " cannot be negative.";
}