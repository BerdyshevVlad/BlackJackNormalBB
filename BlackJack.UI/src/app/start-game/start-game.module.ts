import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { StartGameRoutingModule } from './start-game-routing.module';
import { StartComponent } from './start/start.component';
import { AppModule } from '../app.module';

@NgModule({
  imports: [
    StartGameRoutingModule,
    SharedModule
  ],
  declarations: [StartComponent]
})
export class StartGameModule { }
