import { PurchaseRecordDTO } from "../contracts/purchased-item-dto";

export class PurchasedItemVM {

    public id: string;
    public name: string;
    public description: string;

    constructor(private dto: PurchaseRecordDTO) {
        this.id = dto.id;
        this.name = dto.name;
        this.description = dto.description;
    }
}
