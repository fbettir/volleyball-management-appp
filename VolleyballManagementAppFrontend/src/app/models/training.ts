import { PriceType } from './priceType';
import { Team } from './team';
import { User } from './user';
import { Location } from './location';

export interface Training {
  id: string;
  players: User[];
  userHasAsFavourite: User[];
  location: Location;
  date: Date;
  description: string;
  team: Team;
  priceType: PriceType;
  pictureLink: string;
  acceptableTickets: PriceType[];
}