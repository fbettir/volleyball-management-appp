import { Location } from "./location";
import { MatchState } from "./matchState";
import { Team } from "./team";
import { Tournament } from "./tournament";
import { User } from "./user";

export interface Match {
    id: string;
    date: Date;
    startTime: Date;
    location: Location;
    referee: User;
    tournament: Tournament;
    teams: Team[];
    points: number[];
    matchState: MatchState;
}