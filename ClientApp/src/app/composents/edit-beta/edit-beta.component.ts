import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-edit-beta',
  templateUrl: './edit-beta.component.html',
  styleUrls: ['./edit-beta.component.css']
})
export class EditBetaComponent implements OnInit {

  id: number = parseInt(<string>this.route.snapshot.paramMap.get('id'));

  nom: string = "";
  photo: string = "";
  description: string | undefined = undefined;
  lien: string | undefined = undefined;
  nomLien: string | undefined = undefined;
  chapitre: number = 0;

  listChapter: number[] = [];

  constructor(
    private deltaruneService: DeltaruneService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getBetaById();
  }

  getBetaById(): void {
    this.deltaruneService.getBetaById(this.id)
    .subscribe({
      next: (data) => {
        const beta = data[0]
        this.nom = beta.nom
        this.photo = beta.photo;
        this.description = beta.description
        this.lien = beta.lien;
        this.nomLien = beta.nomLien;
        this.chapitre = beta.idChapitre;
      },
      error: (error) => console.error(error)
    })
  }

  editBeta() {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.deltaruneService.editBeta(this.id, this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
    .subscribe({
      next: () => this.router.navigateByUrl('/beta'),
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

}
