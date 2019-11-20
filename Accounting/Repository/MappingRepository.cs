using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System.Collections.Generic;
using System.Data;

namespace Accounting.Repository
{
    public class MappingRepository : BaseRepository, IMappingRepository
    {

        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public MappingRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Mapping> GetMappingRequest()
        {
            return Get<Mapping>(DatabaseConnection.connection, SQLStoredProcedures.getMappings, _connection, _transaction);
        }

        public void SaveMapping(SaveMappingRequest request)
        {
            Save(DatabaseConnection.connection, SQLStoredProcedures.saveMapping, request, _connection, _transaction);
        }

        public void DeleteMapping(DeleteMappingRequest request)
        {
            Delete(DatabaseConnection.connection, SQLStoredProcedures.deleteMapping, request, _connection, _transaction);
        }
    }
}
