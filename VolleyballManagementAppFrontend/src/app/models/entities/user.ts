import { Gender } from '../enums/gender';
import { Post } from '../enums/post';
import { PriceType } from '../enums/priceType';
import { Role } from '../enums/role';
import { Team } from './team';
import { Tournament } from './tournament';
import { Training } from './training';

export interface User {
  id: string;
  auth0Id: string;
  name: string;
  email: string;
  pictureLink: string;
  birthday: Date;
  phone: string;
  playerNumber: number;
  roles: Role[];
  priceType: PriceType;
  gender: Gender;
  posts: Post;
  ownedTeams: Team[];
  joinedTeams: Team[];
  coachedTeams: Team[];
  favouriteTeams: Team[];
  trainings: Training[];
  favouriteTrainings: Training[];
  favouriteTournaments: Tournament[];
}
