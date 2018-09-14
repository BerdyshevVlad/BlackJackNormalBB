import { NgModule } from '@angular/core';
import { GameHistoryRoutingModule } from './game-history-routing.module';
import { HistoryListComponent } from './history-list/history-list.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [
    GameHistoryRoutingModule,
    SharedModule
  ],
  declarations: [HistoryListComponent]
})
export class GameHistoryModule { }
