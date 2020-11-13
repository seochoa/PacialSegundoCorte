import { Component, OnInit,Input } from '@angular/core';
import {NgbActiveModal, NgbAlertConfig} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-alert-modal',
  templateUrl: './alert-modal.component.html',
  styleUrls: ['./alert-modal.component.css']
})
export class AlertModalComponent implements OnInit {
  
  @Input() type : string;
  @Input() message;
  constructor() {

   }

  ngOnInit(): void {
  }

}
