import { Component, OnInit } from '@angular/core';
import { MssgService } from '../message-sender.service';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.css']
})
export class NewPageComponent implements OnInit {

  TranslatedText = '';
  constructor(private mssgService:MssgService) { }

  ngOnInit() {
    this.mssgService.currentApprovalStageMessage.subscribe(msg => this.TranslatedText = msg);
  }

  

}
