import { Component } from '@angular/core';
import { Gender } from 'src/app/models/gender';
import { Post } from 'src/app/models/post';
import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';
import { FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-team-page',
  templateUrl: './team-page.component.html',
  styleUrls: ['./team-page.component.scss'],
})
export class TeamPageComponent {
  players: User[] = [
    {
      id: '1',
      name: 'Tom',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '2',
      name: 'Ana',
      role: Role.User,
      email: 'anaa@mail.com',
      post: Post.Hitter,
      phone: 12345678,
      birthday: new Date(2000, 5, 22),
      gender: Gender.Woman,
    },
    {
      id: '3',
      name: 'Charles',
      role: Role.User,
      email: 'charles123@mail.com',
      post: Post.Receiver,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '4',
      name: 'Kate',
      role: Role.User,
      email: 'Kate@mail.com',
      post: Post.Libero,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Woman,
    },
    {
      id: '5',
      name: 'John',
      role: Role.User,
      email: 'John@mail.com',
      post: Post.Receiver,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
  ];
  dataSource = new MatTableDataSource<User>([]);

  displayedColumns: string[] = ['position', 'name', 'post'];
  teamname: string = 'Team A';
  description: String =
    'This team was created in 2016, they were champions in ....';

  constructor(
    private formBuilder: FormBuilder
  ) {
    this.dataSource.data = this.players;
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
