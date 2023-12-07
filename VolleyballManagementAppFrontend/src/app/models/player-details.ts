import { Gender } from "./gender";
import { Post } from "./post";
import { TicketPass } from "./ticket-pass";

export interface PlayerDetails {
    id: string;
    userId: string;
    birthday: Date;
    phone: string;
    playerNumber: number;
    ticketPass?: TicketPass;
    gender: Gender;
    posts: Post[];
}