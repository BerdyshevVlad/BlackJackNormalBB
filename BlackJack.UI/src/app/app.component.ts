import { Component, OnInit,Input } from '@angular/core';
import { Http } from '@angular/http';
import { debug } from 'util';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  cards: CardData[] = [];
  players: PlayerData[] = [];
  playersCards: PlayersCards[] = [];
  botCount: number;
  

  constructor(private _http: Http) {

  }

  ngOnInit() {
    this._http.get("/api/values").subscribe(result=>
    {
      this.cards = result.json();
    });
  }


  getPlayers() {
    debugger;
    //var ele = document.getElementById("input-player");
    const url = `/api/values/${this.botCount}`;
    this._http.get(url).subscribe(result => {
      this.players = result.json();
      }
    );
  }

  handOverCards() {
    this._http.get("/api/gameLogic").subscribe(result => {
      this.playersCards = result.json();
    });
  }

  playAgain() {
    debugger;
    this._http.get("/api/gamelogic/PlayAgain/true").subscribe(result => {
      this.playersCards = result.json();
    });
  }

  playStay() {
    debugger;
    this._http.get("/api/gamelogic/PlayAgain/false").subscribe(result => {
      this.playersCards = result.json();
    });
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
