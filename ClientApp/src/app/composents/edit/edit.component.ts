import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id: number = parseInt(<string>this.route.snapshot.paramMap.get('id'));

  nom: string = "";
  photo: string = "";
  description: string | undefined = undefined;
  card: string | undefined = undefined;
  lien: string | undefined = undefined;
  nomLien: string | undefined = undefined;
  chapitre: number = 0;

  listChapter: number[] = [];

  constructor(
    private verif: VerifaccountService,
    private deltaruneService: DeltaruneService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.verif.verifSession();
    this.getChapitres();
    this.getStaffById();
  }

  editStaff() {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.deltaruneService.editStaff(this.id, this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, chapitre)
    .subscribe({
      next: () => this.router.navigateByUrl('/home'),
      error: (error) => console.error(error)
    })
  }

  getStaffById(): void {
    this.deltaruneService.getStaffById(this.id)
    .subscribe({
      next: (data) => {
        const staff = data[0]
        this.nom = staff.nom
        this.photo = staff.photo;
        this.description = staff.description
        this.card = staff.card;
        this.lien = staff.lien;
        this.nomLien = staff.nomLien;
        this.chapitre = staff.idChapitre;
      },
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
