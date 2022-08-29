import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Staff, StaffDR } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  url!: string;

  nom = "";
  photo = "";
  card = "";
  description: string | undefined = undefined;
  lien: string | undefined = undefined;
  nomLien: string | undefined = undefined;

  staffs: Staff[] = [];
  staffsDR: StaffDR[] = []; 
  listChapter: number[] = [];

  constructor(
    private deltaruneService: DeltaruneService,
    private router : Router
  ) { }

  ngOnInit(): void {
    this.getAll();
    this.getChapitres();
    if (this.router.url == "/home") {
      this.url = "/trad"
    }
    else {
      this.url = this.router.url;
    }
  }

  set(): void {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    switch (this.router.url) {
      case "/home":
        this.deltaruneService.setStaff(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
        break;
      case "/beta":
        this.deltaruneService.setBeta(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
        break;
      case "/voix":
        this.deltaruneService.setVoix(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
        break;
      case "/staff":
        this.deltaruneService.setStaffDR(this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, chapitre)
        .subscribe({
          next: () => { this.getAll(); },
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

  getAll(): void {
    switch (this.router.url) {
      case "/home":
        this.deltaruneService.getAllStaff()
        .subscribe({
          next: (data) => {
            this.staffs = data;
          },
          error: (error) => console.error(error)
        })
        break;
      case "/beta":
        this.deltaruneService.getAllBeta()
        .subscribe({
          next: (data) => {
            this.staffs = data;
          },
          error: (error) => console.error(error)
        })
        break;
      case "/voix":
        this.deltaruneService.GetAllVoix()
        .subscribe({
          next: (data) => {
            this.staffs = data;
          },
          error: (error) => console.error(error)
        })
        break;
      case "/staff":
        this.deltaruneService.GetAllStaffDR()
        .subscribe({
          next: (data) => {
            this.staffsDR = data;
          },
          error: (error) => console.error(error)
        })
    }

  }

  delete(id: number): void {
    switch (this.router.url) {
      case "/home":
        this.deltaruneService.deleteStaff(id)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
        break;
      case "/beta":
        this.deltaruneService.deleteBeta(id)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
        break;
      case "/voix":
        this.deltaruneService.deleteVoix(id)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
        break;
      case "/staff":
        this.deltaruneService.deleteStaffDR(id)
        .subscribe({
          next: () => { this.getAll(); },
          error: (error) => console.error(error)
        })
    }
  }
}
