using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.Inventory
{
    public class AddInventoryAssetDTO
    {
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
