import {Injectable, PipeTransform} from '@angular/core';

import {BehaviorSubject, Observable, of, Subject} from 'rxjs';
import {DecimalPipe} from '@angular/common';
import {debounceTime, delay, switchMap, tap} from 'rxjs/operators';
import { Enterprise } from 'src/app/_models';
import { SortDirection } from 'src/app/_directive/sortable.directive';


interface SearchResult {
  documents: Enterprise[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: string;
  sortDirection: SortDirection;
}

function compare(v1, v2) {
  return v1 < v2 ? -1 : v1 > v2 ? 1 : 0;
}

function sort(docs:Enterprise [], column: string, direction: string): Enterprise[] {
  if (direction === '') {
    return docs;
  } else {
    return [...docs].sort((a, b) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(doc: Enterprise, term: string, pipe: PipeTransform) {
  //return "";
  return doc.ruc_empresa.toLowerCase().includes(term)
    || String(doc.logo).includes(term)
    || pipe.transform(doc.razon_social  ).includes(term);
}

@Injectable({providedIn: 'root'})
export class EnterpriseClientService {
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _documents$ = new BehaviorSubject<Enterprise[]>([]);
  private _total$ = new BehaviorSubject<number>(0);

  private _state: State = {
    page: 1,
    pageSize: 10,
    searchTerm: '',
    sortColumn: '',
    sortDirection: ''
  };

  constructor(private pipe: DecimalPipe) {
   this.mecmec();
  }

  public mecmec ()
  {
    this._search$.pipe(
      tap(() => this._loading$.next(true)),
      debounceTime(200),
      switchMap(() => this._search()),
      delay(200),
      tap(() => this._loading$.next(false))
    ).subscribe(result => {
      this._documents$.next(result.documents);
      this._total$.next(result.total);
    });

    this._search$.next();
  }

  get documents$() { return this._documents$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get loading$() { return this._loading$.asObservable(); }
  get page() { return this._state.page; }
  get pageSize() { return this._state.pageSize; }
  get searchTerm() { return this._state.searchTerm; }

  set page(page: number) { this._set({page}); }
  set pageSize(pageSize: number) { this._set({pageSize}); }
  set searchTerm(searchTerm: string) { this._set({searchTerm}); }
  set sortColumn(sortColumn: string) { this._set({sortColumn}); }
  set sortDirection(sortDirection: SortDirection) { this._set({sortDirection}); }
  

  public documentsX:Enterprise[] = [];

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    // 1. sort
    let documents = sort(this.documentsX, sortColumn, sortDirection);

    // 2. filter filter(country => matches(country, searchTerm, this.pipe));
    documents = documents.filter(doc => matches(doc,searchTerm, this.pipe));
    const total = documents.length;

    // 3. paginate
    documents = documents.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({documents, total});
  }
}