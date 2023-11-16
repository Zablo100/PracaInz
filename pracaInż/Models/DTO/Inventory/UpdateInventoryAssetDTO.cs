using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.Inventory
{
    public class UpdateInventoryAssetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeviceType Type { get; set; }
        public string FixedAssetClassification { get; set; }
        public string InventoryNumber { get; set; }
        public byte InventoryBookNumber { get; set; }
        public short Amount { get; set; }
        public short YearOfPurches { get; set; }
        public decimal OrginalPrice { get; set; }
        public int DepartmentId { get; set; }
    }
}
