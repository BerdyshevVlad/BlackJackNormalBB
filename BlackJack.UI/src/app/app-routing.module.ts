import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { AppComponent } from './app.component';


const routes: Routes = [
 
  { path: '', redirectTo: '', pathMatch: 'full' },
  { path: 'api/[controller]/[action]', component: TestComponent },
  { path: 'api/[controller]/[action]', component: AppComponent },
  {
    path: 'history',
    loadChildren: './game-history/game-history.module#GameHistoryModule'
  },
  {
    path: 'startGame',
    loadChildren: './start-game/start-game.module#StartGameModule'
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[]
})
export class AppRoutingModule { }
