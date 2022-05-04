namespace Bot.Data.Models.HttpModels
{
    public class ProductPurchasesResponse
    {
        public List<ProductPurchaseDto?> Data { get; set; } = new List<ProductPurchaseDto?>();
    }
}
