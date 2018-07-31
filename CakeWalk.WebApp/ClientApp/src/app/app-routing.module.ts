import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '../../node_modules/@angular/router';

// All pages Need to define
import { LoginComponent } from './pages/login/login.component';



// Add All Modules

/*
this is Main app routing Module
*/

// Define all the rous over hear.
const routes: Routes = [
  {  path: '', component: LoginComponent },
  {  path: 'login',   component: LoginComponent },

];


@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  declarations: [],
  exports: [
    RouterModule
]
})
export class AppRoutingModule { }
