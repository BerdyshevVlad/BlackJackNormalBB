import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    GridModule,
    DropDownsModule
  ],
  exports: [CommonModule, FormsModule, DropDownsModule, GridModule],
  declarations: []
})
export class SharedModule {
  static forRoot(){
    return {
      ngModule: SharedModule
    };
  }
}
