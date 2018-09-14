import { NgModule } from '@angular/core';
import { StartGameRoutingModule } from './start-game-routing.module';
import { StartComponent } from './start/start.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    StartGameRoutingModule,
    SharedModule
  ],
  declarations: [StartComponent]
})
export class StartGameModule { }
