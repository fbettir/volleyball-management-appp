import { Gender } from './gender';
import { Post } from './post';
import { Role } from './role';
import { TicketPass } from './ticket-pass';

export interface User {
  id: string;
  name: string;
  role: Role;
  email: string;
  post: Post;
  ticket?: TicketPass;
  number?: number;
  phone: number;
  birthday: Date;
  gender: Gender;
}
