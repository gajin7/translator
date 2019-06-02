import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewPageComponent } from './new-page/new-page.component';
import { AppComponent } from './app.component';
import { TranslateComponent } from './translate/translate.component';

const routes: Routes = [
  { path: 'home', component:TranslateComponent},
  { path: 'page', component:NewPageComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
