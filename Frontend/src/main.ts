import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { LandingComponent } from './app/landing/landing.component';
import { MetricDataComponent } from './app/metric-data/metric-data';

bootstrapApplication(MetricDataComponent, {
  providers: [provideHttpClient()],
});
