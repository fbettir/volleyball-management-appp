import { Level } from '../enums/level';
import { Location } from './location';
import { Match } from './match';
import { PriceType } from '../enums/priceType';
import { Team } from './team';
import { TournamentType } from '../enums/tournamentType';
import { User } from './user';

export interface Tournament {
  id: string;
  name: string;
  date: Date;
  entryDeadline: Date;
  description: string;
  organizer: string;
  registrationPolicy: string;
  teamPolicy: string;
  pictureLink: string;
  categories: Level[];
  priceType: PriceType;
  teams: Team[];
  matches: Match[];
  userHasAsFavourite: User[];
  location: Location;
  courts: number;
  maxTeamsPerLevel: number[];
  tournamentType: TournamentType;
}
 