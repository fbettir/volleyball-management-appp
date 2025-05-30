import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDialog } from '@angular/material/dialog';

import { TeamService } from 'src/app/services/team.service';
import { UserService } from 'src/app/services/user.service';
import { Team } from 'src/app/models/entities/team';
import { User } from 'src/app/models/entities/user';

import { TeamFormComponent } from 'src/app/components/forms/team-form/team-form.component';
import { ConfirmDialogComponent } from 'src/app/components/forms/confirm-dialog/confirm-dialog.component';
import { EventSearchBarComponent } from 'src/app/components/search/event-search-bar/event-search-bar.component';

@Component({
  selector: 'app-teams-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatIconModule,
    MatExpansionModule,
    EventSearchBarComponent,
  ],
  templateUrl: './teams-management.component.html',
  styleUrls: ['./teams-management.component.scss'],
})
export class TeamsManagementComponent implements OnInit {
  teams: Team[] = [];
  filteredTeams: Team[] = [];
  users: User[] = [];
  teamSearchText = '';
  teamFilter = 'name';
  selectedPlayer: { [teamId: string]: string } = {};
  selectedCoach: { [teamId: string]: string } = {};

  constructor(
    private teamService: TeamService,
    private userService: UserService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadTeams();
    this.loadUsers();
  }

  loadTeams(): void {
    this.teamService.getAllTeams().subscribe((teams) => {
      this.teams = teams;
      this.filterTeams();
    });
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe((users) => {
      this.users = users;
    });
  }

  loadTeamDetails(team: Team): void {
    this.teamService.getTeamById(team.id).subscribe((loaded) => {
      team.players = loaded.players;
      team.coaches = loaded.coaches;
    });
  }

  onTeamSearchChanged(event: { text: string; filter: string }): void {
    this.teamSearchText = event.text.toLowerCase();
    this.teamFilter = event.filter;
    this.filterTeams();
  }

  filterTeams(): void {
    this.filteredTeams = this.teams.filter((team) =>
      team.name.toLowerCase().includes(this.teamSearchText)
    );
  }

  onCreateTeam(): void {
    const dialogRef = this.dialog.open(TeamFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
    });

    dialogRef.afterClosed().subscribe(() => this.loadTeams());
  }

  editTeam(team: Team): void {
    const dialogRef = this.dialog.open(TeamFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
      data: team,
    });

    dialogRef.afterClosed().subscribe(() => this.loadTeams());
  }

  onDeleteTeam(team: Team): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
      data: {
        title: 'Delete Team',
        message: `Are you sure you want to delete "${team.name}"?`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.teamService.deleteTeamById(team.id).subscribe(() => this.loadTeams());
      }
    });
  }

  addPlayerToTeam(teamId: string): void {
    const userId = this.selectedPlayer[teamId];
    if (!userId) return;

    this.teamService.addPlayerToTeam(teamId, userId).subscribe(() => {
      const team = this.filteredTeams.find((t) => t.id === teamId);
      if (team) this.loadTeamDetails(team);
      this.selectedPlayer[teamId] = '';
    });
  }

  removePlayerFromTeam(teamId: string, user: User): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
      data: {
        title: 'Remove Player',
        message: `Are you sure you want to remove "${user.name}" from this team?`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.teamService.removePlayerFromTeam(teamId, user.id).subscribe(() => {
          const team = this.filteredTeams.find((t) => t.id === teamId);
          if (team) this.loadTeamDetails(team);
        });
      }
    });
  }

  addCoachToTeam(teamId: string): void {
    const userId = this.selectedCoach[teamId];
    if (!userId) return;

    this.teamService.addCoachToTeam(teamId, userId).subscribe(() => {
      const team = this.filteredTeams.find((t) => t.id === teamId);
      if (team) this.loadTeamDetails(team);
      this.selectedCoach[teamId] = '';
    });
  }

  removeCoachFromTeam(teamId: string, user: User): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
      data: {
        title: 'Remove Coach',
        message: `Are you sure you want to remove "${user.name}" from this team?`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.teamService.removeCoachFromTeam(teamId, user.id).subscribe(() => {
          const team = this.filteredTeams.find((t) => t.id === teamId);
          if (team) this.loadTeamDetails(team);
        });
      }
    });
  }
}
