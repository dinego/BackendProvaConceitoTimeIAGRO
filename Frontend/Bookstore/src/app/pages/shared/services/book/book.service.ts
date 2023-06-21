import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBook } from '../../models/interfaces/book.interface';
import { IPayloadBook } from '../../models/interfaces/payloadbook.interface';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  constructor(private _httpClient: HttpClient) {}

  getBookList(): Observable<IBook[]> {
    return this._httpClient.get<IBook[]>(environment.Book.GetAll);
  }

  searchBySpecification(payload: IPayloadBook): Observable<IBook[]> {
    return this._httpClient.get<IBook[]>(
      `${environment.Book.SortByPrice}?genericSpecification=${payload.searchField}`
    );
  }

  getBookOrderByPriceDesc() {
    return this._httpClient.get<IBook[]>(
      `${environment.Book.SortByPrice}?ordination=DESC`
    );
  }
  getBookOrderByPriceAsc() {
    return this._httpClient.get<IBook[]>(
      `${environment.Book.SortByPrice}?ordination=ASC`
    );
  }
}
