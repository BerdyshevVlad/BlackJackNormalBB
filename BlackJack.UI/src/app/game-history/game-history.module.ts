import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { GameHistoryRoutingModule } from './game-history-routing.module';
import { HistoryListComponent } from './history-list/history-list.component';


@NgModule({
  imports: [
    GameHistoryRoutingModule,
    SharedModule
  ],
  declarations: [HistoryListComponent]
})
export class GameHistoryModule { }
