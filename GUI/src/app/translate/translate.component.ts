import { Component, OnInit} from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { AppService } from '../app.service';
import { MssgService } from '../message-sender.service';
import { Content } from '../content';



@Component({
  selector: 'translate-root',
  templateUrl: 'translate.component.html',
  styleUrls: ['translate.component.css'],
})

export class TranslateComponent implements OnInit {
  contents : string[];
  name: string = '';
  TranslatedText : string = '';
  
 

  constructor(private service: AppService, private router: Router,private mssgService:MssgService) { }

  ngOnInit() {
    
  }

  SendTranslatedText()
 {
 
    this.mssgService.updateMessage(this.TranslatedText);
 }

 
  Translate(value : string) : void 
  {
     this.service.sendText({value} as Content)
       .subscribe(content => { this.contents = content});

       this.TranslatedText = this.contents.toString();

       this.SendTranslatedText();

       this.router.navigate(['page']);
       
  }
  
}
