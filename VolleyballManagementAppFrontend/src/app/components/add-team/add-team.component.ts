import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Team } from 'src/app/models/team';
import { User } from 'src/app/models/user';
import { TeamService } from 'src/app/services/team.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.scss']
})
export class AddTeamComponent{

  teams: Team[] = [];
  users: User[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private teamService: TeamService,
    private userService: UserService
  ){
  }



  addTeamForm = this.formBuilder.group({
    name: "",
    description: "",
    picture: "",
  });

  onSubmit(): void { 
    const { name, description, picture} = this.addTeamForm.value;
    const team: Partial<Team> = { 
      name: name!,
      pictureLink: picture!,
      description: description!,
    };
    this.teamService.insertTeam(team as Team);
  }

}
