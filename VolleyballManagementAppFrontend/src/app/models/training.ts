import { PlayerDetailsWithName } from './player-details-with-name';
import { PriceType } from './priceType';
import { Team } from './team';
import { User } from './user';

export interface Training {
  id: string;
  players: User[];
  userHasAsFavourite: User[];
  location: Location;
  date: Date;
  description: string;
  Team: Team;
  priceType: PriceType;
}
