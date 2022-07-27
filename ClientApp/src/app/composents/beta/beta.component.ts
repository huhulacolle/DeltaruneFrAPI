import { Component, OnInit } from '@angular/core';
import { Beta } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-beta',
  templateUrl: './beta.component.html',
  styleUrls: ['./beta.component.css']
})
export class BetaComponent implements OnInit {

  nom: string = "";
  photo: string = "";
  description: string | undefined = undefined;
  lien: string | undefined = undefined;
  nomLien: string | undefined = undefined;

  betas: Beta[] = [];
  listChapter: number[] = [];


  constructor(
    private deltaruneService: DeltaruneService,
    private verif: VerifaccountService
  ) { }

  ngOnInit(): void {
    this.verif.verifSession();
    this.getAllBeta();
    this.getChapitres();
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

  getAllBeta(): void {
    this.deltaruneService.getAllBeta()
    .subscribe({
      next: (data) => {
        this.betas = data;
        console.log(this.betas);
      },
      error: (error) => console.error(error)
    })
  }

  deleteBeta(id: number): void {
    this.deltaruneService.deleteBeta(id)
    .subscribe({
      next: () => { this.getAllBeta(); },
      error: (error) => console.error(error)
    })
  }

  setBeta(): void {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.deltaruneService.setBeta(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
    .subscribe({
      next: () => { this.getAllBeta(); },
      error: (error) => console.error(error)
    })
  }

}
