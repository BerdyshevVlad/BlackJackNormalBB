import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { StartGameRoutingModule } from './start-game-routing.module';
import { StartComponent } from './start/start.component';
import { AppModule } from '../app.module';

@NgModule({
  imports: [
    CommonModule,
    StartGameRoutingModule,
    FormsModule
  ],
  declarations: [StartComponent]
})
export class StartGameModule { }
