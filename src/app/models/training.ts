import { User } from "./user";

export interface Training {
    id: number;
    participants: User[];
    location: string;
    date: Date;
    description: string;
}
