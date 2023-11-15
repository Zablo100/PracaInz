export interface InventoryAsset {
    id: number;
    name: string;
    description: string;
    type: number;
    buyingUnit: string;
    costPosition: string;
    fixedAssetClassification: string;
    inventoryNumber: string;
    inventoryBookNumber: number;
    amount: number;
    yearOfPurches: number;
    orginalPrice: number;
}