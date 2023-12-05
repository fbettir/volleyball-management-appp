import { Gender } from "./gender";
import { Post } from "./post";
import { TicketPass } from "./ticket-pass";

export interface User {
    id: string;
    userId: string;
    birthday: Date;
    phone: number;
    playerNumber: number;
    ticketPass?: TicketPass;
    gender: Gender;
    posts: Post[];
}