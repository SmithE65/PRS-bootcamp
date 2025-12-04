import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthConfig, OAuthEvent, OAuthService } from 'angular-oauth2-oidc';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly issuer = 'http://localhost:8080/realms/bootcamp';
  private readonly redirectKey = 'prs:redirect';

  constructor(private readonly oauthService: OAuthService, private readonly router: Router) {
    // subscribe to token events to perform post-login redirect
    this.oauthService.events.subscribe((e: OAuthEvent) => {
      if ((e as any)?.type === 'token_received') {
        const target = sessionStorage.getItem(this.redirectKey) ?? '/dashboard';
        sessionStorage.removeItem(this.redirectKey);
        // navigate in next tick
        void Promise.resolve().then(() => this.router.navigateByUrl(target));
      }
    });
  }

  async init(): Promise<void> {
    const authConfig: AuthConfig = {
      issuer: this.issuer,
      clientId: 'prs-angular',
      redirectUri: window.location.origin,
      responseType: 'code',
      scope: 'openid profile email',
      showDebugInformation: false,
      requireHttps: false,
    };

    this.oauthService.configure(authConfig);
    await this.oauthService.loadDiscoveryDocumentAndTryLogin();

    // If already logged in, redirect to dashboard or intended URL
    if (this.oauthService.hasValidAccessToken()) {
      const target = sessionStorage.getItem(this.redirectKey) ?? '/dashboard';
      sessionStorage.removeItem(this.redirectKey);
      void Promise.resolve().then(() => this.router.navigateByUrl(target));
    }
  }

  login(redirectUri?: string): void {
    if (redirectUri) {
      sessionStorage.setItem(this.redirectKey, redirectUri);
    }
    this.oauthService.initCodeFlow();
  }

  logout(): void {
    this.oauthService.logOut();
  }

  isLoggedIn(): boolean {
    return this.oauthService.hasValidAccessToken();
  }

  getAccessToken(): string | null {
    return this.oauthService.getAccessToken();
  }

  getIdentityClaims(): any {
    return this.oauthService.getIdentityClaims();
  }
}
