import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export type Forecast = {
  date: string;
  temperatureC: number;
  summary: string | null;
}

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  private readonly base = '/api';
  private readonly http = inject(HttpClient);

  getForecasts(): Observable<Forecast[]> {
    return this.http.get<Forecast[]>(`${this.base}/weatherforecast`);
  }
}
