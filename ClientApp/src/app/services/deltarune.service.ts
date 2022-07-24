import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { Chapitre, FileResponse, Progression, ProgressiondeltaruneClient, Staff, StaffdeltaruneClient, Tokens, User, UserdeltaruneClient } from '../clientSwagger/deltaruneClient';

@Injectable({
  providedIn: 'root'
})
export class DeltaruneService {

  constructor(
    private user: UserdeltaruneClient,
    private staff: StaffdeltaruneClient,
    private progression: ProgressiondeltaruneClient
  ) { }

  public getAccount(user: string, mdp: string): Observable<Tokens> {
    return this.user.getAccount(new User({nom: user, mdp: mdp}));
  }

  public setStaff(nom: string, photo: string, description: string | undefined, card: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.staff.setStaff(new Staff({id: 0, nom: nom, photo: photo, description: description, card: card, lien: lien, nomLien: nomLien, idChapitre: chapitre}));
  }

  public editStaff(id: number, nom: string, photo: string, description: string | undefined, card: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.staff.editStaff(new Staff({id: id, nom: nom, photo: photo, description: description, card: card, lien: lien, nomLien: nomLien, idChapitre: chapitre}));
  }

  public getAllStaff(): Observable<Staff[]> {
    return this.staff.getAllStaff();
  }

  public getStaffById(id: number): Observable<Staff[]> {
    return this.staff.getStaffById(id);
  }

  public getChapitres(): Observable<Chapitre[]> {
    return this.staff.getChapitres();
  }

  public deleteStaff(id: number): Observable<FileResponse | null> {
    return this.staff.deleteStaff(id);
  }

  public getProgression(): Observable<Progression[]> {
    return this.progression.getProgression();
  }

  public editProgression(progression: Progression): Observable<any> {
    progression.id = 1;
    return this.progression.editProgression(progression);
  }

}
