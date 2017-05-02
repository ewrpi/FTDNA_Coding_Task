import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { SamplesComponent } from './components/fetchdata/displaysamples.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { WebAPIComponent } from './components/fetchdata/webapi.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
		SamplesComponent,
		WebAPIComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
			{ path: 'fetch-data', component: FetchDataComponent },
			{ path: 'samples', component: SamplesComponent },
			{ path: 'web-api', component: WebAPIComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
