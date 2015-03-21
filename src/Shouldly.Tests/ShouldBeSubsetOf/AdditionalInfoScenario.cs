﻿using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeSubsetOf
{
    public class AdditionalInfoScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            new[] { 1 }.ShouldBeSubsetOf(new[] { 2, 3, 4 }, "Some additional context");
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return "new[] { 1 } should be subset of  [2, 3, 4] but does not" +
                        " Additional Info:" +
                        " Some additional context";
            }
        }

        protected override void ShouldPass()
        {
            new[] { 1 }.ShouldBeSubsetOf(new[] { 1, 2, 3 }, "Some additional context");
        }
    }
}