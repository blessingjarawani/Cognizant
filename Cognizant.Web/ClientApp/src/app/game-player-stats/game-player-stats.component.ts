import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { GameStatsService } from '../http-services/api/game-stats/game-stats.service';
import { GetGameStatsTopNQuery } from '../http-services/api/game-stats/queries/get-game-stats-topN-query';
import { GameStatsDTO } from '../http-services/dtos/game-stats-dto';

@Component({
  selector: 'app-game-player-stats',
  templateUrl: './game-player-stats.component.html',
  styleUrls: ['./game-player-stats.component.scss']
})
export class GamePlayerStatsComponent implements OnInit {
  displayedColumns: string[] = ['playerName', 'totalTasksTaken', 'tasksPassed'];
  data: GameStatsDTO[]
  constructor(private gameStatsService: GameStatsService) { }

  ngOnInit() {
    this.getData();
  }

  getData() {
    let query: GetGameStatsTopNQuery = {};
    this.gameStatsService.getTopNPlayers(query)
      .subscribe(t => {
        console.log(t);
        if (t.isSuccess) {
          this.data = t.result;
        }
      });
  }
}
