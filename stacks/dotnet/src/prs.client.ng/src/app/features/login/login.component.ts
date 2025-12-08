import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'prs-login',
  standalone: true,
  imports: [CommonModule, RouterModule, MatCardModule, MatButtonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  private readonly auth = inject(OidcSecurityService);
  constructor() {}

  login(): void {
    this.auth.authorize();
  }
}
