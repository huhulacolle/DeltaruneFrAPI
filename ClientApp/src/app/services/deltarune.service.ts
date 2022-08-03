import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Beta, BetadeltaruneClient, Chapitre, FileResponse, Progression, ProgressiondeltaruneClient, Staff, StaffdeltaruneClient, Tokens, User, UserdeltaruneClient } from '../clientSwagger/deltaruneClient';

@Injectable({
  providedIn: 'root'
})
export class DeltaruneService {

  constructor(
    private user: UserdeltaruneClient,
    private staff: StaffdeltaruneClient,
    private progression: ProgressiondeltaruneClient,
    private beta: BetadeltaruneClient
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

  public editChapitre(chap: number): Observable<FileResponse | null> {
    return this.staff.editChapitre(chap);
  }

  public deleteStaff(id: number): Observable<FileResponse | null> {
    return this.staff.deleteStaff(id);
  }

  public getProgression(): Observable<Progression[]> {
    return this.progression.getProgression();
  }

  public editProgression(progression: Progression): Observable<FileResponse | null> {
    progression.id = 1;
    return this.progression.editProgression(progression);
  }

  public getAllBeta(): Observable<Beta[]> {
    return this.beta.getAllBeta();
  }

  public deleteBeta(id: number): Observable<FileResponse | null> {
    return this.beta.deleteBeta(id);
  }

  public setBeta(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.beta.setBeta(new Beta({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}))
  }

  public editBeta(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.beta.editBeta(new Beta({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}))
  }

  public getBetaById(id: number): Observable<Beta[]> {
    return this.beta.getBetaById(id);
  }

  public getProgressionJson(): Observable<FileResponse | null> {
    return this.progression.getProgressionJson();
  }

}
