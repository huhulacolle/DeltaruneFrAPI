import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  chapitre!: number;
  title!: string

  constructor(
    private verif: VerifaccountService,
    private deltaruneService: DeltaruneService,
    private router : Router
  ) { }

  ngOnInit(): void {
    this.verif.verifSession();
    this.getChapitres();
    this.getTitle();
  }

  getTitle(): void {
    switch (this.router.url) {
      case "/home":
        this.title = "Traducteurs"
        break;
      case "/beta":
        this.title = "Beta-Testeurs"
        break;
      case "/voix":
        this.title = "Doubleurs"
        break;
      case "/progression":
        this.title = "Progression"
        break;
      default:
        this.title = "Ryo"
        break;
    }
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
      next: () => window.location.reload(),
      error: (error) => console.error(error)
    })
  }

  plus(chapitre: number): void {
    this.deltaruneService.editChapitre(++chapitre)
    .subscribe({
      next: () => window.location.reload(),
      error: (error) => console.error(error)
    })
  }


}
