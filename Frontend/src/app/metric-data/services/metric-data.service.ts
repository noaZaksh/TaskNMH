import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface Metric {
  id: number;
  premiumMethodId: number;
  name: string;
  description: string;
  sourceType: string;
  sourceName: string;
  frequency: string;
}

@Injectable({
  providedIn: 'root',
})
export class MetricDataService {
  private http = inject(HttpClient);

  getMetrics(): Observable<Metric[]> {
    return this.http.get<Metric[]>(
      `${environment.apiUrl}/api/Metric/GetAll`,
      {}
    );
  }
}
