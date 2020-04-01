import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { DPlayerService } from 'angular-dplayer';

import { AuthService } from '../../_core/_services/auth.service';
import { Video } from '../../_core/_models/video';
import { ViewRecord } from '../../_core/_models/viewrecord';
import { DashboardService } from '../../_core/_services/dashboard.service';
import { User } from '../../_core/_models/user';

@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  user: User = JSON.parse(localStorage.getItem('user'));
  modalRef: BsModalRef;
  config = {
    keyboard: false,
    backdrop: true,
    ignoreBackdropClick: true
  };
  videoByDepts: Video[];
  video: Video = {
    path: '',
    character: '',
    sid: 0,
    status: '',
    subject: '',
    type: ''
  };
  viewRecord: ViewRecord = {
    account: '',
    end_time: '',
    name: '',
    path: '',
    sid: 0,
    start_time: '',
    subject: '',
    work_Id: '',
    factory: '',
    dept: ''
  };

  constructor(private dashboardService: DashboardService,
    private authService: AuthService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService) {
    }

  ngOnInit(): void {
    this.getAllVideo();
  }

  getAllVideoByDept() {
    this.spinner.show();
    this.dashboardService.getAllVideoByDept(this.user.grouP_NAME).subscribe(res => {
      this.videoByDepts = res;
      this.spinner.hide();
    });
  }

  getAllVideo() {
    this.spinner.show();
    this.dashboardService.getAllVideo().subscribe(res => {
      this.videoByDepts = res;
      this.spinner.hide();
    });
  }

  showModal(video: Video, templateModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(templateModal, this.config);
    this.modalRef.setClass('modal-lg');
    this.video = video;
    this.viewRecord.start_time = String(new Date()).toString().substr(0, 24);
  }

  closeModal(videoModal: HTMLVideoElement) {
    videoModal.pause();
    this.modalRef.hide();

    this.viewRecord.account = this.user.account;
    this.viewRecord.name = this.user.name;
    this.viewRecord.work_Id = this.user.optioN1;
    this.viewRecord.path = this.video.path;
    this.viewRecord.subject = this.video.subject;
    this.viewRecord.start_time = this.viewRecord.start_time;
    this.viewRecord.end_time = String(new Date()).toString().substr(0, 24);
    this.viewRecord.factory = this.user.domain;
    this.viewRecord.dept = this.user.grouP_NAME;

    this.dashboardService.saveViewRecord(this.viewRecord).subscribe();

  }

  saveStartVideo(video: Video) {
    this.video = video;

    this.viewRecord.account = this.user.account;
    this.viewRecord.name = this.user.name;
    this.viewRecord.work_Id = this.user.optioN1;
    this.viewRecord.path = this.video.path;
    this.viewRecord.subject = this.video.subject;
    this.viewRecord.start_time = String(new Date()).toString().substr(0, 24);
    this.viewRecord.end_time = String(new Date()).toString().substr(0, 24);
    this.viewRecord.factory = this.user.domain;
    this.viewRecord.dept = this.user.grouP_NAME;

    this.dashboardService.saveViewRecord(this.viewRecord).subscribe();

    window.open(this.video.path, 'blank');
  }
}
