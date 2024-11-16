namespace TTADotNetCore.RestApi.DataModels
{
    public class UserDataModel
    {
        public int UseId { get; set; }
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Balance { get; set; }
        public string? Pin { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
