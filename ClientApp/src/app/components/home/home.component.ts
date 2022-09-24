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

	async set(): Promise<void> {
		const chapitre = parseInt((<HTMLInputElement>document.getElementById('chapitre')).value);
		switch (this.router.url) {
			case "/home":
			 await this.deltaruneService.setStaff(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
				.then(
					() => {
						this.getAll()
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
			case "/beta":
			 await this.deltaruneService.setBeta(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
				.then(
					() => {
						this.getAll()
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
			case "/voix":
			 await this.deltaruneService.setVoix(this.nom, this.photo, this.description, this.lien, this.nomLien, chapitre)
				.then(
					() => {
						this.getAll()
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
			case "/staff":
			 await this.deltaruneService.setStaffDR(this.nom, this.photo, this.description, this.card, this.lien, this.nomLien, chapitre)
				.then(
					() => {
						this.getAll()
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
		}
	}

	async getChapitres(): Promise<void> {
		await this.deltaruneService.getChapitres()
		.then(
			data => {
				for (let i = 1; i <= data[0].chapitre; i++) {
					this.listChapter.push(i)
				}
			}
		)
		.then(
			err => {
				console.error(err);
			}
		)
	}

	async getAll(): Promise<void> {
		switch (this.router.url) {
			case "/home":
				await this.deltaruneService.getAllStaff()
				.then(
					data => {
						this.staffs = data;
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
			case "/beta":
				await this.deltaruneService.getAllBeta()
				.then(
					data => {
						this.staffs = data;
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
			case "/voix":
			 await this.deltaruneService.GetAllVoix()
				.then(
					data => {
						this.staffs = data;
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
				break;
			case "/staff":
			 await this.deltaruneService.GetAllStaffDR()
				.then(
					data => {
						this.staffs = data;
					}
				)
				.catch(
					err => {
						console.error(err);
					}
				)
		}

	}

	async delete(id: number): Promise<void> {
		switch (this.router.url) {
			case "/home":
				await this.deltaruneService.deleteStaff(id)
					.then(
						() => {
							this.getAll();
						}
					)
					.catch(
						err => {
							console.error(err);
						}
					)
				break;
			case "/beta":
			 await this.deltaruneService.deleteBeta(id)
					.then(
						() => {
							this.getAll();
						}
					)
					.catch(
						err => {
							console.error(err);
						}
					)
				break;
			case "/voix":
			 await this.deltaruneService.deleteVoix(id)
					.then(
						() => {
							this.getAll();
						}
					)
					.catch(
						err => {
							console.error(err);
						}
					)
				break;
			case "/staff":
			 await this.deltaruneService.deleteStaffDR(id)
					.then(
						() => {
							this.getAll();
						}
					)
					.catch(
						err => {
							console.error(err);
						}
					)
		}
	}
}
