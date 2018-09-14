import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';
import { debug } from 'util';
import { Observable } from 'rxjs';

import { CardData } from './Interfaces/cardData';
import { PlayerData } from './Interfaces/playerData';
import { PlayersCards } from './Interfaces/playersCards';
import { Round } from './Interfaces/Round';
import { GameHistory } from './Interfaces/GameHistory';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  cards: CardData[] = [];
  players: PlayerData[] = [];
  playersCards: PlayersCards[] = [];
  roundList: Round[] = [];
  gameList: GameHistory[] = [];
  botCount: number;
  buttonDisabled: boolean;
 

  constructor(private _http: Http ) {
    this.buttonDisabled = false;
  }

  ngOnInit() {

  }
}








