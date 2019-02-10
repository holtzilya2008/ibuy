import { PurchaseRecordDTO } from "../contracts/purchased-item-dto";

export class PurchasedItemVM {

    public id: string;
    public name: string;
    public description: string;
    public isSelected: boolean;

    constructor(private dto: PurchaseRecordDTO, public isNew = false) {
        isNew ? this.initNew() : this.initFromDto(dto);
        this.isSelected = false;
    }

    private initNew() {
        this.id = '';
        this.name = '';
        this.description = '';
    }

    private initFromDto(dto: PurchaseRecordDTO) {
        this.id = this.dto.id;
        this.name = this.dto.name;
        this.description = this.dto.description;
    }

    public setDto(dto: PurchaseRecordDTO) {
        this.isNew = false;
        this.dto = dto;
        this.initFromDto(dto);
    }

}
