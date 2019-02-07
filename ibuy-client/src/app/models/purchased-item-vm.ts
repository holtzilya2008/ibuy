import { PurchaseRecordDTO } from "../contracts/purchased-item-dto";

export class PurchasedItemVM {

    public name: string;
    public descriptiopn: string;

    constructor(private dto: PurchaseRecordDTO) {
        this.name = dto.name;
        this.descriptiopn = dto.description;
    }
}
