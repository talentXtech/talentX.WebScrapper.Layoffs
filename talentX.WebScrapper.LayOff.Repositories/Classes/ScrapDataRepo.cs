using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using talentX.WebScrapper.LayOff.Entities;
using talentX.WebScrapper.LayOff.Repositories.Contracts;
using talentX.WebScrapper.LayOff.Repositories.Data;

namespace talentX.WebScrapper.LayOff.Repositories.Classes
{
    public class ScrapDataRepo : IScrapDataRepo
    {
        private readonly DataContext _context;
        private readonly ILogger<ScrapDataRepo> _logger;

        public ScrapDataRepo(DataContext context, ILogger<ScrapDataRepo> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task AddOutputDataAsync(ScrapOutputData outputData)
        {
            try
            {
                if (!_context.ScrapOutputDatas.Any(o => o.elementName == outputData.elementName))
                {
                    await _context.ScrapOutputDatas.AddAsync(outputData);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task AddRangeOutputDataAsync(List<ScrapOutputData> outputDatas) 
        {
            try
            {
                await _context.ScrapOutputDatas.AddRangeAsync(outputDatas);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
        public async Task DeleteOutputDataAsync()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("TRUNCATE TABLE ScrapOutputDatas");
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<List<ScrapOutputData>> FindOutputDataAsync()
        {
            try
            {
                var list = _context.ScrapOutputDatas.ToList();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}
