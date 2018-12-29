import { PurchasedItemDTO } from '../contracts/purchased-item-dto';

export class PurchasedItemVM {

    public name: string;
    public descriptiopn: string;

    constructor(private dto: PurchasedItemDTO) {
        this.name = dto.name;
        this.descriptiopn = dto.description;
    }
}
