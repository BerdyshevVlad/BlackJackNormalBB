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
      debugger;
      this.cards = result.json();
      debugger;
      for (let item of this.cards) {
        console.log(item.id);
      }
      }
    );
  }


  getPlayers() {
    debugger;
    //var ele = document.getElementById("input-player");
    const url = `/api/values/${this.botCount}`;
    this._http.get(url).subscribe(result => {
      debugger;
      this.players = result.json();
      debugger;
      }
    );
  }

  handOverCards() {
    this._http.get("/api/gameLogic").subscribe(result => {
      debugger;
      this.playersCards = result.json();
      debugger;
      console.log(this.playersCards.length);
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
  cardsList: CardData[];
}
