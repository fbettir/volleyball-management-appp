import { Gender } from "./gender";
import { Post } from "./post";
import { TicketPass } from "./ticket-pass";

export interface PlayerDetailsWithName {
    id: string;
    name: string;
    birthday: Date;
    phone: string;
    playerNumber: number;
    ticketPass?: TicketPass;
    gender: Gender;
    posts: Post[]; 
}