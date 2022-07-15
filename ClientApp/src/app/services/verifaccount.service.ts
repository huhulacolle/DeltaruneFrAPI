import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class VerifaccountService {

  constructor(private router: Router) { }

  verifSession(): void {
    const helper = new JwtHelperService();
    const token = localStorage.getItem('token')?.toString();

    if (!token && helper.isTokenExpired(token)) {
      this.router.navigateByUrl('/');
    }

  }
}
