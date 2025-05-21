import { Match } from "./match";
import { Tournament } from "./tournament";
import { Training } from "./training";
import { User } from "./user";
import { Location } from './location';

export interface Team {
  id: string;
  name: string;
  pictureLink: string;
  description: string;
  owner: User;
  location: Location;
  players: User[];
  coaches: User[];
  matches: Match[];
  trainings: Training[];
  tournaments: Tournament[];
  userHasAsFavourite: User[];
}