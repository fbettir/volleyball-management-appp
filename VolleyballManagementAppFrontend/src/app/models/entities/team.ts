import { Match } from "./match";
import { Tournament } from "./tournament";
import { User } from "./user";
import { Location } from './location';
import { Training } from "./training";

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