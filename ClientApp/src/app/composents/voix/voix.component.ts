import { Component, OnInit } from '@angular/core';
import { Staff } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';

@Component({
  selector: 'app-voix',
  templateUrl: './voix.component.html',
  styleUrls: ['./voix.component.css']
})
export class VoixComponent implements OnInit {

  nom = "";
  photo = "";
  description: string | undefined = undefined;
  card: string | undefined = undefined;
  lien: string | undefined = undefined;
  nomLien: string | undefined = undefined;

  staffs: Staff[] = [];
  listChapter: number[] = [];

  constructor(
    private deltaruneService: DeltaruneService,
  ) { }

  ngOnInit(): void {
    this.GetAllVoix();
    this.getChapitres();
  }

  setVoix(): void {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.deltaruneService.setVoix(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
    .subscribe({
      next: () => { this.GetAllVoix(); },
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

  GetAllVoix(): void {
    this.deltaruneService.GetAllVoix()
    .subscribe({
      next: (data) => {
        this.staffs = data;
      },
      error: (error) => console.error(error)
    })
  }

  deleteVoix(id: number): void {
    this.deltaruneService.deleteVoix(id)
    .subscribe({
      next: () => { this.GetAllVoix(); },
      error: (error) => console.error(error)
    })
  }
}
