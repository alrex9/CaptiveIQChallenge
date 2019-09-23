using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptiveIQTest.Server
{
    public static class DynamoUtils
    {
        public static T GetById<T>(object id)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            var context = new DynamoDBContext(client);
            var result = context.LoadAsync<T>(id).Result;
            return result;
        }

        // Also update
        public static async Task<bool> Insert<T>(this T data)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            var context = new DynamoDBContext(client);
            await context.SaveAsync(data);
            return true;
        }

        public static bool EntryExists<T>(string id)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            var context = new DynamoDBContext(client);
            var scanConditions = new List<ScanCondition>();
            scanConditions.Add(new ScanCondition("Id", ScanOperator.Equal, id));
            var response = context.ScanAsync<T>(scanConditions).GetRemainingAsync().Result;
            var result = response.FirstOrDefault();
            return result != null;
        }
    }
}
