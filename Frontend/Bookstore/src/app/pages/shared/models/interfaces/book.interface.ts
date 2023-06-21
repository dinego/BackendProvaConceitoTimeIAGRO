import { ISpecifications } from './specifications.interface';

export interface IBook {
  id: number;
  name: string | null;
  price: number;
  specifications: ISpecifications | null;
}
