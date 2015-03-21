using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using JetBrains.Annotations;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeTestExtensions
    {
        public static void ShouldBe<T>(this T actual, T expected)
        {
            ShouldBe(actual, expected, null);
        }

        public static void ShouldBe<T>(this T actual, T expected, string additionalInfo)
        {
            if (ShouldlyConfiguration.CompareAsObjectTypes.Contains(typeof(T).FullName) || typeof(T) == typeof(string))
                actual.AssertAwesomely(v => Is.Equal(v, expected, new ObjectEqualityComparer<T>()), actual, expected, additionalInfo);
            else
                actual.AssertAwesomely(v => Is.Equal(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldBe<T>(this IEnumerable<T> actual, IEnumerable<T> expected, bool ignoreOrder = false)
        {
            ShouldBe(actual, expected, ignoreOrder, null);
        }

        public static void ShouldBe<T>(this IEnumerable<T> actual, IEnumerable<T> expected, bool ignoreOrder, string additionalInfo)
        {
            if (!ignoreOrder && ShouldlyConfiguration.CompareAsObjectTypes.Contains(typeof(T).FullName))
            {
                actual.AssertAwesomely(v => Is.Equal(v, expected, new ObjectEqualityComparer<IEnumerable<T>>()), actual, expected, additionalInfo);
            }
            else
            {
                if (ignoreOrder)
                {
                    actual.AssertAwesomelyIgnoringOrder(v => Is.EqualIgnoreOrder(v, expected), actual, expected, additionalInfo);
                }
                else
                {
                    actual.AssertAwesomely(v => Is.Equal(v, expected), actual, expected, additionalInfo);
                }
            }
        }

        public static void ShouldBe(this float actual, float expected, double tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this float actual, float expected, double tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this IEnumerable<double> actual, IEnumerable<double> expected, double tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this IEnumerable<double> actual, IEnumerable<double> expected, double tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this IEnumerable<float> actual, IEnumerable<float> expected, double tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this IEnumerable<float> actual, IEnumerable<float> expected, double tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this double actual, double expected, double tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this double actual, double expected, double tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this decimal actual, decimal expected, decimal tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this decimal actual, decimal expected, decimal tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this IEnumerable<decimal> actual, IEnumerable<decimal> expected, decimal tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this IEnumerable<decimal> actual, IEnumerable<decimal> expected, decimal tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this DateTime actual, DateTime expected, TimeSpan tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this DateTime actual, DateTime expected, TimeSpan tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this DateTimeOffset actual, DateTimeOffset expected, TimeSpan tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this DateTimeOffset actual, DateTimeOffset expected, TimeSpan tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldBe(this TimeSpan actual, TimeSpan expected, TimeSpan tolerance)
        {
            ShouldBe(actual, expected, tolerance, null);
        }

        public static void ShouldBe(this TimeSpan actual, TimeSpan expected, TimeSpan tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        [ContractAnnotation("actual:null,expected:null => halt")]
        public static void ShouldNotBe<T>(this T actual, T expected)
        {
            ShouldNotBe(actual, expected, null);
        }

        [ContractAnnotation("actual:null,expected:null => halt")]
        public static void ShouldNotBe<T>(this T actual, T expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.Equal(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldNotBe(this DateTime actual, DateTime expected, TimeSpan tolerance)
        {
            ShouldNotBe(actual, expected, tolerance, null);
        }

        public static void ShouldNotBe(this DateTime actual, DateTime expected, TimeSpan tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldNotBe(this DateTimeOffset actual, DateTimeOffset expected, TimeSpan tolerance)
        {
            ShouldNotBe(actual, expected, tolerance, null);
        }

        public static void ShouldNotBe(this DateTimeOffset actual, DateTimeOffset expected, TimeSpan tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static void ShouldNotBe(this TimeSpan actual, TimeSpan expected, TimeSpan tolerance)
        {
            ShouldNotBe(actual, expected, tolerance, null);
        }

        public static void ShouldNotBe(this TimeSpan actual, TimeSpan expected, TimeSpan tolerance, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.Equal(v, expected, tolerance), actual, expected, tolerance, additionalInfo);
        }

        public static T ShouldBeAssignableTo<T>(this object actual)
        {
            return ShouldBeAssignableTo<T>(actual, null);
        }

        public static T ShouldBeAssignableTo<T>(this object actual, string additionalInfo)
        {
            ShouldBeAssignableTo(actual, typeof(T), additionalInfo);
            return (T)actual;
        }

        public static void ShouldBeAssignableTo(this object actual, Type expected)
        {
            ShouldBeAssignableTo(actual, expected, null);
        }

        public static void ShouldBeAssignableTo(this object actual, Type expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.InstanceOf(v, expected), actual == null ? null : actual.GetType(), expected, additionalInfo);
        }

        public static T ShouldBeOfType<T>(this object actual)
        {
            return ShouldBeOfType<T>(actual, null);
        }

        public static T ShouldBeOfType<T>(this object actual, string additionalInfo)
        {
            ShouldBeOfType(actual, typeof(T), additionalInfo);
            return (T)actual;
        }

        public static void ShouldBeOfType(this object actual, Type expected)
        {
            ShouldBeOfType(actual, expected, null);
        }

        public static void ShouldBeOfType(this object actual, Type expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => v != null && v.GetType() == expected, actual == null ? null : actual.GetType(), expected, additionalInfo);
        }

        public static void ShouldNotBeAssignableTo<T>(this object actual)
        {
            ShouldNotBeAssignableTo<T>(actual, null);
        }

        public static void ShouldNotBeAssignableTo<T>(this object actual, string additionalInfo)
        {
            ShouldNotBeAssignableTo(actual, typeof(T), additionalInfo);
        }

        public static void ShouldNotBeAssignableTo(this object actual, Type expected)
        {
            ShouldNotBeAssignableTo(actual, expected, null);
        }

        public static void ShouldNotBeAssignableTo(this object actual, Type expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.InstanceOf(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldNotBeOfType<T>(this object actual)
        {
            ShouldNotBeOfType<T>(actual, null);
        }

        public static void ShouldNotBeOfType<T>(this object actual, string additionalInfo)
        {
            ShouldNotBeOfType(actual, typeof(T), additionalInfo);
        }

        public static void ShouldNotBeOfType(this object actual, Type expected)
        {
            ShouldNotBeOfType(actual, expected, null);
        }

        public static void ShouldNotBeOfType(this object actual, Type expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => v == null || v.GetType() != expected, actual, expected, additionalInfo);
        }

        public static void ShouldBeGreaterThan<T>(this T actual, T expected) where T : IComparable<T>
        {
            ShouldBeGreaterThan<T>(actual, expected, null);
        }

        public static void ShouldBeGreaterThan<T>(this T actual, T expected, string additionalInfo) where T : IComparable<T>
        {
            actual.AssertAwesomely(v => Is.GreaterThan(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldBeLessThan<T>(this T actual, T expected) where T : IComparable<T>
        {
            ShouldBeLessThan<T>(actual, expected, null);
        }

        public static void ShouldBeLessThan<T>(this T actual, T expected, string additionalInfo) where T : IComparable<T>
        {
            actual.AssertAwesomely(v => Is.LessThan(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldBeGreaterThanOrEqualTo<T>(this T actual, T expected) where T : IComparable<T>
        {
            ShouldBeGreaterThanOrEqualTo<T>(actual, expected, null);
        }

        public static void ShouldBeGreaterThanOrEqualTo<T>(this T actual, T expected, string additionalInfo) where T : IComparable<T>
        {
            actual.AssertAwesomely(v => Is.GreaterThanOrEqualTo(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldBeLessThanOrEqualTo<T>(this T actual, T expected) where T : IComparable<T>
        {
            ShouldBeLessThanOrEqualTo<T>(actual, expected, null);
        }

        public static void ShouldBeLessThanOrEqualTo<T>(this T actual, T expected, string additionalInfo) where T : IComparable<T>
        {
            actual.AssertAwesomely(v => Is.LessThanOrEqualTo(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldBeSameAs(this object actual, object expected)
        {
            ShouldBeSameAs(actual, expected, null);
        }

        public static void ShouldBeSameAs(this object actual, object expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => Is.Same(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldNotBeSameAs(this object actual, object expected)
        {
            ShouldNotBeSameAs(actual, expected, null);
        }

        public static void ShouldNotBeSameAs(this object actual, object expected, string additionalInfo)
        {
            actual.AssertAwesomely(v => !Is.Same(v, expected), actual, expected, additionalInfo);
        }

        public static void ShouldBeOneOf<T>(this T actual, params T[] expected)
        {
            if (!expected.Contains(actual))
                throw new ShouldAssertException(new ExpectedActualShouldlyMessage(expected, actual).ToString());
        }

        public static void ShouldNotBeOneOf<T>(this T actual, params T[] expected)
        {
            if (expected.Contains(actual))
                throw new ShouldAssertException(new ExpectedActualShouldlyMessage(expected, actual).ToString());
        }

        public static void ShouldBeInRange<T>(this T actual, T from, T to) where T : IComparable<T>
        {
            ShouldBeInRange(actual, from, to, null);
        }

        public static void ShouldBeInRange<T>(this T actual, T from, T to, string additionalInfo) where T : IComparable<T>
        {
            actual.AssertAwesomely(v => Is.InRange(v, from, to), actual, new { from, to }, additionalInfo);
        }

        public static void ShouldNotBeInRange<T>(this T actual, T from, T to) where T : IComparable<T>
        {
            ShouldNotBeInRange(actual, from, to, null);
        }

        public static void ShouldNotBeInRange<T>(this T actual, T from, T to, string additionalInfo) where T : IComparable<T>
        {
            actual.AssertAwesomely(v => !Is.InRange(v, from, to), actual, new { from, to }, additionalInfo);
        }
    }
}
