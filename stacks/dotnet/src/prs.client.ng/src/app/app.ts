import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { map, take } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    RouterOutlet,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatSidenavModule,
    MatListModule,
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App implements OnInit {
  private readonly oidcSecurityService = inject(OidcSecurityService);
  protected readonly title = signal('Purchase Request System');
  protected isLoggedIn$ = this.oidcSecurityService.isAuthenticated$.pipe(take(1), map((result) => result.isAuthenticated));

  constructor() {}

  ngOnInit(): void {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData }) => {});
  }

  get userName(): string | null {
    // get username from client
    return 'TODO';
  }

  onSignIn(): void {
    this.oidcSecurityService.authorize();
  }

  onSignOut(): void {
    this.oidcSecurityService.logoff().subscribe((result) => {
      console.log(result);
    })
  }
}
