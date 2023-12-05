import { Team } from './team';

export interface Tournament {
  id: string;
  name: string;
  date: Date;
  location: string;
  description: string;
  picture?: string;
}
 