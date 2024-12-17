using CDNConverter.API.Domain.Entities;
using CDNConverter.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDNConverter.API.Infrastructure.DataAccess.Repositories
{
    public class LogRepository : ILogReadOnlyRepository, ILogWriteOnlyRepository
    {
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<OriginalLog> GetAllOriginalsLogs()
        {
            return _context.OriginalLogs.ToList();
        }

        public OriginalLog GetOriginalLogById(Guid id)
        {
            return _context.OriginalLogs.FirstOrDefault(l => l.Id == id);
        }

        public async Task SaveLog(OriginalLog log)
        {
            await _context.OriginalLogs.AddAsync(log);
        }

        public async Task SaveConvertedLog(ConvertedLog convertedLog)
        {
            await _context.ConvertedLogs.AddAsync(convertedLog);
        }

        public IList<ConvertedLog> GetAllConvertedLogs()
        {
            return _context.ConvertedLogs.ToList();
        }

        public async Task<ConvertedLog> GetConvertedLogById(Guid id)
        {
            var convertedLog = _context.ConvertedLogs.FirstOrDefault(l => l.Id == id);

            if (convertedLog != null)
                await _context.Entry(convertedLog).Reference(c => c.OriginalLog).LoadAsync();

            return convertedLog;
        }

        public async Task<bool> ExistConvertedLogAsync(Guid id) =>
            await _context.ConvertedLogs.AnyAsync(t => t.OriginalLogId == id);
    }
}
