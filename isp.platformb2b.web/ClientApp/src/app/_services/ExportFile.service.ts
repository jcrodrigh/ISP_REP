import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as FileSaver from 'file-saver';
import { DocumentFilter } from '../_models';
const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';

@Injectable({
  providedIn: 'root'
})
export class ExportFileService {
  constructor(private http:HttpClient) { }

    public ExportDataByProvider(documentFilter:DocumentFilter)
    {
        return this.http.post<Blob>(`document/Export/provider`,documentFilter,
      {responseType: 'blob' as 'json'})
      .subscribe(
        blob => {
          this.saveAsBlob(blob,'ExportData.xlsx');
        },
        error => {
          console.log('Something went wrong');
        });
    }

    public ExportDataIVM (documentFilter:DocumentFilter)
    {
      return this.http.post<Blob>(`document/Export/ivm`,documentFilter,
      {responseType: 'blob' as 'json'})
      .subscribe(
        blob => {
          this.saveAsBlob(blob,'ExportData.xlsx');
        },
        error => {
          console.log('Something went wrong');
        });
    }

    private saveAsBlob(data: any,name:string) {
        const blob = new Blob([data],
          {type: EXCEL_TYPE});
        const file = new File([blob],name ,
          {type: EXCEL_TYPE});
    
        FileSaver.saveAs(file);
      }

}
