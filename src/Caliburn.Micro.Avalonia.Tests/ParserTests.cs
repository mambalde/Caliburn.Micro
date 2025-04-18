﻿using System.Globalization;

namespace Caliburn.Micro.Avalonia.Tests
{
    public class ParserTests
    {
        [Fact]
        public void CreateParametersWithOddNumbers()
        {
            var evenResult = Parser.CreateParameter(null, "0.1");
            var oddResult = Parser.CreateParameter(null, "-0.1");
            var nanResult = Parser.CreateParameter(null, "-0.1abc");

            Assert.Equal(0.1, double.Parse((string)evenResult.Value, CultureInfo.InvariantCulture));
            Assert.Equal(-0.1, double.Parse((string)oddResult.Value, CultureInfo.InvariantCulture));
            Assert.Null(nanResult.Value);
        }
    }
}
