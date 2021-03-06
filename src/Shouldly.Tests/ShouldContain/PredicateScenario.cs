﻿using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldContain
{
    public class PredicateScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            new[] { 1, 2, 3 }.ShouldContain(i => i > 4);
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get { return "new[] { 1, 2, 3 } should contain an element satisfying the condition (i > 4) but does not"; }
        }

        protected override void ShouldPass()
        {
            new[] { 1, 2, 3 }.ShouldContain(i => i < 3);
        }
    }
}