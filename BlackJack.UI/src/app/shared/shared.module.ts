import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { HttpModule } from '@angular/http';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    GridModule,
    DropDownsModule,
    HttpModule
  ],
  exports: [CommonModule, FormsModule, DropDownsModule, GridModule, DropDownsModule,
    HttpModule],
  declarations: []
})
export class SharedModule {
  static forRoot(){
    return {
      ngModule: SharedModule
    };
  }
}
