using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using NetCoreLambdaFunction.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace NetCoreLambdaFunction
{
    public class Function
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public void FunctionHandler(SampleRequest request, ILambdaContext context)
        {
            var jsonRequest = SerializeStreamRecord(request);
            context.Logger.LogLine($"Beginning to process {jsonRequest} request...");
            context.Logger.LogLine("Request processing complete.");
        }

        private string SerializeStreamRecord(Object item)
        {
            using (var writer = new StringWriter())
            {
                _jsonSerializer.Serialize(writer, item);
                return writer.ToString();
            }
        }
    }
}