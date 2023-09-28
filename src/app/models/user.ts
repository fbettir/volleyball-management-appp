import { Gender } from "./gender";
import { Post } from "./post";
import { Role } from "./role";

export interface User {
    id: string;
    name: string;
    role: Role;
    email: string;
    post: Post;
    phone: number;
    age: number;
    gender: Gender; 
}
