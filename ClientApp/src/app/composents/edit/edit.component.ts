import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DeltaruneService } from 'src/app/services/deltarune.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id: number = parseInt(<string>this.route.snapshot.paramMap.get('id'));
  equipe = this.route.snapshot.paramMap.get('equipe');
  url = this.equipe;

  nom = "";
  photo = "";
  card = "";
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
    this.getChapitres();
    this.getById();

    if (this.url == "trad") {
      this.url = "/home"
    }
  }

  edit() {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    switch (this.equipe) {
      case "trad":
        this.deltaruneService.editStaff(this.id, this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
        .subscribe({
          next: () => this.router.navigateByUrl('/home'),
          error: (error) => console.error(error)
        })
        break;
        case "beta":
          this.deltaruneService.editBeta(this.id, this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
          .subscribe({
            next: () => this.router.navigateByUrl('/beta'),
            error: (error) => console.error(error)
          })
          break;
        case "voix":
          this.deltaruneService.editVoix(this.id, this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
          .subscribe({
            next: () => this.router.navigateByUrl('/voix'),
            error: (error) => console.error(error)
          })
          break;
        case "staff":
          this.deltaruneService.editStaffDR(this.id, this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, chapitre)
          .subscribe({
            next: () => this.router.navigateByUrl('/staff'),
            error: (error) => console.error(error)
          })
          break;
    }
  }

  getById(): void {
    switch (this.equipe) {
      case "trad":
        this.deltaruneService.getStaffById(this.id)
        .subscribe({
          next: (data) => {
            const staff = data[0]
            this.nom = staff.nom
            this.photo = staff.photo;
            this.description = staff.description
            this.lien = staff.lien;
            this.nomLien = staff.nomLien;
            this.chapitre = staff.idChapitre;
          },
          error: (error) => console.error(error)
        })
        break;
      case "beta":
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
        break;
      case "voix":
        this.deltaruneService.getVoixById(this.id)
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
        break;
      case "staff":
        this.deltaruneService.getStaffByIdDR(this.id)
        .subscribe({
          next: (data) => {
            const beta = data[0]
            this.nom = beta.nom
            this.photo = beta.photo;
            this.card = beta.card;
            this.description = beta.description
            this.lien = beta.lien;
            this.nomLien = beta.nomLien;
            this.chapitre = beta.idChapitre;
          },
          error: (error) => console.error(error)
        })
        break;
    }
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
