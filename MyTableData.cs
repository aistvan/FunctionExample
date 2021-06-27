namespace Example.Isolated
{
    public class MyTableData
    {
        public string ETag { get; } = "*";
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Text { get; set; }
        public MyTableData()
        { }
    }
}
