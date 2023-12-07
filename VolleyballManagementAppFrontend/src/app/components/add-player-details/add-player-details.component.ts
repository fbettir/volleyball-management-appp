import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Gender } from 'src/app/models/gender';
import { PlayerDetails } from 'src/app/models/player-details';
import { Post } from 'src/app/models/post';
import { Role } from 'src/app/models/role';
import { TicketPass } from 'src/app/models/ticket-pass';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-add-player-details',
  templateUrl: './add-player-details.component.html',
  styleUrls: ['./add-player-details.component.scss']
})
export class AddPlayerDetailsComponent {

  users: User[] = [];
  
  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ){
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
    posts: posts!,
    ticketPass: ticket!,
    gender: gender! as Gender
    };
    console.log(playerDetails);
  }
}
