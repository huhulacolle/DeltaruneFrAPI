import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Staff, StaffdeltaruneClient, Tokens, User, UserdeltaruneClient } from '../clientSwagger/deltaruneClient';

@Injectable({
  providedIn: 'root'
})
export class DeltaruneService {

  constructor(
    private user: UserdeltaruneClient,
    private staff: StaffdeltaruneClient
  ) { }

  public getAccount(user: string, mdp: string): Observable<Tokens> {
    return this.user.getAccount(new User({nom: user, mdp: mdp}));
  }

  // public GetStaff(nom: string, photo: string, description: string | undefined, card: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<Staff> {
  //   let user = new Staff;
  //   user.nom = nom;
  //   user.photo = photo;
  //   user.description = description;
  //   user.card = card;
  //   user.lien = lien;
  //   user.nomLien = nomLien;
  //   user.idChapitre = chapitre;

  //   return this.staff.getStaff(user);
  // }

  public GetStaff(): Observable<Staff[]> {
    return this.staff.getStaff();
  }

  public test(): Observable<string> {
    return this.user.test();
  }

}
