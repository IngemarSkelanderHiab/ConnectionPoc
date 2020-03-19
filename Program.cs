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

            var signalBucket = new SignalBucket();

            await signalBucket.InsertAsync(new Signal {Id = MessageId.Create(), ParameterValue = "1", VariableValue = "11"});
            await signalBucket.InsertAsync(new Signal { Id = MessageId.Create(), ParameterValue = "2", VariableValue = "22"});
            await signalBucket.InsertAsync(new Signal { Id = MessageId.Create(), ParameterValue = "3", VariableValue = "33"});

            ISignalBucketManager bucketManager = new BucketManager();
            bucketManager.Add(connection.Id, signalBucket);

            var parameterBucketReader = bucketManager.GetReader<Parameter>(connection.Id);
            var variableBucketReader = bucketManager.GetReader<Variable>(connection.Id);

            var parameters = await GetAllParametersAsync(parameterBucketReader);
            var variables = await GetAllParametersAsync(variableBucketReader);

            Console.WriteLine("Writing parameters");
            foreach (var parameter in parameters)
            {
                Console.WriteLine(parameter);
            }

            Console.WriteLine();
            Console.WriteLine("Writing variables");
            foreach (var variable in variables)
            {
                Console.WriteLine(variable);
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

        public static async Task<IReadOnlyCollection<Parameter>> GetAllParametersAsync(IBucketReader<Parameter, Signal> reader)
        {
            // IBucketReader reader = await bucketManager.GetReaderAsync(connectionId);
            var parameters = await reader.ReadAllAsync();
            return parameters;
        }

        public static async Task<IReadOnlyCollection<Variable>> GetAllParametersAsync(IBucketReader<Variable, Signal> reader)
        {
            // IBucketReader reader = await bucketManager.GetReaderAsync(connectionId);
            var variables = await reader.ReadAllAsync();
            return variables;
        }
    }
}