using pracaInż.Models.DTO.Inventory;
using pracaInż.Models.Entities.CompanyStructure;
using System.Text.Json.Serialization;

namespace pracaInż.Models.Entities.Inventory
{
    public enum DeviceType
    {
        Server,
        NAS,
        Router,
        Switch,
        Computer,
        Laptop,
        Phone,
        Other,
        Printer
    }
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeviceType Type { get; set; }
        public string? IPAddress { get; set; }

    }

    public class InventoryAsset : Device
    {
        public string FixedAssetClassification { get; set; }
        public string InventoryNumber { get; set; }
        public byte InventoryBookNumber { get; set; }
        public short Amount { get; set; }
        public short YearOfPurches { get; set; }
        public decimal OrginalPrice { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public InventoryAsset()
        {
            
        }

        public InventoryAsset(AddInventoryAssetDTO assetDTO)
        {
            Name = assetDTO.Name;
            Description = assetDTO.Description;
            Type = assetDTO.Type;
            FixedAssetClassification = assetDTO.FixedAssetClassification;
            InventoryNumber = assetDTO.InventoryNumber;
            InventoryBookNumber = assetDTO.InventoryBookNumber;
            Amount = assetDTO.Amount;
            YearOfPurches = assetDTO.YearOfPurches;
            OrginalPrice = assetDTO.OrginalPrice;
            DepartmentId = assetDTO.DepartmentId;
        }

        public InventoryAsset(UpdateInventoryAssetDTO assetDTO)
        {
            Id = assetDTO.Id;
            Name = assetDTO.Name;
            Description = assetDTO.Description;
            Type = assetDTO.Type;
            FixedAssetClassification = assetDTO.FixedAssetClassification;
            InventoryNumber = assetDTO.InventoryNumber;
            InventoryBookNumber = assetDTO.InventoryBookNumber;
            Amount = assetDTO.Amount;
            YearOfPurches = assetDTO.YearOfPurches;
            OrginalPrice = assetDTO.OrginalPrice;
            DepartmentId = assetDTO.DepartmentId;
        }
    }
}
