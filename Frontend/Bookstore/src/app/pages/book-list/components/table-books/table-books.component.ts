import { Component, Input, OnInit } from '@angular/core';
import { IBook } from 'src/app/pages/shared/models/interfaces/book.interface';

@Component({
  selector: 'app-table-books',
  templateUrl: './table-books.component.html',
  styleUrls: ['./table-books.component.scss'],
})
export class TableBooksComponent implements OnInit {
  @Input() bookList: IBook[] = [];

  constructor() {}

  ngOnInit() {}
}
