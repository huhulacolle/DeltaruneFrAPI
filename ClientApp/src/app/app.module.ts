import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './composents/login/login.component';
import { API_BASE_URL, BetadeltaruneClient, ProgressiondeltaruneClient, StaffdeltaruneClient, TraducteurdeltaruneClient, UserdeltaruneClient, VoixdeltaruneClient } from './clientSwagger/deltaruneClient';
import { HomeComponent } from './composents/home/home.component';
import { ApiUrlService, apiUrlServiceFactory } from './services/api-url.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { EditComponent } from './composents/edit/edit.component';
import { NavbarComponent } from './composents/navbar/navbar.component';
import { ProgressionComponent } from './composents/progression/progression.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    EditComponent,
    NavbarComponent,
    ProgressionComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent},
      { path: 'beta', component: HomeComponent},
      { path: 'voix', component: HomeComponent},
      { path: 'staff', component: HomeComponent},
      { path: 'progression', component: ProgressionComponent},
      { path: 'edit/:equipe/:id', component: EditComponent}
    ])
  ],
  providers: [
    UserdeltaruneClient,
    TraducteurdeltaruneClient,
    ProgressiondeltaruneClient,
    BetadeltaruneClient,
    VoixdeltaruneClient,
    StaffdeltaruneClient,
    {
			provide: APP_INITIALIZER,
			useFactory: apiUrlServiceFactory,
			deps: [ApiUrlService],
			multi: true,
		},
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
    { provide: API_BASE_URL, useFactory: (service: ApiUrlService) => service.apiUrl, deps: [ApiUrlService] },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
