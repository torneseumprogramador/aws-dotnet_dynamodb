using System;
using Amazon.DynamoDBv2.DataModel;

namespace dynamodb
{

    [DynamoDBTable("clientes")]
    public class Cliente
    {
        // [DynamoDBHashKey] // Criando Id pelo documento
        // public Guid Id { get; set; }

        // [DynamoDBRangeKey] // campo para ordenação
        // public int Order { get; set; }
        
        [DynamoDBProperty("id")]
        public string Id {get;set;}
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Telefone {get;set;}
        public int Idade {get;set;}

        [DynamoDBIgnore]
        public int Teste {get;set;}

    }
}
