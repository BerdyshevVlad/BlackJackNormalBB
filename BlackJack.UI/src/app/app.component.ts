import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';
import { debug } from 'util';
import { Observable } from 'rxjs';
import { LogicService } from './logic.service'


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

  constructor(private _http: Http, private _logicService:LogicService ) {
    this.buttonDisabled = false;
  }

  ngOnInit() {
    this._http.get("/api/values").subscribe(result => {
      this.cards = result.json();
    });
  }


  startNewGame() {
    this.playersCards = null;
    this.buttonDisabled = false;
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
    return this.playersCards;
  }

  playAgain() {
    this._http.get("/api/gamelogic/PlayAgain/true").subscribe(result => {
      this.playersCards = result.json();
    });
  }

  playStay() {
    this.buttonDisabled = true;
    this._http.get("/api/gamelogic/PlayAgain/false").subscribe(result => {
      this.playersCards = result.json();
    });
  }

  startNewRound() {
    this.buttonDisabled = false;
    this._http.get("/api/gameLogic/StartNewRound").subscribe(result => {
      this.playersCards = result.json();
    });
  }

  getHistory() {
    this._http.get("/api/gameLogic/getHistory").subscribe(result => {
      this.gameList = result.json();
    });
    console.log(this.gameList.length);
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

export interface Round {
  playerCards: PlayersCards[];
}

export interface GameHistory {
  gamesList: Round[];
}
