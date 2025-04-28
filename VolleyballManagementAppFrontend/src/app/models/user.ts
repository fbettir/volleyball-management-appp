import { Gender } from './gender';
import { Post } from './post';
import { PriceType } from './priceType';
import { Role } from './role';
import { Team } from './team';
import { Tournament } from './tournament';
import { Training } from './training';

export interface User {
  id: string;
  name: string;
  email: string;
  password: string;
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
