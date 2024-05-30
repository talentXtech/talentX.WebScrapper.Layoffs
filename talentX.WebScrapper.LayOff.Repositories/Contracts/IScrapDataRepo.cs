using talentX.WebScrapper.LayOff.Entities;

namespace talentX.WebScrapper.LayOff.Repositories.Contracts
{
    public interface IScrapDataRepo
    {
        Task AddOutputDataAsync(ScrapOutputData outputData);

        Task AddRangeOutputDataAsync(List<ScrapOutputData> outputDatas);
        Task DeleteOutputDataAsync();

        Task<List<ScrapOutputData>> FindOutputDataAsync();
    }
}
