import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// All pages Need to define
import { LoginComponent } from './pages/admin/login/login.component';




// Add All Modules

/*
this is Main app routing Module
*/

// Define all the rous over hear.
const routes: Routes = [
  {  path: '', component: LoginComponent },
  {  path: 'admin',   component: LoginComponent },

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
