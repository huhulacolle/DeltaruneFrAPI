import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Chapitre, FileResponse, Staff, StaffdeltaruneClient, Tokens, User, UserdeltaruneClient } from '../clientSwagger/deltaruneClient';

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

  public setStaff(nom: string, photo: string, description: string | undefined, card: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<any> {
    return this.staff.setStaff(new Staff({id: 0, nom: nom, photo: photo, description: description, card: card, lien: lien, nomLien: nomLien, idChapitre: chapitre}));
  }

  public getAllStaff(): Observable<Staff[]> {
    return this.staff.getAllStaff();
  }

  public getChapitres(): Observable<Chapitre[]> {
    return this.staff.getChapitres();
  }

  deleteStaff(id: number): Observable<FileResponse | null> {
    return this.staff.deleteStaff(id);
  }

  public test(): Observable<string> {
    return this.user.test();
  }

}
