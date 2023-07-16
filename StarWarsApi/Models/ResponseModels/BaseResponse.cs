namespace StarWarsApi.Models.ResponseModels
{
    public  abstract class BaseResponse<T> 
        where T : class
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> results { get; set; }
    }
}
