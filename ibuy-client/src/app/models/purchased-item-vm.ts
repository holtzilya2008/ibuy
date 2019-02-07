import { PurchaseRecordDTO } from "../contracts/purchased-item-dto";

export class PurchasedItemVM {

    public name: string;
    public description: string;

    constructor(private dto: PurchaseRecordDTO) {
        this.name = dto.name;
        this.description = dto.description;
    }
}
