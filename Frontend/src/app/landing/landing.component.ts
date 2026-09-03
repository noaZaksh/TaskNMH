import { Component } from '@angular/core';
import { JsonPipe } from '@angular/common';
import { LandingService } from '../service/landing';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [JsonPipe],
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.scss',
})
export class LandingComponent {
  data: any = null;
  error = '';

  constructor(private landingService: LandingService) {}

  getData(): void {
    this.error = '';

    this.landingService.getData().subscribe({
      next: (response: any) => {
        console.log('SERVER RESPONSE:', response);
        this.data = response.message;
      },
      error: (error: any) => {
        console.error('SERVER ERROR:', error);
        this.error = 'אירעה שגיאה בקבלת הנתונים מהשרת';
      },
    });
  }
}
