import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { AuthService } from '../../core/services/auth.service';
import { HttpClient } from '@angular/common/http';
import { combineLatest, Observable } from 'rxjs';

type Forecast = {
  date: string;
  temperatureC: number;
  summary: string | null;
}

@Component({
  selector: 'prs-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, MatToolbarModule, MatButtonModule, MatSidenavModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  forecasts: Forecast[] = [];

  constructor(public auth: AuthService, private readonly http: HttpClient) {}

  ngOnInit(): void {
    this.getWeather().subscribe((forecasts) => {
      this.forecasts = forecasts
    })
  }

  getWeather(): Observable<Forecast[]> {
    return this.http.get<Forecast[]>('/api/weatherforecast');
  }
}
