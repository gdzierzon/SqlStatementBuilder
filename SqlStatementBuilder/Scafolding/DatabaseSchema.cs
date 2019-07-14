namespace SqlStatementBuilder.Scafolding
{
    public class DatabaseSchema
    {
        public string SchemaName { get; set; }

        public DatabaseSchema(string name)
        {
            SchemaName = name;
        }

        public override string ToString()
        {
            return $"[{SchemaName}]";
        }
    }
}