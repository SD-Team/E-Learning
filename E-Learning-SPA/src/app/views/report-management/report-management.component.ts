import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

import { ViewRecord } from '../../_core/_models/viewrecord';
import { AuthService } from '../../_core/_services/auth.service';
import { ReportManagementService } from '../../_core/_services/report-management.service';
import { ViewRecordSummary } from '../../_core/_models/viewrecordsummary';
import { User } from '../../_core/_models/user';

@Component({
  selector: 'app-report-management',
  templateUrl: './report-management.component.html',
  styleUrls: ['./report-management.component.css']
})
export class ReportManagementComponent implements OnInit {
  user: User = JSON.parse(localStorage.getItem('user'));
  pageSize: number = 10;
  currentPage: number = 1;
  rowCount: number;
  pageCount: number;
  viewRecords: ViewRecord[];
  viewRecordSummarys: ViewRecordSummary[];
  start: string = '';
  end:  string = '';
  summaryDetail: boolean = true;

  constructor(private reportManagementService: ReportManagementService,
    private spinner: NgxSpinnerService,
    private authService: AuthService,
    private router: Router) {
      this.authService.administrator(this.user.account).subscribe(res => {
        if (!res) {
          this.router.navigate(['/dashboard']);
        }
      });
    }

  ngOnInit() {
    this.getViewRecord();
  }

  getViewRecord() {
    const startDate = String(this.start).substr(0, 15);
    const endDate = String(this.end).substr(0, 15);

    this.spinner.show();
    this.reportManagementService.getViewRecord(this.currentPage, this.pageSize, startDate, endDate).subscribe(res => {
      this.viewRecords = res.result;
      this.currentPage = res.currentPage;
      this.rowCount = res.rowCount;
      this.pageCount = res.pageCount;

      this.spinner.hide();
    });
  }

  getViewRecordSummary() {
    const startDate = String(this.start).substr(0, 15);
    const endDate = String(this.end).substr(0, 15);

    this.spinner.show();
    this.reportManagementService.getViewRecordSummary(this.currentPage, this.pageSize, startDate, endDate).subscribe(res => {
      this.viewRecordSummarys = res.result;
      this.currentPage = res.currentPage;
      this.rowCount = res.rowCount;
      this.pageCount = res.pageCount;

      this.spinner.hide();
    });
  }

  pageChanged(event: any): void {
    this.currentPage = event.page;
    if (!this.summaryDetail) {
      this.getViewRecordSummary();
    } else {
      this.getViewRecord();
    }
  }

  search() {
    this.currentPage = 1;
    if (!this.summaryDetail) {
      this.getViewRecordSummary();
    } else {
      this.getViewRecord();
    }
  }

  summaryOrDetail() {
    this.summaryDetail = !this.summaryDetail;
    this.currentPage = 1;
    if (!this.summaryDetail) {
      this.getViewRecordSummary();
    } else {
      this.getViewRecord();
    }
  }
}
