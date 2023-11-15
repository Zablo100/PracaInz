using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.Inventory
{
    public class InventoryAssetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeviceType Type { get; set; }
        public string BuyingUnit { get; set; }
        public string CostPosition { get; set; }
        public string FixedAssetClassification { get; set; }
        public string InventoryNumber { get; set; }
        public byte InventoryBookNumber { get; set; }
        public short Amount { get; set; }
        public short YearOfPurches { get; set; }
        public decimal OrginalPrice { get; set; }

        public InventoryAssetDTO(InventoryAsset asset)
        {
            Id = asset.Id;
            Name = asset.Name;
            Description = asset.Description;
            Type = asset.Type;
            BuyingUnit = asset.Department.ShortName;
            CostPosition = asset.Department.InvoiceCode;
            FixedAssetClassification = asset.FixedAssetClassification;
            InventoryNumber = asset.InventoryNumber;
            InventoryBookNumber = asset.InventoryBookNumber;
            Amount = asset.Amount;
            YearOfPurches = asset.YearOfPurches;
            OrginalPrice = asset.OrginalPrice;

        }

    }
}
