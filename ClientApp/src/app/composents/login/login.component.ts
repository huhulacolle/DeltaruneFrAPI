import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User[] = [];

  constructor(
    private deltaruneService: DeltaruneService
  ) { }

  ngOnInit(): void {
  }

  public test(): void {
    this.deltaruneService.test().subscribe(
      data => {
        console.log(data);
      },
      err => {
        console.error("salut");
      }
    )
  }

  public getUser(): void {
    console.log("salut");
  }


}
