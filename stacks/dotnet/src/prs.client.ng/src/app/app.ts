import { Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatDrawer } from '@angular/material/sidenav';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { LayoutModule } from '@angular/cdk/layout';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { map } from 'rxjs';
import { toSignal } from '@angular/core/rxjs-interop';

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
    LayoutModule,
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App implements OnInit {
  @ViewChild('sidenav') sidenav?: MatDrawer;

  private readonly oidcSecurityService = inject(OidcSecurityService);
  private readonly breakpointObserver = inject(BreakpointObserver);

  protected isHandset = false;
  protected sidenavOpened = true;
  protected readonly title = signal('Purchase Request System');
  protected readonly shortTitle = signal('PRS');

  protected isLoggedIn = toSignal(
    this.oidcSecurityService.isAuthenticated$.pipe(map((result) => result.isAuthenticated)),
    { initialValue: false })

  constructor() {}

  ngOnInit(): void {
    this.breakpointObserver.observe([Breakpoints.Handset]).subscribe((result) => {
      this.isHandset = result.matches;
      this.sidenavOpened = !this.isHandset;
    });

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

  toggleSidenav(): void {
    if (this.sidenav) {
      this.sidenav.toggle();
    } else {
      this.sidenavOpened = !this.sidenavOpened;
    }
  }

  closeIfHandset(): void {
    if (this.isHandset) {
      this.sidenav?.close();
    }
  }
}
