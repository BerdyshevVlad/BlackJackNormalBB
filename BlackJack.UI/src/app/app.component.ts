import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { debug } from 'util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  apiValues: CardData[] = [];
  testString: string;

  constructor(private _http: Http) {

  }

  ngOnInit() {
    debugger;
    this._http.get("/api/values").subscribe(result=>
    {
      this.apiValues = result.json();
      for (let item of this.apiValues) {
        console.log(item.id);
      }
      }
    );
  }

  getTestString() {
    this._http.get("/api/values/3").subscribe(result => {
      debugger;
      this.testString = result.json() as string;
      debugger;
      }
    );
  }

}

export interface CardData {
  id: number;
  value: number;
  suit: string;
  rank: string;
}
