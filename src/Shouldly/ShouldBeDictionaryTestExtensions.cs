using System.Collections.Generic;
using System.Diagnostics;

namespace Shouldly 
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class ShouldBeDictionaryTestExtensions 
    {
        public static void ShouldContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
           ShouldContainKey(dictionary, key, null);
        }

        public static void ShouldContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string additionalInfo)
        {
            if (!dictionary.ContainsKey(key))
                throw new ShouldAssertException(new ExpectedShouldlyMessage(key, additionalInfo).ToString());
        }

        public static void ShouldNotContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
           ShouldNotContainKey(dictionary, key, null);
        }

        public static void ShouldNotContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string additionalInfo)
        {
            if (dictionary.ContainsKey(key))
                throw new ShouldAssertException(new ExpectedShouldlyMessage(key, additionalInfo).ToString());
        }

        public static void ShouldContainKeyAndValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue val)
        {
           ShouldContainKeyAndValue(dictionary, key, val, null);
        }

        public static void ShouldContainKeyAndValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue val, string additionalInfo)
        {
            if (!dictionary.ContainsKey(key))
                throw new ShouldAssertException(new ExpectedActualShouldlyMessage(val, key, additionalInfo).ToString());

            if (!dictionary[key].Equals(val))
                throw new ShouldAssertException(new ExpectedActualKeyShouldlyMessage(val, dictionary[key], key, additionalInfo).ToString());
        }

        public static void ShouldNotContainValueForKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue val)
        {
            ShouldNotContainValueForKey(dictionary, key, val, null);
        }

        public static void ShouldNotContainValueForKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue val, string additionalInfo)
        {
            if (!dictionary.ContainsKey(key))
                throw new ShouldAssertException(new ExpectedActualShouldlyMessage(val, key, additionalInfo).ToString());

            if (dictionary[key].Equals(val))
                throw new ShouldAssertException(new ExpectedActualKeyShouldlyMessage(val, dictionary[key], key, additionalInfo).ToString());
        }
    }
}
