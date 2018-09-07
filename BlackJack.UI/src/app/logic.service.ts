import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { CardData } from './Interfaces/cardData';
import { PlayerData } from './Interfaces/playerData';
import { PlayersCards } from './Interfaces/playersCards';

@Injectable({
  providedIn: 'root'
})
export class LogicService {


  playersCards2: PlayersCards[] = [];


  constructor(private _http: Http) { }

  handOverCards() {
    this._http.get("/api/gameLogic").subscribe(result => {
      this.playersCards2 = result.json();
    });
    return this.playersCards2;
  }
}
