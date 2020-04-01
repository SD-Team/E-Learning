import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginationResult } from '../_models/pagination';
import { ViewRecord } from '../_models/viewrecord';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { ViewRecordSummary } from '../_models/viewrecordsummary';

@Injectable({
  providedIn: 'root'
})
export class ReportManagementService {
  baseUrl = environment.apiUrl + 'ReportManagement/';

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: max-line-length
  getViewRecord(page: number, pageSize: number, startDate: string, endDate: string, detailOrSummary: boolean = true): Observable<PaginationResult<ViewRecord>> {
    // tslint:disable-next-line: max-line-lengths
    if (startDate === '' || endDate === '' || startDate === 'null' || endDate === 'null') {
      // tslint:disable-next-line: max-line-length
        return this.http.get<PaginationResult<ViewRecord>>(this.baseUrl + 'GetAllViewRecordPaging?page=' + page + '&pageSize=' + pageSize + '&detailOrSummary=' + detailOrSummary);
    }
    // tslint:disable-next-line: max-line-length
    return this.http.get<PaginationResult<ViewRecord>>(this.baseUrl + 'GetAllViewRecordPaging?page=' + page + '&pageSize=' + pageSize + '&startDate=' + startDate + '&endDate=' + endDate + '&detailOrSummary=' + detailOrSummary);
  }

  // tslint:disable-next-line: max-line-length
  getViewRecordSummary(page: number, pageSize: number, startDate: string, endDate: string, detailOrSummary: boolean = false): Observable<PaginationResult<ViewRecordSummary>> {
    // tslint:disable-next-line: max-line-lengths
    if (startDate === '' || endDate === '' || startDate === 'null' || endDate === 'null') {
      // tslint:disable-next-line: max-line-length
        return this.http.get<PaginationResult<ViewRecordSummary>>(this.baseUrl + 'GetAllViewRecordPaging?page=' + page + '&pageSize=' + pageSize + '&detailOrSummary=' + detailOrSummary);
    }
    // tslint:disable-next-line: max-line-length
    return this.http.get<PaginationResult<ViewRecordSummary>>(this.baseUrl + 'GetAllViewRecordPaging?page=' + page + '&pageSize=' + pageSize + '&startDate=' + startDate + '&endDate=' + endDate + '&detailOrSummary=' + detailOrSummary);
  }
}
