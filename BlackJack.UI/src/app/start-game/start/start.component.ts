import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';
import { LogicService } from '../../logic.service';
import { Observable } from 'rxjs';

import { CardData } from '../../Interfaces/cardData';
import { PlayerData } from '../../Interfaces/playerData';
import { PlayersCards } from '../../Interfaces/playersCards';
import { Round } from '../../Interfaces/Round';
import { GameHistory } from '../../Interfaces/GameHistory';
import { debug } from 'util';
import { expandAggregates } from '@progress/kendo-data-query/dist/npm/transducers';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

  constructor(private _http: Http, private _logicService: LogicService) {
    this.buttonDisabled = false;
    this.gameIsRunning = false;
  }

  cards: CardData[] = [];
  players: PlayerData[] = [];
  playersCards: PlayersCards[] = [];
  roundList: Round[] = [];
  gameList: GameHistory[] = [];

  botCount: number;
  buttonDisabled: boolean;
  gameIsRunning: boolean;
  newRoundIsStarted: boolean;

  ngOnInit() {
    this._http.get("/api/values").subscribe(result => {
      this.cards = result.json();
    });
  }


  setBotCount() {
    this.playersCards = null;
    this.buttonDisabled = false;

    if (this.botCount > 0 && this.botCount < 6) {
      var inputField = document.getElementById("inputFieldBotCount");
      inputField.style.background = "green";
    }
    else {
      var inputField = document.getElementById("inputFieldBotCount");
      inputField.style.borderColor = "red";
      inputField.style.background = "";
      return;
    }

    const url = `/api/values/${this.botCount}`;
    this._http.get(url).subscribe(result => {
      this.players = result.json();
      this.gameIsRunning = true;
      this.handOverCards();
    }
    );
  }


  handOverCards() {
    this.newRoundIsStarted = true;
    this._http.get("/api/gameLogic").subscribe(result => {
      this.playersCards = result.json();
    });
    return this.playersCards;
  }


  playAgain() {
    this.newRoundIsStarted = false;
    this._http.get("/api/gamelogic/PlayAgain/true").subscribe(result => {
      this.playersCards = result.json();
    });
  }


  playStay() {
    this.newRoundIsStarted = false;
    this.buttonDisabled = true;
    this._http.get("/api/gamelogic/PlayAgain/false").subscribe(result => {
      this.playersCards = result.json();
    });
  }


  startNewRound() {
    this.newRoundIsStarted = true;
    this.buttonDisabled = false;
    this._http.get("/api/gameLogic/StartNewRound").subscribe(result => {
      this.playersCards = result.json();
    });
  }


  startNewGame() {
    this.gameIsRunning = false;
    this.newRoundIsStarted = false;
  }
}

