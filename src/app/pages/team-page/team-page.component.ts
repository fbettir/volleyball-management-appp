import { Component, Input, OnInit } from '@angular/core';
import { Gender } from 'src/app/models/gender';
import { Post } from 'src/app/models/post';
import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';
import { FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Team } from 'src/app/models/team';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from 'src/app/services/team.service';


@Component({
  selector: 'app-team-page',
  templateUrl: './team-page.component.html',
  styleUrls: ['./team-page.component.scss'],
})
export class TeamPageComponent implements OnInit{

  team?: Team = undefined;
  teamId = 1;
  dataSource = new MatTableDataSource<User>([]);

  displayedColumns: string[] = ['position', 'name', 'post'];

  constructor(
    private formBuilder: FormBuilder,
    private route : ActivatedRoute,
    private teamService: TeamService
  ) {  }

  ngOnInit() {
    this.teamId = parseInt(this.route.snapshot.params["teamId"], 10);
    this.team = this.teamService.getTeamById(this.teamId);
    this.dataSource.data = this.team?.members || [];

}

  addPlayerForm = this.formBuilder.group({
    name: 'someone',
    role: Role.User,
    email: 'example@email.com',
    post: Post.Receiver,
    phone: 0,
    birthday: new Date(),
    gender: "",
  });

  onSubmit(): void { 
    const {name, role, email, post, phone, birthday, gender} = this.addPlayerForm.value;
    const user: User = { 
    id : Math.random().toString(36).substr(2),
    name: name!,
    role: role! as Role,
    email: email!,
    post: post!,
    phone: phone!,
    birthday: birthday!,
    gender: gender! as Gender
    };

    this.dataSource.data = [...this.dataSource.data, user];
  }
}
