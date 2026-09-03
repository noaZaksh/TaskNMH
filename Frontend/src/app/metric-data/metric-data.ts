import { Component, OnInit, inject } from '@angular/core';
import { MetricDataService, Metric } from './services/metric-data.service';

@Component({
  selector: 'app-metric-data',
  standalone: true,
  templateUrl: './metric-data.html',
  styleUrl: './metric-data.css',
})
export class MetricDataComponent implements OnInit {
  private metricDataService = inject(MetricDataService);

  metrics: Metric[] = [];
  selectedMetricId: number | null = null;
  selectedFile: File | null = null;
  ngOnInit(): void {
    this.metricDataService.getMetrics().subscribe({
      next: (metrics) => {
        console.log('Metrics received:', metrics);
        this.metrics = metrics;
      },
      error: (error) => {
        console.error('Failed to load metrics:', error);
      },
    });
  }

  onMetricChange(event: Event): void {
    const value = (event.target as HTMLSelectElement).value;

    this.selectedMetricId = value ? Number(value) : null;

    this.selectedFile = null;
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }

  uploadFile(): void {
    if (!this.selectedFile || this.selectedMetricId === null) {
      return;
    }

    console.log('Metric:', this.selectedMetricId);
    console.log('File:', this.selectedFile);

    // כאן נחבר בהמשך ל-API
  }
}
