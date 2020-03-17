using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IPrincipal principal = null;

            IConnectionManager connectionManager = new ConnectionManager();
            var connection = await connectionManager.CreateConnectionAsync(principal);

            var parameterBucket = new ParameterBucket();

            await parameterBucket.InsertAsync(new Parameter {Id = MessageId.Create(), Value = "1"});
            await parameterBucket.InsertAsync(new Parameter {Id = MessageId.Create(), Value = "2"});
            await parameterBucket.InsertAsync(new Parameter {Id = MessageId.Create(), Value = "3"});

            IBucketManager bucketManager = new BucketManager();
            bucketManager.Add(connection.Id, parameterBucket);

            var bucketReader = bucketManager.GetReader<Parameter>(connection.Id);

            var parameters = await GetAllParametersAsync(bucketReader);

            foreach (var parameter in parameters)
            {
                Console.WriteLine(parameter);
            }
        }

        public async Task<IConnection> ConnectToSerial(IPrincipal principal, IConnectionManager connectionManager)
        {
            var configuration = new SerialConnectionConfiguration
            {
                Username = "se393",
                Password = "82be",
                PortName = "COM4"
            };

            var connection = await connectionManager.CreateConnectionAsync(principal, configuration);
            await connection.ConnectAsync();

            return connection;
        }

        public async Task<IConnection> ConnectToCan(IPrincipal principal, IConnectionManager connectionManager)
        {
            var connection = await connectionManager.CreateConnectionAsync(principal);
            await connection.ConnectAsync();

            return connection;
        }

        public static async Task<IReadOnlyCollection<Parameter>> GetAllParametersAsync(IBucketReader<Parameter> reader)
        {
            // IBucketReader reader = await bucketManager.GetReaderAsync(connectionId);
            var parameters = await reader.ReadAllAsync();
            return parameters;
        }
    }
}