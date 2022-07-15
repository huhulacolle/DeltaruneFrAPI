import { Component, OnInit } from '@angular/core';
import { Chapitre, Staff } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  nom: string = "";
  photo: string = "";
  description: string | undefined = undefined;
  card: string | undefined = undefined;
  lien: string | undefined = undefined;
  nomLien: string | undefined = undefined;

  staffs: Staff[] = [];
  listChapter: number[] = [];

  constructor(
    private deltaruneService: DeltaruneService,
    private verif: VerifaccountService
  ) { }

  ngOnInit(): void {
    this.verif.verifSession();
    this.getAllStaff();
    this.getChapitres();
  }

  setStaff(): void {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.deltaruneService.setStaff(this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, chapitre)
    .subscribe({
      next: () => { this.getAllStaff(); },
      error: (error) => console.error(error)
    })
  }

  getChapitres(): void {
    this.deltaruneService.getChapitres()
    .subscribe({
      next: (data) => {
        for (let i = 1; i <= data[0].chapitre; i++) {
          this.listChapter.push(i)
        }
      },
      error: (error) => console.error(error)
    })
  }

  getAllStaff(): void {
    this.deltaruneService.getAllStaff()
    .subscribe({
      next: (data) => {
        this.staffs = data;
      },
      error: (error) => console.error(error)
    })
  }

  deleteStaff(id: number): void {
    this.deltaruneService.deleteStaff(id)
    .subscribe({
      next: () => { this.getAllStaff(); },
      error: (error) => console.error(error)
    })
  }
}
