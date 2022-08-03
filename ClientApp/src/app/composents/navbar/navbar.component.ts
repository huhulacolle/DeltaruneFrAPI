import { Component, OnInit } from '@angular/core';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  chapitre!: number;

  constructor(
    private verif: VerifaccountService,
    private deltaruneService: DeltaruneService
  ) { }

  ngOnInit(): void {
    this.verif.verifSession();
    this.getChapitres();
  }

  getChapitres(): void {
    this.deltaruneService.getChapitres()
    .subscribe({
      next: (data) => {
        this.chapitre = data[0].chapitre;
      }
    })
  }

  moins(chapitre: number): void {
    this.deltaruneService.editChapitre(--chapitre)
    .subscribe({
      next: () => this.getChapitres(),
      error: (error) => console.error(error)
    })
  }

  plus(chapitre: number): void {
    this.deltaruneService.editChapitre(++chapitre)
    .subscribe({
      next: () => this.getChapitres(),
      error: (error) => console.error(error)
    })
  }


}
