import { Team } from "./team";

export interface Tournament {
    id: number;
    teams: Team[],
    date: Date;
    location: string;
    description: string;
}
