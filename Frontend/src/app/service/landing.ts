import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LandingService {
  constructor(private http: HttpClient) {}

  getData() {
    return this.http.post(`${environment.apiUrl}/api/Landing/GetLandingData`, {
      UserId: 123,
      Name: 'Noa',
    });
  }
}
