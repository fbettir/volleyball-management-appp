
import { PriceType } from '../enums/priceType';
import { Location } from '../entities/location';
import { Team } from './team';
import { User } from './user';

export interface Training {
  id: string;
  players: User[];
  userHasAsFavourite: User[];
  location: Location;
  date: Date;
  description: string;
  team: Team;
  coach: User;
  pictureLink: string;
  priceType: PriceType[];
}