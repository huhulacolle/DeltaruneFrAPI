import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BetadeltaruneClient, Chapitre, FileResponse, Progression, ProgressiondeltaruneClient, Staff, TraducteurdeltaruneClient, User, UserdeltaruneClient, VoixdeltaruneClient } from '../clientSwagger/deltaruneClient';

@Injectable({
  providedIn: 'root'
})
export class DeltaruneService {

  constructor(
    private user: UserdeltaruneClient,
    private staff: TraducteurdeltaruneClient,
    private progression: ProgressiondeltaruneClient,
    private beta: BetadeltaruneClient,
    private voix: VoixdeltaruneClient
  ) { }

  public getAccount(user: string, mdp: string): Observable<string> {
    return this.user.getAccount(new User({nom: user, mdp: mdp}));
  }

  public setStaff(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.staff.setStaff(new Staff({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}));
  }

  public editStaff(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.staff.editStaff(new Staff({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}));
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

  public getAllBeta(): Observable<Staff[]> {
    return this.beta.getAllBeta();
  }

  public deleteBeta(id: number): Observable<FileResponse | null> {
    return this.beta.deleteBeta(id);
  }

  public setBeta(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.beta.setBeta(new Staff({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}))
  }

  public editBeta(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.beta.editBeta(new Staff({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}))
  }

  public getBetaById(id: number): Observable<Staff[]> {
    return this.beta.getBetaById(id);
  }

  public getProgressionJson(): Observable<FileResponse | null> {
    return this.progression.getProgressionJson();
  }

  public GetAllVoix(): Observable<Staff[]> {
    return this.voix.getAllVoix();
  }

  public setVoix(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.voix.setVoix(new Staff({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}))
  }

  public deleteVoix(id: number): Observable<FileResponse | null> {
    return this.voix.deleteVoix(id);
  }

  public editVoix(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Observable<FileResponse | null> {
    return this.voix.editVoix(new Staff({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre}))
  }

  public getVoixById(id: number): Observable<Staff[]> {
    return this.voix.getVoixById(id);
  }

}
