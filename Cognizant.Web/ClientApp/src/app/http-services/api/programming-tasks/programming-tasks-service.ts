import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TasksDTO } from '../../dtos/tasks-dto';
import { IResponse } from '../../responses/i-response';
import { GetTasksQuery } from './queries/get-tasks-query';

@Injectable({
  providedIn: 'root'
})
export class ProgrammingTasksService {

  constructor(private http: HttpClient) { }

  GetAll(query: GetTasksQuery): Observable<IResponse<TasksDTO[]>> {
    return this.http.post<IResponse<TasksDTO[]>>(`/api/ProgrammingTasks/GetTasks`, query);
  }

}
