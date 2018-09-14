import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { PlayersCards } from '../../Interfaces/playersCards';
import { debug } from 'util';
import { forEach } from '@angular/router/src/utils/collection';
import { PlayerData } from '../../Interfaces/playerData';
import { Round } from '../../Interfaces/Round';
import { PageChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-history-list',
  templateUrl: './history-list.component.html',
  styleUrls: ['./history-list.component.css']
})
export class HistoryListComponent implements OnInit {

  constructor(private _http: Http) {
  }

  public gridView: GridDataResult;
  public pageSize = 10;
  public skip = 0;
  private data: Object[];

  round: Round[] = [];


  ngOnInit() {
      this._http.get("/api/gameLogic/getHistory").subscribe(result => {
        this.round = result.json();
        this.loadItems();

        var header = document.getElementById("header");
        header.innerHTML = "GAME HISTORY";
      });

  }

  public pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.loadItems();
  }

  private loadItems(): void {
    this.gridView = {
      data: this.round.slice(this.skip, this.skip + this.pageSize),
      total: this.round.length
    };
  }
}
