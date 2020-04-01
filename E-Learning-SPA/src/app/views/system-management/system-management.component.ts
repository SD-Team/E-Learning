import { Component, ViewChild, OnInit, OnChanges } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Select2OptionData } from 'ng-select2';
import { Options } from 'select2';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

import { SystemManagementService } from '../../_core/_services/system-management.service';
import { AlertifyService } from '../../_core/_services/alertify.service';
import { SystemRole } from '../../_core/_models/systemrole';
import { AuthService } from '../../_core/_services/auth.service';
import { User } from '../../_core/_models/user';

@Component({
  selector: 'app-system-management',
  templateUrl: 'system-management.component.html',
  styleUrls: ['./system-management.component.css']
})
export class SystemManagementComponent implements OnInit, OnChanges {
  user: User = JSON.parse(localStorage.getItem('user'));
  @ViewChild('primaryModal') public primaryModal: ModalDirective;
  addForm: FormGroup;
  factories: Array<Select2OptionData>;
  characters: Array<Select2OptionData> = [
    {id: 'Administrator', text: 'Administrator'},
  ];
  character: string = 'Administrator';
  optionsSelect2: Options = {
    theme: 'bootstrap4',
  };
  pageSize: number = 10;
  currentPage: number = 1;
  rowCount: number;
  pageCount: number;
  systemRoles: SystemRole[];
  selectedSystemRoles: SystemRole[];
  dept: string = '';
  name: string = '';
  account: string = '';

  constructor(private systemManagementService: SystemManagementService,
    private fb: FormBuilder,
    private alertify: AlertifyService,
    public authService: AuthService,
    private spinner: NgxSpinnerService,
    private router: Router) {
      this.authService.administrator(this.user.account).subscribe(res => {
        if (!res) {
          this.router.navigate(['/dashboard']);
        }
      });
    }

  ngOnChanges() {}

  ngOnInit() {
    this.getSystemRole();
    this.loadFactories();
    this.createAddForm();
  }

  createAddForm() {
    this.addForm = this.fb.group({
      factory: [],
      account: ['', Validators.required],
      name: ['', Validators.required],
      dept: ['', Validators.required],
      character: [null, Validators.required]
    });
  }

  loadFactories() {
    this.systemManagementService.getFactories().subscribe(res => {
      this.factories = res.map(item => {
        return { id: item.domaiN_NAME, text: item.domaiN_NAME };
      });
    }, error => {
      console.log(error);
    });
  }

  add() {
    this.spinner.show();
    this.systemManagementService.addSystemRole(this.addForm.value).subscribe(res => {
      if (res.resultAdd === 'notexistuser') {
        this.alertify.error('Not exist user. Please select Account another!');

        this.spinner.hide();
      } else
      if (res.resultAdd === 'existsystemrole') {
        this.alertify.error('User already exist. Please select Account another!');

        this.spinner.hide();
      } else
      if (res.resultAdd === 'true') {
        this.alertify.success('Add SystemRole success!');
        this.addForm.reset();
        this.getSystemRole();

        this.spinner.hide();

        this.primaryModal.hide();
      } else {
        this.alertify.error('Add SystemRole faild!');

        this.spinner.hide();
      }
    });
  }

  getSystemRole() {
    this.spinner.show();
    this.systemManagementService.getSystemRole(this.currentPage, this.pageSize).subscribe(res => {
      this.systemRoles = res.result;
      this.currentPage = res.currentPage;
      this.rowCount = res.rowCount;
      this.pageCount = res.pageCount;

      this.spinner.hide();
    });
  }

  pageChanged(event: any): void {
    this.currentPage = event.page;
    this.getSystemRole();
  }

  deleteRoleSelected() {
    this.alertify.confirm('There is a lot of list systemrole deleted. Are you sure you want to delete?', () => {
      this.selectedSystemRoles = this.systemRoles.filter(_ => _.selected);
      // tslint:disable-next-line: forin
      for (const systemRole in this.selectedSystemRoles) {
          this.spinner.show();
          this.systemManagementService.removeSystemRole(this.selectedSystemRoles[systemRole].sid).subscribe(data => {
            if (data) {
              this.alertify.success('Delete successs system fole: Account = ' + this.selectedSystemRoles[systemRole].account);
              this.getSystemRole();
            } else {
              this.alertify.error('Delete failed system fole: Account = ' + this.selectedSystemRoles[systemRole].account);

              this.spinner.hide();
            }
          });
      }
    });
  }

  getNameAndDeptByAccount() {
    this.systemManagementService.getNameAndDetpByAccount(this.account).subscribe(res => {
      this.name = res.name;
      this.dept = res.dept;
    });
  }
}
