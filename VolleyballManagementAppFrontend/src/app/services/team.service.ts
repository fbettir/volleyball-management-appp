import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { Training } from '../models/training';
import { Gender } from '../models/gender';
import { Post } from '../models/post';
import { Role } from '../models/role';
import { User } from '../models/user';
import { TicketPass } from '../models/ticket-pass';
import { Tournament } from '../models/tournament';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  getTeamById(teamId: number): Team {
    return this.teams.find(team => team.id === teamId)!;
  }
  getTournamentById(tournamentId: number): Tournament {
    return this.tournaments.find(tournament => tournament.id === tournamentId)!;
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
      number: 14,
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
      number: 12,
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
      ticket: TicketPass.StudentPass,
      number: 8,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '6',
      name: 'Player6',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      number: 7,
      ticket: TicketPass.Pass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '7',
      name: 'Player7',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      number: 6,
      ticket: TicketPass.StudentTicket,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Hitter,
      number: 2,
      ticket: TicketPass.StudentPass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Receiver,
      number: 8,
      ticket: TicketPass.Pass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Receiver,
      number: 9,
      ticket: TicketPass.Pass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Setter,
      number: 1,
      ticket: TicketPass.StudentPass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      number: 7,
      ticket: TicketPass.Ticket,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    },
    {
      id: '1',
      name: 'Player1',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Setter,
      number: 2,
      ticket: TicketPass.Pass,
      phone: 12345678,
      birthday: new Date(),
      gender: Gender.Man,
    }
  ];
  players2: User[] = [ 
    {
      id: '1',
      name: 'player2',
      role: Role.User,
      email: 'tom@mail.com',
      post: Post.Libero,
      number: 12,
      ticket: TicketPass.Ticket,
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
      ticket: TicketPass.StudentPass,
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
      ticket: TicketPass.Ticket,
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
    id: '1', 
    participants: this.players1,
    location: "Somewhere",
    date: new Date(),
    description: "Team 1 training1"
    },  
    {
      id: '2', 
      participants: this.players1,
      location: "Somewhere2",
      date: new Date(),
      description: "Team 1 training2"
    }  
  ]
  trainings2: Training[] = [
    {
    id: '1', 
    participants: this.players2,
    location: "Somewhere",
    date: new Date(),
    description: "Team 2 training1"
    },  
    {
      id: '2', 
      participants: this.players2,
      location: "Somewhere2",
      date: new Date(),
      description: "Team 2 training2"
    }  
  ]
  trainings3: Training[] = [{
    id: '1', 
    participants: this.players3,
    location: "Somewhere",
    date: new Date(),
    description: "Team 3 trainings"
  }]

  team1: Team = {
    id: 1,
    coach: this.coach1,
    name: "Team A",
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit.  Nulla id odio id erat ornare vestibulum.",
    members: this.players1,
    picture : "./../assets/kep.jpg",
    trainings: this.trainings1
  }
  team2: Team = {
    id: 2,
    coach: this.coach2,
    name: "Team B",
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla id odio id erat ornare vestibulum. ",
    members: this.players2,
    picture : "./../assets/okt.jpg",
    trainings: this.trainings2
  }
  team3: Team = {
    id: 3,
    coach: this.coach3,
    name: "Team C",
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla id odio id erat ornare vestibulum. ",
    members: this.players3,
    picture : "./../assets/kepp.jpg",
    trainings: this.trainings3
  }

  tournaments: Tournament[] = [
    {
      id : 1,
      name: "Tournament September",
      teams: [this.team1, this.team2],
      date: new Date(),
      location: "Road1",
      description: "",
      picture: "./../assets/kepp.jpg",
    },
    {
      id : 2,
      name: "Tournament October",
      teams: [this.team1, this.team3],
      date: new Date(),
      location: "Road2",
      description: "",
      picture: "./../assets/kepp.jpg",
    },
    {
      id : 3,
      name: "Tournament November",
      teams: [this.team1, this.team2, this.team3],
      date: new Date(),
      location: "Road3",
      description: "",
      picture: "./../assets/kepp.jpg",
    },
    {
      id : 4,
      name: "Tournament December",
      teams: [this.team3],
      date: new Date(),
      location: "Road4",
      description: "",
      picture: "./../assets/kepp.jpg",
    },
  ]

  teams: Team[] = [this.team1, this.team2, this.team3];
  
  
}
