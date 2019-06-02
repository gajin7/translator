import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
 
@Injectable({
 providedIn: 'root'
})
export class MssgService {
 
 private StageMessage = new BehaviorSubject('');
 currentApprovalStageMessage = this.StageMessage.asObservable();
 
 constructor() {
 
 }
 updateMessage(message: string) {
 this.StageMessage.next(message)
 }
}