import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Post } from 'src/app/models/post';



@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit{

  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar,
  ) {}

  pageIndex: number = 0;
  size: number = 10;

  posts: Post[] = [ Post.Hitter]
 
  ngOnInit(): void {
  }
  
}
