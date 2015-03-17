using System.Diagnostics;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeStringTestExtensions
    {
        /// <summary>
        /// Perform a string comparison, specifying the desired case sensitivity
        /// </summary>
        public static void ShouldBe(this string actual, string expected, Case caseSensitivity)
        {
            ShouldBe(actual, expected, caseSensitivity, null);
        }

        public static void ShouldBe(this string actual, string expected, Case caseSensitivity, string additionalInfo)
        {
            actual.AssertAwesomely(v => (caseSensitivity == Case.Sensitive)
                ? Is.Equal(v, expected)
                : Is.StringEqualIgnoreCase(v, expected), actual, expected, additionalInfo);
        }

        /// <summary>
        /// Strip out whitespace (whitespace, tabs, line-endings, etc) and compare the two strings
        /// </summary>
        public static void ShouldContainWithoutWhitespace(this string actual, object expected)
        {
            ShouldContainWithoutWhitespace(actual, expected, null);
        }

        public static void ShouldContainWithoutWhitespace(this string actual, object expected, string additionalInfo)
        {
            var strippedActual = actual.Quotify().StripWhitespace();
            var strippedExpected = (expected ?? "NULL").ToString().Quotify().StripWhitespace();

            strippedActual.AssertAwesomely(v => Is.Equal(v, strippedExpected), actual, expected, additionalInfo);
        }

        public static void ShouldStartWith(this string actual, string expected)
        {
            ShouldStartWith(actual, expected, null);
        }

        public static void ShouldStartWith(this string actual, string expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.StringStartingWithIgnoreCase(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldEndWith(this string actual, string expected)
        {
            ShouldEndWith(actual, expected, null);
        }

        public static void ShouldEndWith(this string actual, string expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.EndsWithIgnoringCase(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldNotStartWith(this string actual, string expected)
        {
            ShouldNotStartWith(actual, expected, null);
        }

        public static void ShouldNotStartWith(this string actual, string expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.StringStartingWithIgnoreCase(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldNotEndWith(this string actual, string expected)
        {
            ShouldNotEndWith(actual, expected, null);
        }

        public static void ShouldNotEndWith(this string actual, string expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.EndsWithIgnoringCase(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldContain(this string actual, string expected)
        {
            ShouldContain(actual, expected, null);
        }

        public static void ShouldContain(this string actual, string expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.StringContainingIgnoreCase(v, expected), actual.Clip(100), expected, additionalInfo);
        }

        public static void ShouldNotContain(this string actual, string expected)
        {
            ShouldNotContain(actual, expected, null);
        }

        public static void ShouldNotContain(this string actual, string expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.StringContainingIgnoreCase(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldMatch(this string actual, string regexPattern)
        {
            ShouldMatch(actual, regexPattern, null);
        }

        public static void ShouldMatch(this string actual, string regexPattern, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.StringMatchingRegex(v, regexPattern), actual, regexPattern, additionalInfo);
        }

        public static void ShouldBeNullOrEmpty(this string actual)
        {
            ShouldBeNullOrEmpty(actual, null);
        }

        public static void ShouldBeNullOrEmpty(this string actual, string additionalInfo)
        {
            if (!string.IsNullOrEmpty(actual))
                throw new ShouldAssertException(new ExpectedShouldlyMessage(actual, additionalInfo).ToString());
        }

        public static void ShouldNotBeNullOrEmpty(this string actual)
        {
            ShouldNotBeNullOrEmpty(actual, null);
        }

        public static void ShouldNotBeNullOrEmpty(this string actual, string additionalInfo)
        {
            if (string.IsNullOrEmpty(actual))
                throw new ShouldAssertException(new ExpectedShouldlyMessage(actual, additionalInfo).ToString());
        }

    }
}