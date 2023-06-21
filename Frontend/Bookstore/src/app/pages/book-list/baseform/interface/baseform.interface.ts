import { FormControl, FormGroup } from '@angular/forms';
import { IPayloadBook } from 'src/app/pages/shared/models/interfaces/payloadbook.interface';

export interface IBaseForm {
  searchField: FormControl;

  getPayload(): IPayloadBook;
  getForm(): FormGroup;
}
