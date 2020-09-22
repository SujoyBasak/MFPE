using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public interface IBenchmark
    {
        public List<AuditBenchmark> GetNolist();
    }
}
