import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { WeatherService } from './weather.service';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'prs-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, MatToolbarModule, MatButtonModule, MatSidenavModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {
  private readonly weatherService = inject(WeatherService);
  forecasts = toSignal(this.weatherService.getForecasts(), {initialValue: []});
}
