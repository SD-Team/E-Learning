/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SystemManagementService } from './system-management.service';

describe('Service: Systemmanagement', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SystemManagementService]
    });
  });

  it('should ...', inject([SystemManagementService], (service: SystemManagementService) => {
    expect(service).toBeTruthy();
  }));
});
