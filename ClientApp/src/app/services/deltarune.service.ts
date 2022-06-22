import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tokens, User, UserdeltaruneClient } from '../clientSwagger/deltaruneClient';

@Injectable({
  providedIn: 'root'
})
export class DeltaruneService {

  constructor(
    private user: UserdeltaruneClient
  ) { }

  public getAccount(user: User): Observable<Tokens> {
    return this.user.getAccount(user);
  }

  public test(): Observable<string> {
    return this.user.test();
  }

}
