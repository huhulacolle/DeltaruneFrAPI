import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  nom: string = "";
  mdp: string = "";

  testprod = environment.production

  session: boolean = false;

  constructor(
    private deltaruneService: DeltaruneService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.verifSession();
  }

  test(): void {
    this.deltaruneService.test().subscribe(data => {
      console.log("réponse : " + data);
    })
  }

  verifSession(): void {
    const helper = new JwtHelperService();
    const token = localStorage.getItem('token')?.toString();
    if (token && !helper.isTokenExpired(token)) {
      this.router.navigateByUrl('/home');
    }
  }

  public getUser(): void {

    if (this.nom == "" || this.mdp == "") {
      alert("nom ou mdp manquant");
    }
    else{
      this.deltaruneService.getAccount(this.nom, this.mdp).subscribe(
        data => {
          localStorage.setItem('token', data.token);
          this.router.navigateByUrl('/home');
        }
      )
    }
  }
}
