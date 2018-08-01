import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';




@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
     ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  declarations: [],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
      ]
})
export class SharedModule { }
