import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public learnAngular: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
    this.getString();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getString() {
    this.http.get<{ text: string }>('/weatherforecast/LearnAngular').subscribe(
      (result) => {        
        this.learnAngular = result.text;        
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'app.angular.client';
}
