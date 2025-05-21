import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDialog } from '@angular/material/dialog';

import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { UserFormComponent } from 'src/app/components/forms/user-form/user-form.component';
import { ConfirmDialogComponent } from 'src/app/components/forms/confirm-dialog/confirm-dialog.component';
import { UserSearchBarComponent } from 'src/app/components/search/user-search-bar/user-search-bar.component';

@Component({
  selector: 'app-users-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    MatExpansionModule,
    UserSearchBarComponent,
  ],
  templateUrl: './users-management.component.html',
  styleUrls: ['./users-management.component.scss'],
})
export class UsersManagementComponent implements OnInit {
  users: User[] = [];
  filteredUsers: User[] = [];
  userSearchText = '';
  userFilter = 'name';

  constructor(private userService: UserService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe((users) => {
      this.users = users;
      this.filteredUsers = users;
    });
  }

  loadUserDetails(user: User): void {
    this.userService.getUserById(user.id).subscribe((loaded) => {
      Object.assign(user, loaded);
    });
  }

  onUserSearchChanged(event: { text: string; filter: string }): void {
    this.userSearchText = event.text.toLowerCase();
    this.userFilter = event.filter;
    this.filterUsers();
  }

  filterUsers(): void {
    this.filteredUsers = this.users.filter((user) => {
      if (this.userFilter === 'name') {
        return user.name.toLowerCase().includes(this.userSearchText);
      } else if (this.userFilter === 'email') {
        return user.email.toLowerCase().includes(this.userSearchText);
      }
      return true;
    });
  }

  onCreateUser(): void {
    const dialogRef = this.dialog.open(UserFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'user-dialog',
    });

    dialogRef.afterClosed().subscribe(() => this.loadUsers());
  }

  editUser(user: User): void {
    const dialogRef = this.dialog.open(UserFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'user-dialog',
      data: user,
    });

    dialogRef.afterClosed().subscribe(() => this.loadUsers());
  }

  onDeleteUser(user: User): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'user-dialog',
      data: {
        title: 'Delete User',
        message: `Are you sure you want to delete "${user.name}"? This action cannot be undone.`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.userService.deleteUserById(user.id).subscribe({
          next: () => this.loadUsers(),
          error: (err) => console.error('Error deleting user', err),
        });
      }
    });
  }
}
