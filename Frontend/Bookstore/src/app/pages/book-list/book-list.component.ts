import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IBook } from '../shared/models/interfaces/book.interface';
import { BookService } from '../shared/services/book/book.service';
import { BaseForm } from './baseform/baseform';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss'],
})
export class BookListComponent {
  bookList: IBook[] = [];
  bookForm: FormGroup;
  baseForm: BaseForm;
  orderBy: string = '';

  constructor(private _bookService: BookService) {
    this.baseForm = new BaseForm();
    this.bookForm = this.baseForm.getForm();
  }

  ngOnInit() {
    this.getBooks();
  }

  getBooks() {
    this._bookService.getBookList().subscribe((res) => {
      this.bookList = res;
    });
  }

  searchBySpecification() {
    const payload = this.baseForm.getPayload();

    if (!payload.searchField || payload.searchField == '') {
      this.getBooks();
      return;
    }

    this._bookService.searchBySpecification(payload).subscribe((res) => {
      this.bookList = res;
    });
  }

  getOrderByDesc() {
    this._bookService.getBookOrderByPriceDesc().subscribe((res) => {
      this.bookList = res;
    });
  }

  getOrderByAsc() {
    this._bookService.getBookOrderByPriceAsc().subscribe((res) => {
      this.bookList = res;
    });
  }
}
