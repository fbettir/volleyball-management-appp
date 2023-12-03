import { Training } from './training';
import { User } from './user';

export interface Team {
  id: string;
  coach: User;
  name: string;
  picture?: string;
  description: string;
  members: User[];
  trainings: Training[];
}
