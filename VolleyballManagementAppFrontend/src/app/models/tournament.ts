import { Team } from './team';

export interface Tournament {
  id: number;
  name: string;
  teams: Team[];
  date: Date;
  location: string;
  description: string;
  picture?: string;
}
 