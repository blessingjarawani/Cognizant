import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBaseResponse } from '../../responses/i-base-response';
import { CompileCommand } from './commands/compile-command';

@Injectable({
  providedIn: 'root'
})
export class CompilerService {

  constructor(private http: HttpClient) { }

  compile(command: CompileCommand): Observable<IBaseResponse> {
    return this.http.post<IBaseResponse>(`/api/Compiler/Compile`, command);
  }
}
