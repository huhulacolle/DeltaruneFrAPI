import { Component, OnInit } from '@angular/core';
import { Progression } from 'src/app/clientSwagger/deltaruneClient';
import { DeltaruneService } from 'src/app/services/deltarune.service';

@Component({
  selector: 'app-progression',
  templateUrl: './progression.component.html',
  styleUrls: ['./progression.component.css']
})
export class ProgressionComponent implements OnInit {

  progress!: Progression;

  constructor(
    private deltaruneService: DeltaruneService
  ) { }

  ngOnInit(): void {
    this.getProgression();
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

}
