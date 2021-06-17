import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProgrammingLanguagesDTO } from '../../dtos/programming-languages-dto';
import { IResponse } from '../../responses/i-response';
import { GetProgrammingLanguagesQuery } from './queries/get-programming-languages-query';

@Injectable({
  providedIn: 'root'
})
export class ProgrammingLanguagesServiceService {

  constructor(private http: HttpClient) { }

  getAll(query: GetProgrammingLanguagesQuery): Observable<IResponse<ProgrammingLanguagesDTO[]>> {
    return this.http.post<IResponse<ProgrammingLanguagesDTO[]>>(`/api/ProgrammingLanguages/GetProgrammingLanguages`, query);
  }
}
