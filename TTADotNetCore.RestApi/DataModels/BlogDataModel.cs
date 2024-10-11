namespace TTADotNetCore.RestApi.DataModels
{
    public class BlogDataModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
