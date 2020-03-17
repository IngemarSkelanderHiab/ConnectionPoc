using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ConnectionPoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPrincipal principal = null;
            
            IConnectionManager connectionManager = new ConnectionManager();
            var connection = await connectionManager.CreateConnectionAsync(principal);

            //var parameterBucket = new ParameterBucket();
                        
            //await parameterBucket.InsertAsync(new Parameter { Id = 0, Value = "1" });
            //await parameterBucket.InsertAsync(new Parameter { Id = 1, Value = "2" });
            //await parameterBucket.InsertAsync(new Parameter { Id = 2, Value = "3" });

            var variableBucket = new VariableBucket();
            await variableBucket.InsertAsync(new Variable { Id = 0, Value = "1" });
            await variableBucket.InsertAsync(new Variable { Id = 1, Value = "2" });
            await variableBucket.InsertAsync(new Variable { Id = 2, Value = "3" });

            IBucketManager bucketManager = new BucketManager();
            //bucketManager.Add(connection.Id, parameterBucket);
            bucketManager.Add(connection.Id, variableBucket);

            //var parameterBucketReader = bucketManager.GetReader<Parameter>(connection.Id);
            var variableBucketReader = bucketManager.GetReader<Variable>(connection.Id);

            //var parameters = await parameterBucketReader.ReadAllAsync();
            var variables = await variableBucketReader.ReadAllAsync();
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
