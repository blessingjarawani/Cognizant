import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GameStatsDTO } from '../../dtos/game-stats-dto';
import { IResponse } from '../../responses/i-response';
import { GetGameStatsTopNQuery } from './queries/get-game-stats-topN-query';

@Injectable({
  providedIn: 'root'
})
export class GameStatsService {

  constructor(private http: HttpClient) { }

  getTopNPlayers(query: GetGameStatsTopNQuery): Observable<IResponse<GameStatsDTO[]>> {
    return this.http.post<IResponse<GameStatsDTO[]>>(`/api/GameStats/GetTopNPlayers`, query);
  }
}
