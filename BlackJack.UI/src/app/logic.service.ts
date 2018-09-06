import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

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



export interface CardData {
  id: number;
  value: number;
  suit: string;
  rank: string;
}

export interface PlayerData {
  id: number;
  name: string;
  playerType: string;
  score: number;
}

export interface PlayersCards {
  player: PlayerData;
  cards: CardData[];
}
