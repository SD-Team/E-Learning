import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Factory } from '../_models/factory';
import { SystemRole } from '../_models/systemrole';
import { PaginationResult } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class SystemManagementService {
  baseUrl = environment.apiUrl + 'SystemManagement/';

  constructor(private  http: HttpClient) { }

  getFactories(): Observable<Factory[]> {
    return this.http.get<Factory[]>(this.baseUrl + 'GetAllFactory');
  }

  addSystemRole(systemRole: SystemRole): Observable<any> {
    return this.http.post<SystemRole>(this.baseUrl + 'AddSystemRole', systemRole);
  }

  getSystemRole(page: number, pageSize: number): Observable<PaginationResult<SystemRole>> {
    return this.http.get<PaginationResult<SystemRole>>(this.baseUrl + 'GetAllSystemRolePaging/' + page + '/' + pageSize);
  }

  removeSystemRole(sid: number) {
    return this.http.delete(this.baseUrl + 'DeleteSystemRole/' + sid);
  }

  getNameAndDetpByAccount(account: string) {
    return this.http.get<any>(this.baseUrl + 'GetNameAndDetpByAccount?account=' + account);
  }

}
