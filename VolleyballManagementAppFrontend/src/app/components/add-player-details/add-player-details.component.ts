import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Gender } from 'src/app/models/gender';
import { PlayerDetails } from 'src/app/models/player-details';
import { Post } from 'src/app/models/post';
import { Role } from 'src/app/models/role';
import { TicketPass } from 'src/app/models/ticket-pass';
import { User } from 'src/app/models/user';
import { PlayerDetailService } from 'src/app/services/player-detail.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-player-details',
  templateUrl: './add-player-details.component.html',
  styleUrls: ['./add-player-details.component.scss']
})
export class AddPlayerDetailsComponent implements OnInit  {

  users: User[] = [];

  
  constructor(
    private formBuilder: FormBuilder,
    private playerService: PlayerDetailService,
    private userService: UserService
  ){
  }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(users => {
      this.users = users;
      console.log(this.users);
    })
  }
  
  addPlayerForm = this.formBuilder.group({
    user: "",
    birthday: new Date(),
    phone: "+3610000000",
    number: 0,
    posts: [],
    ticket: TicketPass.Ticket,
    gender: Gender.Other,
  });

  onSubmit(): void { 
    const { user, posts, phone, ticket, number, birthday, gender} = this.addPlayerForm.value;
    const playerDetails: Partial<PlayerDetails> = { 
    userId: user!,
    birthday: birthday!,
    phone: phone!,
    playerNumber: number!,
    posts: (posts! as string[]).map(p => parseInt(p, 10)) as any,
    ticketPass: parseInt(ticket!, 10) as any,
    gender: parseInt(gender!, 10) as any,
    };
    this.playerService.insertPlayer(playerDetails as PlayerDetails);
  }
}
