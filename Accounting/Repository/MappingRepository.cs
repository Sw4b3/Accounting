using Accounting.Models.Models;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    class MappingRepository : BaseRepository, IMappingRepository
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public MappingRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Mapping> GetMappingRequest()
        {
            return Get<Mapping>(DatabaseConnection.connection, SQLStoredProcedures.spGetMappings , _connection, _transaction);
        }
    }
}
