import { PlayerDetailsWithName } from './player-details-with-name';

export interface Training {
  id: string;
  participants: PlayerDetailsWithName[];
  location: string;
  date: Date;
  description: string;
}
