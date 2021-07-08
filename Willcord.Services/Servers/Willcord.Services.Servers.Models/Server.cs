using EfficientDynamoDb.Attributes;

namespace Willcord.Services.Servers.Models
{
    [DynamoDbTable("willcord-servers")]
    public class Server
    {
        [DynamoDbProperty("Id", DynamoDbAttributeType.PartitionKey)]
        public string Id { get; set; }

        [DynamoDbProperty("Name", DynamoDbAttributeType.SortKey)]
        public string Name { get; set; }

        [DynamoDbProperty("CreatedById")]
        public string CreatedById { get; set; }

        [DynamoDbProperty("DeletedOn")]
        public string DeletedOn { get; set; }

        [DynamoDbProperty("DeletedById")]
        public string DeletedById { get; set; }
    }
}