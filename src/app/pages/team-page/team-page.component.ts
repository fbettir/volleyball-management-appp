import { Component } from '@angular/core';
import { Gender } from 'src/app/models/gender';
import { Post } from 'src/app/models/post';
import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';

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

  displayedColumns: string[] = ['position', 'name', 'post'];

  description: String =
    'This team was created in 2016, they were champions in ....';
}
