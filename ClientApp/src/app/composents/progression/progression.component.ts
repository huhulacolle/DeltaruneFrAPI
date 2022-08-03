import { Component, OnInit } from '@angular/core';
import { Progression } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';
import { VerifaccountService } from 'src/app/services/verifaccount.service';

@Component({
  selector: 'app-progression',
  templateUrl: './progression.component.html',
  styleUrls: ['./progression.component.css']
})
export class ProgressionComponent implements OnInit {

  progress!: Progression;
  error: string = "";
  loadingEdit: boolean = false;
  checkEdit: boolean = false;
  listChapter: number[] = [];

  constructor(
    private deltaruneService: DeltaruneService,
  ) { }

  ngOnInit(): void {
    this.getProgression();
    this.getChapitres();
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

  getProgression(): void {
    this.deltaruneService.getProgression()
    .subscribe({
      next: (data) => {
        this.progress = data[0];
      },
      error: (error) => console.error(error)
    })
  }

  editProgression(): void {
    this.progress.chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
    this.progress.fini = (<HTMLInputElement>document.getElementById('fini')).checked;
    this.checkEdit = false;
    this.loadingEdit = true;
    const editProgression = this.deltaruneService.editProgression(this.progress)
    .subscribe({
      next: () => {
        this.getChapitres();
        editProgression.unsubscribe();
      },
      error : (error) => this.error = error
    })
    this.getProgressionJson();
  }

  getProgressionJson(): void {
    this.deltaruneService.getProgressionJson()
    .subscribe({
      next: () => {
        this.loadingEdit = false;
        this.checkEdit = true;
      },
      error : (error) => this.error = error
    })

  }


}
