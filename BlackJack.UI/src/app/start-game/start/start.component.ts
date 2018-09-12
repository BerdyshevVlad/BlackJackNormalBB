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
    this.moreButtonDisabled = false;
    this.gameIsRunning = false;
    this.stayButtonDisabled = false;
  }

  cards: CardData[] = [];
  players: PlayerData[] = [];
  playersCards: PlayersCards[] = [];
  winner: PlayersCards[] = [];
  roundList: Round[] = [];
  gameList: GameHistory[] = [];
  maxWinScore: number = 21;

  userName: string = "You";
  botCount: number;
  moreButtonDisabled: boolean;
  stayButtonDisabled: boolean;
  gameIsRunning: boolean;
  newRoundIsStarted: boolean;

  ngOnInit() {
    this._http.get("/api/values").subscribe(result => {
      this.cards = result.json();
    });
  }


  setBotCount() {
    this.playersCards = null;
    this.moreButtonDisabled = false;

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

      for (var i = 0; i < this.playersCards.length; i++) {
        if (this.playersCards[i].player.score >= this.maxWinScore && this.playersCards[i].player.name == this.userName) {
          this.defineTheWinner();
          this.moreButtonDisabled = true;
          this.stayButtonDisabled = true;
        }
      }

    });
  }


  playStay() {
    this.newRoundIsStarted = false;
    this.moreButtonDisabled = true;
    this._http.get("/api/gamelogic/PlayAgain/false").subscribe(result => {
      this.playersCards = result.json();
      this.defineTheWinner();
    });
  }


  defineTheWinner() {
    this._http.get("/api/gamelogic/DefineTheWinner").subscribe(result => {
      this.winner = result.json();
    });
  }


  startNewRound() {
    this.newRoundIsStarted = true;
    this.moreButtonDisabled = false;
    this.stayButtonDisabled = false;
    this._http.get("/api/gameLogic/StartNewRound").subscribe(result => {
      this.playersCards = result.json();
    });
  }


  startNewGame() {
    this.gameIsRunning = false;
    this.newRoundIsStarted = false;
    this.stayButtonDisabled = false;
  }


}

