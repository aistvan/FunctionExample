using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Example.Isolated
{
    public static class UpdateAzureTable
    {
        [Function("UpdateAzureTable")]
        [TableOutput("OutputTable", Connection = "AzureWebJobsStorage")]
        public static MyTableData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            return new MyTableData
            {
                PartitionKey = "UpdateAzureTable",
                RowKey = "RowKey",
                Text = Guid.NewGuid().ToString()
            };
        }
    }
}
