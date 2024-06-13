namespace talentX.WebScrapper.LayOff.Entities
{
    public class ApiResponseDto<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; }
    }
}
