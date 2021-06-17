import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { ProgrammingLanguagesService } from '../http-services/api/programming-languages/programming-languages-service';
import { GetProgrammingLanguagesQuery } from '../http-services/api/programming-languages/queries/get-programming-languages-query';
import { ProgrammingTasksService } from '../http-services/api/programming-tasks/programming-tasks-service';
import { GetTasksQuery } from '../http-services/api/programming-tasks/queries/get-tasks-query';
import { ProgrammingLanguagesDTO } from '../http-services/dtos/programming-languages-dto';
import { TasksDTO } from '../http-services/dtos/tasks-dto';
@Component({
  selector: 'app-tasks-compiler',
  templateUrl: './tasks-compiler.component.html',
  styleUrls: ['./tasks-compiler.component.scss']
})
export class TasksCompilerComponent implements OnInit {
  tasks: TasksDTO[];
  languages: ProgrammingLanguagesDTO[];
  constructor(private fb: FormBuilder, private programmingLanguagesService: ProgrammingLanguagesService,
    private programmingTasksService: ProgrammingTasksService) { }

  ngOnInit() {
    this.getTasks();
    this.getProgrammingLanguages();
  }

  getTasks() {
    let query: GetTasksQuery = {};
    this.programmingTasksService.GetAll(query).subscribe(x => {
      console.log(x);
      if (x.isSuccess) {
        this.tasks = x.result;
        console.log(this.tasks);
      }
    })
  }
  getProgrammingLanguages() {
    let query: GetProgrammingLanguagesQuery = {};
    this.programmingLanguagesService.getAll(query).subscribe(x => {
      if (x.isSuccess) {

        this.languages = x.result;
      }
    })
  }
}
