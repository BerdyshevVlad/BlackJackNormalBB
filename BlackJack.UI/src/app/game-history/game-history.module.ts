import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GameHistoryRoutingModule } from './game-history-routing.module';
import { HistoryListComponent } from './history-list/history-list.component';
import { FormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    GameHistoryRoutingModule,
    GridModule,
    DropDownsModule
  ],
  declarations: [HistoryListComponent]
})
export class GameHistoryModule { }
