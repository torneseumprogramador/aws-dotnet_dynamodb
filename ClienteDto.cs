using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

namespace dynamodb
{
    public static class ClienteDto
    {
        // doc
        // https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/DynamoDBContext.QueryScan.html

        private static BasicAWSCredentials awsCredentials = new BasicAWSCredentials(Environment.GetEnvironmentVariable("AWS_KEY"), Environment.GetEnvironmentVariable("AWS_SECRET")); 
        public static async Task SalvarAsync(this Cliente cliente)
        {
            var client = new AmazonDynamoDBClient(awsCredentials, RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);
            await context.SaveAsync(cliente);
        }

        public static async Task<Cliente> Find(string id)
        {
            var client = new AmazonDynamoDBClient(awsCredentials, RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);

            return await context.LoadAsync<Cliente>(id);
        }

        public static async Task<List<Cliente>> Todos()
        {
            var client = new AmazonDynamoDBClient(awsCredentials, RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);

            var conditions = new List<ScanCondition>();
            // conditions.Add(new ScanCondition("Nome", ScanOperator.Equal, "Danilo"));
            // conditions.Add(new ScanCondition("Nome", ScanOperator.Contains, "Danilo"));
            var allDocs = await context.ScanAsync<Cliente>(conditions).GetRemainingAsync();
            return allDocs;
        }
    }
}
