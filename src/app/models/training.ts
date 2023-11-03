import { User } from './user';

export interface Training {
  id: string;
  participants: User[];
  location: string;
  date: Date;
  description: string;
}
