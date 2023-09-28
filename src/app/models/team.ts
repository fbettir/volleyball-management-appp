import { Training } from './training';
import { User } from './user';

export interface Team {
    id: number;
    coach: User;
    name: string;
    description: string;
    members: User[];
    trainings: Training[];
}
