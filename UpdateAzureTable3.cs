using System;
using System.Linq;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Example.Isolated
{
    public static class UpdateAzureTable3
    {
        [Function("UpdateAzureTable3")]
        [TableOutput("OutputTable", Connection = "AzureWebJobsStorage")]
        public static MyTableData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            [TableInput("OutputTable", "UpdateAzureTable", "{Header:Host[0]}")] MyTableData tableItem,
            FunctionContext executionContext)
        {
            string host = string.Empty;

            if (req.Headers.TryGetValues("Host", out var hostValues))
            {
                // I want to bind for this rowkey, what I have to put upper there, instead of "Header:Host[0]"
                host = hostValues
                    .FirstOrDefault()
                    .Split(new char[] { ',' })
                    .FirstOrDefault()
                    .Split(new char[] { ':' })
                    .FirstOrDefault();
            }

            if (tableItem == null)
            {
                tableItem = new MyTableData
                {
                    PartitionKey = "UpdateAzureTable",
                    RowKey = host,
                    Text = Guid.NewGuid().ToString()
                };
            }

            tableItem.Text = Guid.NewGuid().ToString();
            return tableItem;
        }
    }
}
