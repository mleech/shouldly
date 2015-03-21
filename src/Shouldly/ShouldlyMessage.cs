﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shouldly.DifferenceHighlighting;
using Shouldly.MessageGenerators;

namespace Shouldly
{
    internal class ExpectedShouldlyMessage : ShouldlyMessage
    {
        public ExpectedShouldlyMessage(object expected, string additionalInfo = null)
        {
            ShouldlyAssertionContext = new ShouldlyAssertionContext(expected);
            ShouldlyAssertionContext.AdditionalInfo = additionalInfo;
        }
    }

    internal class ExpectedActualShouldlyMessage : ShouldlyMessage
    {
        public ExpectedActualShouldlyMessage(object expected, object actual, string additionalInfo = null)
        {
            ShouldlyAssertionContext = new ShouldlyAssertionContext(expected, actual);
            ShouldlyAssertionContext.HasRelevantActual = true;
            ShouldlyAssertionContext.AdditionalInfo = additionalInfo;
        }
    }

    internal class ExpectedActualToleranceShouldlyMessage : ShouldlyMessage
    {
        public ExpectedActualToleranceShouldlyMessage(object expected, object actual, object tolerance, string additionalInfo = null)
        {
            ShouldlyAssertionContext = new ShouldlyAssertionContext(expected, actual);
            ShouldlyAssertionContext.Tolerance = tolerance;
            ShouldlyAssertionContext.HasRelevantActual = true;
            ShouldlyAssertionContext.AdditionalInfo = additionalInfo;
        }
    }

    internal class ExpectedActualIgnoreOrderShouldlyMessage : ShouldlyMessage
    {
        public ExpectedActualIgnoreOrderShouldlyMessage(object expected, object actual, string additionalInfo = null)
        {
            ShouldlyAssertionContext = new ShouldlyAssertionContext(expected, actual);
            ShouldlyAssertionContext.IgnoreOrder = true;
            ShouldlyAssertionContext.HasRelevantActual = true;
            ShouldlyAssertionContext.AdditionalInfo = additionalInfo;
        }
    }

    internal class ExpectedActualKeyShouldlyMessage : ShouldlyMessage
    {
        public ExpectedActualKeyShouldlyMessage(object expected, object actual, object key, string additionalInfo = null)
        {
            ShouldlyAssertionContext = new ShouldlyAssertionContext(expected, actual);
            ShouldlyAssertionContext.Key = key;
            ShouldlyAssertionContext.HasRelevantActual = true;
            ShouldlyAssertionContext.HasRelevantKey = true;
            ShouldlyAssertionContext.AdditionalInfo = additionalInfo;
        }
    }

    internal abstract class ShouldlyMessage
    {
        private static readonly IEnumerable<ShouldlyMessageGenerator> ShouldlyMessageGenerators = new ShouldlyMessageGenerator[]
        {
            new ShouldBeNullOrEmptyMessageGenerator(),  
            new ShouldBeEmptyMessageGenerator(), 
            new ShouldAllBeMessageGenerator(), 
    #if net40
            new DynamicShouldMessageGenerator(), 
    #endif
            new DictionaryShouldOrNotContainKeyMessageGenerator(), 
            new DictionaryShouldContainKeyAndValueMessageGenerator(), 
            new DictionaryShouldNotContainValueForKeyMessageGenerator(),
            new ShouldBeWithinRangeMessageGenerator(), 
            new ShouldContainWithinRangeMessageGenerator(),
            new ShouldBeUniqueMessageGenerator(), 
            new ShouldContainMessageGenerator(), 
            new ShouldContainPredicateMessageGenerator(), 
            new ShouldBeIgnoringOrderMessageGenerator(), 
            new ShouldSatisfyAllConditionsMessageGenerator(),
        };
        private ShouldlyAssertionContext _shouldlyAssertionContext;

        protected ShouldlyAssertionContext ShouldlyAssertionContext
        {
            get { return _shouldlyAssertionContext; }
            set { _shouldlyAssertionContext = value; }
        }

        public override string ToString()
        {
            var message = GenerateShouldMessage();
            if (_shouldlyAssertionContext.AdditionalInfo != null)
            {
                message += string.Format(@"
    Additional Info:
    {0}", _shouldlyAssertionContext.AdditionalInfo);
            }
            return message;
        }

        private string GenerateShouldMessage()
        {
            var messageGenerator = ShouldlyMessageGenerators.FirstOrDefault(x => x.CanProcess(_shouldlyAssertionContext));
            if (messageGenerator != null)
            {
                var message = messageGenerator.GenerateErrorMessage(_shouldlyAssertionContext);
                return message;
            }

            if (_shouldlyAssertionContext.HasRelevantActual)
            {
                return CreateActualVsExpectedMessage(_shouldlyAssertionContext);
            }

            return CreateExpectedErrorMessage();
        }

        public string CreateExpectedErrorMessage()
        {
            var format = @"
    {0}
        {1} {2}
    {3}
        but does{4}";

            var codePart = _shouldlyAssertionContext.CodePart;
            var isNegatedAssertion = _shouldlyAssertionContext.ShouldMethod.Contains("Not");

            const string elementSatifyingTheConditionString = "an element satisfying the condition";
            return string.Format(format, codePart, _shouldlyAssertionContext.ShouldMethod.PascalToSpaced(), _shouldlyAssertionContext.Expected is BinaryExpression ? elementSatifyingTheConditionString : "", _shouldlyAssertionContext.Expected.ToStringAwesomely(), isNegatedAssertion ? "" : " not");
        }

        private string CreateActualVsExpectedMessage(ShouldlyAssertionContext context)
        {
            var codePart = context.CodePart;
            string message = string.Format(@"
    {0}
        {1}
    {2}
        but was
    {3}",
                codePart, context.ShouldMethod.PascalToSpaced(), context.Expected.ToStringAwesomely(), context.Actual.ToStringAwesomely());

            if (DifferenceHighlighter.CanHighlightDifferences(context))
            {
                message += string.Format(@"
        difference
    {0}",
                DifferenceHighlighter.HighlightDifferences(context));
            }
            return message;
        }
    }
}