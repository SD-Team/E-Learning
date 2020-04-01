import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Video } from '../_models/video';
import { environment } from '../../../environments/environment';
import { ViewRecord } from '../_models/viewrecord';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl = environment.apiUrl + 'Home/';

  constructor(private http: HttpClient) { }

  getAllVideoByDept(groupName: string): Observable<Video[]> {
    return this.http.get<Video[]>(this.baseUrl + 'GetAllVideoByDept',
      {
        params: {
          groupName : groupName
        }
      });
  }

  getAllVideo(): Observable<Video[]> {
    return this.http.get<Video[]>(this.baseUrl + 'GetAllVideo');
  }

  saveViewRecord(viewRecord: ViewRecord): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'SaveViewRecord', viewRecord);
  }

  openIE(url: string) {
    debugger
    return this.http.get(this.baseUrl + 'OpenIE', {params: {url: url}});
  }
}
