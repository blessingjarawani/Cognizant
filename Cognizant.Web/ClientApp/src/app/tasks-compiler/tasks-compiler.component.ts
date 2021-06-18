import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CompileCommand } from '../http-services/api/compiler/commands/compile-command';
import { CompilerService } from '../http-services/api/compiler/compiler.service';
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
  taskDescription: string = "";
  solutionCode: string = "";
  form: FormGroup;
  isProcessing: boolean;
  constructor(private fb: FormBuilder, private programmingLanguagesService: ProgrammingLanguagesService,
    private programmingTasksService: ProgrammingTasksService, private compilerService: CompilerService) { }

  ngOnInit() {
    this.getTasks();
    this.getProgrammingLanguages();
    this.buildForm();
    this.form.get("tasks").valueChanges.subscribe(t => { this.setTaskDescription(t) });
    this.form.get("languages").valueChanges.subscribe(t => { this.setsolutionBaseCode(t) });
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
  buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      tasks: ['', Validators.required],
      languages: ['', Validators.required],
      solution: ['', Validators.required],
      description: ['']
    })
  }
  setTaskDescription(taskId: number) {
    if (this.tasks && this.tasks.length > 0) {
      let task = this.tasks.filter(x => x.id == taskId);
      this.taskDescription = task[0].description;
      return;
    }
    this.taskDescription = "";
  }

  setsolutionBaseCode(keyCode: string) {
    if (this.languages && this.languages.length > 0) {
      let language = this.languages.filter(x => x.keyCode == keyCode);
      this.solutionCode = language[0].baseSolutionCode;
      return;
    }
    this.solutionCode = "";
  }
  buildComplieCommand(): CompileCommand {
    let command: CompileCommand = {
      taskId: this.form.get("tasks").value,
      language: this.form.get("languages").value,
      script: this.form.get("solution").value,
      playerName: this.form.get("name").value
    }
    return command;
  }
  submit() {
    this.isProcessing = true;
    let command = this.buildComplieCommand();
    this.compilerService.compile(command)
      .subscribe(t => {
        console.log(t);
        this.isProcessing = false;
      })
  }
}
