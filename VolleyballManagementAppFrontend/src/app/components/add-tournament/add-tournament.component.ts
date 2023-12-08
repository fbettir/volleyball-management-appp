import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-add-tournament',
  templateUrl: './add-tournament.component.html',
  styleUrls: ['./add-tournament.component.scss']
})
export class AddTournamentComponent {

  tournaments: Tournament[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private tournamentService: TournamentService
  ){
  }

  addTournamentForm = this.formBuilder.group({
    name: "",
    date: new Date(),
    location: "",
    description: "",
    picture: "",
  });

  onSubmit(): void {
    const { name, date, location, description, picture} = this.addTournamentForm.value;
    const tournament: Partial<Tournament> = {
      name: name!,
      date: date!,
      location: location!,
      description: description!,
      picture: picture!,
    };

    this.tournamentService.insertTournament(tournament as Tournament);
  }
}
