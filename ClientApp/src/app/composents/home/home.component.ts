import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Chapitre, Staff } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';

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
    private router: Router
  ) { }

  ngOnInit(): void {
    this.verifSession();
    this.getAllStaff();
    this.getChapitres();
  }

  setStaff(): void {
    const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.deltaruneService.setStaff(this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, chapitre).subscribe(
      () => {
        this.getAllStaff();
      }
    )
  }

  getChapitres(): void {
    this.deltaruneService.getChapitres().subscribe(
      data => {
        for (let i = 1; i <= data[0].chapitre; i++) {
          this.listChapter.push(i)
        }
      }
    )
  }

  getAllStaff(): void {
    this.deltaruneService.getAllStaff().subscribe(
      data => {
        this.staffs = data;
      }
    )
  }

  deleteStaff(id: number): void {
    this.deltaruneService.deleteStaff(id).subscribe(
      () => {
        this.getAllStaff();
      }
    )
  }

  verifSession(): void {
    const helper = new JwtHelperService();
    const token = localStorage.getItem('token')?.toString();

    if (!token && helper.isTokenExpired(token)) {
      this.router.navigateByUrl('/');
    }

  }

}
