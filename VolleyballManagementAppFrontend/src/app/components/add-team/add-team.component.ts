import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Team } from 'src/app/models/team';
import { User } from 'src/app/models/user';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.scss']
})
export class AddTeamComponent {

  teams: Team[]= [];

  constructor(
    private formBuilder: FormBuilder,
    private teamService: TeamService
  ){
  }

  addUserForm = this.formBuilder.group({
    name: "",
    email: "",
    password: "",
    roles: [],
  });

  onSubmit(): void { 
    const { name, email, password, roles} = this.addUserForm.value;
    const user: Partial<User> = { 
      name: name!,
      email: email!,
      password: password!,
      roles: roles!,
    };
    //this.teamService.insertTeam(team);
  }

}
