import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Staff } from 'src/app/clientSwagger/deltaruneClient';
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
  chapitre: number = 0;

  staffs: Staff[] = [];

  constructor(
    private deltaruneService: DeltaruneService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.verifSession();
    this.GetStaff();
  }

  setStaff(): void {
    this.deltaruneService.SetStaff(this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, this.chapitre).subscribe(
      () => {
        this.GetStaff();
      }
    )
  }

  GetStaff(): void {
    this.deltaruneService.GetStaff().subscribe(
      data => {
        this.staffs = data;
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
