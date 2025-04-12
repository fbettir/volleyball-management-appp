import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SwaggerService {
  private swaggerURL: string = 'api/swagger/v1/swagger.json';

  constructor(private httpClient: HttpClient) { }

  goToSwaggerEndpoint(): void {
    this.httpClient.get(this.swaggerURL);
  }
}
