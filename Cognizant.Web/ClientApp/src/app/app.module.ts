import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { TasksCompilerComponent } from './tasks-compiler/tasks-compiler.component';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { A11yModule } from '@angular/cdk/a11y';
import { BidiModule } from '@angular/cdk/bidi';
import { OverlayModule } from '@angular/cdk/overlay';
import { PlatformModule } from '@angular/cdk/platform';
import { ObserversModule } from '@angular/cdk/observers';
import { PortalModule } from '@angular/cdk/portal';
import { ReactiveFormsModule } from '@angular/forms';
import { GamePlayerStatsComponent } from './game-player-stats/game-player-stats.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TasksCompilerComponent,
    GamePlayerStatsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CdkTableModule,
    A11yModule,
    BidiModule,
    CdkAccordionModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    BrowserAnimationsModule,
    PortalModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: TasksCompilerComponent, pathMatch: 'full' },
      { path: 'tasks-compiler', component: TasksCompilerComponent },
      { path: 'game-player-stats', component: GamePlayerStatsComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
