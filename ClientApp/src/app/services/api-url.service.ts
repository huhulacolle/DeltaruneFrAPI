import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiUrlService {

  public apiUrl: string = "";

  load(): void {
    this.apiUrl = environment.url
  }

}

export function apiUrlServiceFactory(apiUrlService: ApiUrlService) {
	return (): void => apiUrlService.load();
}
