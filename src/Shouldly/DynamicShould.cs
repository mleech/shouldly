#if net40
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;

namespace Shouldly
{
    [DebuggerStepThrough]
    [ShouldlyMethods]
    public static class DynamicShould
    {
        public static void HaveProperty(dynamic dynamicTestObject, string p)
        {
           HaveProperty(dynamicTestObject, p, null);
        }

        public static void HaveProperty(dynamic dynamicTestObject, string p, string additionalInfo)
        {
            if (dynamicTestObject is IDynamicMetaObjectProvider)
            {
                var dynamicAsDictionary = (IDictionary<string, object>)dynamicTestObject;

                if (!dynamicAsDictionary.ContainsKey(p))
                {
                    throw new ShouldAssertException(new ExpectedShouldlyMessage(p, additionalInfo).ToString());
                }
            }
            else
            {
                var dynamicAsObject = (object)dynamicTestObject;
                if (!dynamicAsObject.GetType().GetProperties().Select(x => x.Name).Contains(p))
                {
                    throw new ShouldAssertException(new ExpectedShouldlyMessage(p, additionalInfo).ToString());
                }
            }
        }
    }
}
#endif