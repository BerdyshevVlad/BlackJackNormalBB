import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  @Input() players: PlayerData;

  ngOnInit() {
    console.log(this.players);
  }
}

export interface PlayerData {
  id: number;
  name: string;
  playerType: string;
  score: number;
}
