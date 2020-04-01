/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReportManagementService } from './report-management.service';

describe('Service: ReportManagement', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReportManagementService]
    });
  });

  it('should ...', inject([ReportManagementService], (service: ReportManagementService) => {
    expect(service).toBeTruthy();
  }));
});
