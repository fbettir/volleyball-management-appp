import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent {

  
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
  ){
  }

  addUserForm = this.formBuilder.group({
    name: "",
    email: "",
    password: "",
    roles: [],
  });

  onSubmit(): void { 
    const { name, email, password, roles } = this.addUserForm.value;
    const team: Partial<User> = { 
      name: name!,
      email: email!,
      password: password!,
      roles: (roles! as string[]).map(p => parseInt(p, 10)) as any,
    };
    this.userService.insertUser(team as User);
  }
}
