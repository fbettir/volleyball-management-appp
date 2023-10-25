import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { Training } from '../models/training';
import { Gender } from '../models/gender';
import { Post } from '../models/post';
import { Role } from '../models/role';
import { User } from '../models/user';
import { TicketPass } from '../models/ticket-pass';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  getTeamById(teamId: number): Team {
    return this.teams.find(team => team.id === teamId)!;
  }

  constructor() { }

  players1: User[] = [ 
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      number: 9,
      ticket: TicketPass.Pass,
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
      number: 16,
      ticket: TicketPass.StudentPass,
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
      number: undefined,
      ticket: TicketPass.Pass,
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
      ticket: TicketPass.Ticket,
      number: 2,
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
      ticket: undefined,
      number: 3,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
  ];
  players2: User[] = [ 
    {
      id: '1',
      name: 'player2',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      number: 12,
      ticket: TicketPass.Pass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '2',
      name: 'Andrea',
      role: Role.User,
      email: 'anaa@mail.com',
      post: Post.Hitter,
      ticket: TicketPass.Pass,
      number: undefined,
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
      ticket: TicketPass.Pass,
      phone: 12345678,
      number: 10,
      birthday: new Date(),
      gender: Gender.Man,
    }
  ];
  players3: User[] = [ 
    {
      id: '1',
      name: 'Player3',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      ticket: TicketPass.Pass,
      number: undefined,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '2',
      name: 'Tom',
      role: Role.User,
      email: 'anaa@mail.com',
      post: Post.Hitter,
      number: 11,
      ticket: TicketPass.Pass,
      phone: 12345678,
      birthday: new Date(2000, 5, 22),
      gender: Gender.Man,
    }
  ];

  coach1: User = {      
    id: '1',
    name: 'Coach1',
    role: Role.User,
    email: 'tom@mail.com',
    post: Post.Libero,
    ticket: TicketPass.Pass,
    number: 18,
    phone: 12345678,
    birthday: new Date(),
    gender: Gender.Man 
  }
  coach2: User = {      
    id: '1',
    name: 'Coach2',
    role: Role.User,
    email: 'tom@mail.com',
    post: Post.Libero,
    number: 4,
    ticket: TicketPass.Pass,
    phone: 12345678,
    birthday: new Date(),
    gender: Gender.Man 
  }
  coach3: User = {      
    id: '1',
    name: 'Coach3',
    role: Role.User,
    email: 'tom@mail.com',
    ticket: TicketPass.Pass,
    post: Post.Hitter,
    number: 6,
    phone: 12345678,
    birthday: new Date(),
    gender: Gender.Man 
  }

  trainings1: Training[] = [
    {
    id: 1, 
    participants: this.players1,
    location: "Somewhere",
    date: new Date(),
    description: "Team 1 training1"
    },  
    {
      id: 2, 
      participants: this.players1,
      location: "Somewhere2",
      date: new Date(),
      description: "Team 1 training2"
    }  
  ]
  trainings2: Training[] = [
    {
    id: 1, 
    participants: this.players2,
    location: "Somewhere",
    date: new Date(),
    description: "Team 2 training1"
    },  
    {
      id: 2, 
      participants: this.players2,
      location: "Somewhere2",
      date: new Date(),
      description: "Team 2 training2"
    }  
  ]
  trainings3: Training[] = [{
    id: 1, 
    participants: this.players3,
    location: "Somewhere",
    date: new Date(),
    description: "Team 3 trainings"
  }]

  team1: Team = {
    id: 1,
    coach: this.coach1,
    name: "Team A",
    description: "This team was created in 2016, they were champions in ....",
    members: this.players1,
    trainings: this.trainings1
  }
  team2: Team = {
    id: 2,
    coach: this.coach2,
    name: "Team B",
    description: "Team B description",
    members: this.players2,
    trainings: this.trainings2
  }
  team3: Team = {
    id: 3,
    coach: this.coach3,
    name: "Team C",
    description: "Team C description",
    members: this.players3,
    trainings: this.trainings3
  }

  teams: Team[] = [this.team1, this.team2, this.team3];
  
  
}
