using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

using Amazon;
using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.Lambda.TestUtilities;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

using NetCoreLambdaFunction;
using NetCoreLambdaFunction.Models;

namespace NetCoreLambdaFunction.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestFunction()
        {
            var request = new SampleRequest()
            {
                AnotherProperty = "hola",
                SomeProperty = "adios"
            };

            var context = new TestLambdaContext();
            var function = new Function();

            function.FunctionHandler(request, context);

            var testLogger = context.Logger as TestLambdaLogger;
            Assert.True(testLogger.Buffer.ToString().Contains("Stream processing complete"));
        }  
    }
}
