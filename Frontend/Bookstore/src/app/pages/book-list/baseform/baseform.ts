import { FormControl, FormGroup } from '@angular/forms';
import { IPayloadBook } from '../../shared/models/interfaces/payloadbook.interface';
import { IBaseForm } from './interface/baseform.interface';

export class BaseForm implements IBaseForm {
  searchField: FormControl;

  constructor() {
    this.searchField = new FormControl('');
  }

  getForm(): FormGroup {
    return new FormGroup({
      searchField: this.searchField,
    });
  }

  getPayload(): IPayloadBook {
    const payload: IPayloadBook = {
      searchField: this.searchField.value,
    };

    return payload;
  }
}
