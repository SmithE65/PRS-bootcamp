import { bootstrapApplication } from '@angular/platform-browser';
import { importProvidersFrom } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { OAuthModule } from 'angular-oauth2-oidc';
import { appConfig } from './app/app.config';
import { APP_INITIALIZER } from '@angular/core';
import { AuthService } from './app/core/services/auth.service';
import { routes } from './app/app.routes';
import { App } from './app/app';

bootstrapApplication(App, {
  providers: [
    importProvidersFrom(BrowserModule, HttpClientModule, RouterModule.forRoot(routes), OAuthModule.forRoot()),
    provideAnimations(),
    {
      provide: APP_INITIALIZER,
      useFactory: (auth: AuthService) => () => auth.init(),
      deps: [AuthService],
      multi: true,
    },
    ...(appConfig?.providers ?? [])
  ]
}).catch((err) => console.error(err));
