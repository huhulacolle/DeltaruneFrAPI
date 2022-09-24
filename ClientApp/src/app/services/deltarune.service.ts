import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { BetadeltaruneClient, Chapitre, FileResponse, Progression, ProgressiondeltaruneClient, Staff, StaffdeltaruneClient, StaffDR, TraducteurdeltaruneClient, User, UserdeltaruneClient, VoixdeltaruneClient } from '../clientSwagger/deltaruneClient';

@Injectable({
  providedIn: 'root'
})
export class DeltaruneService {

  constructor(
    private user: UserdeltaruneClient,
    private staff: TraducteurdeltaruneClient,
    private progression: ProgressiondeltaruneClient,
    private beta: BetadeltaruneClient,
    private voix: VoixdeltaruneClient,
    private staffDR: StaffdeltaruneClient
  ) { }

  public getAccount(user: string, mdp: string): Promise<string> {
    return lastValueFrom(this.user.getAccount(new User({nom: user, mdp: mdp})));
  }

  public setStaff(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staff.setStaff(new Staff({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public editStaff(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staff.editStaff(new Staff({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public getAllStaff(): Promise<Staff[]> {
    return lastValueFrom(this.staff.getAllStaff());
  }

  public getStaffById(id: number): Promise<Staff[]> {
    return lastValueFrom(this.staff.getStaffById(id)); 
  }

  public getChapitres(): Promise<Chapitre[]> {
    return lastValueFrom(this.staff.getChapitres());
  }

  public editChapitre(chap: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staff.editChapitre(chap));
  }

  public deleteStaff(id: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staff.deleteStaff(id));
  }

  public getProgression(): Promise<Progression[]> {
    return lastValueFrom(this.progression.getProgression());
  }

  public editProgression(progression: Progression): Promise<FileResponse | null> {
    progression.id = 1;
    return lastValueFrom(this.progression.editProgression(progression));
  }

  public getAllBeta(): Promise<Staff[]> {
    return lastValueFrom(this.beta.getAllBeta());
  }

  public deleteBeta(id: number): Promise<FileResponse | null> {
    return lastValueFrom(this.beta.deleteBeta(id));
  }

  public setBeta(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.beta.setBeta(new Staff({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public editBeta(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.beta.editBeta(new Staff({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public getBetaById(id: number): Promise<Staff[]> {
    return lastValueFrom(this.beta.getBetaById(id)); 
  }

  public getProgressionJson(): Promise<FileResponse | null> {
    return lastValueFrom(this.progression.getProgressionJson());
  }

  public GetAllVoix(): Promise<Staff[]> {
    return lastValueFrom(this.voix.getAllVoix());
  }

  public setVoix(nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.voix.setVoix(new Staff({id: 0, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public deleteVoix(id: number): Promise<FileResponse | null> {
    return lastValueFrom(this.voix.deleteVoix(id));
  }

  public editVoix(id: number, nom: string, photo: string, description: string | undefined, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.voix.editVoix(new Staff({id: id, nom: nom, photo: photo, description: description, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public getVoixById(id: number): Promise<Staff[]> {
    return lastValueFrom(this.voix.getVoixById(id));
  }

  public GetAllStaffDR(): Promise<StaffDR[]> {
    return lastValueFrom(this.staffDR.getAllStaff());
  }

  public setStaffDR(nom: string, photo: string, description: string | undefined, card: string, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staffDR.setStaff(new StaffDR({id: 0, nom: nom, photo: photo, description: description, card: card, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public deleteStaffDR(id: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staffDR.deleteStaff(id));
  }

  public editStaffDR(id: number, nom: string, photo: string, description: string | undefined, card: string, lien: string | undefined, nomLien: string | undefined, chapitre: number): Promise<FileResponse | null> {
    return lastValueFrom(this.staffDR.editStaff(new StaffDR({id: id, nom: nom, photo: photo, description: description, card: card, lien: lien, nomLien: nomLien, idChapitre: chapitre})));
  }

  public getStaffByIdDR(id: number): Promise<StaffDR[]> {
    return lastValueFrom(this.staffDR.getStaffById(id));
  }

}
