using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.Strings.ShouldBeNullOrEmpty
{
    public class AdditionalInfoScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            "a".ShouldBeNullOrEmpty("Some additional context");
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return "\"a\" should be null or empty" +
                       "Additional Info:" +
                       "Some additional context";
            }
        }

        protected override void ShouldPass()
        {
            string.Empty.ShouldBeNullOrEmpty("Some additional context");
        }
    }
}