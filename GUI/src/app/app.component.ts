import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Content } from './content';
import { Router } from '@angular/router';





@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
})

export class AppComponent  {

  constructor() { }

}