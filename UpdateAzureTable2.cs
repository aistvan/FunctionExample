using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Example.Isolated
{
    public static class UpdateAzureTable2
    {
        [Function("UpdateAzureTable2")]
        [TableOutput("OutputTable", Connection = "AzureWebJobsStorage")]
        public static MyTableData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            [TableInput("OutputTable", "UpdateAzureTable", "RowKey")] MyTableData tableItem,
            FunctionContext executionContext)
        {
            tableItem.Text = Guid.NewGuid().ToString();
            return tableItem;
        }
    }
}
