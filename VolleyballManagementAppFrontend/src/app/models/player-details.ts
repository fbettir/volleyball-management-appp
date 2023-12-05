import { Gender } from "./gender";
import { Post } from "./post";
import { TicketPass } from "./ticket-pass";
import { User } from "./user";

export interface PlayerDetails {
    id: string;
    userId: User;
    birthday: Date;
    phone: number;
    playerNumber: number;
    ticketPass?: TicketPass;
    gender: Gender;
    posts: Post[];
}