import { Component, OnInit } from '@angular/core';
import { AuthService } from "angularx-social-login";
import { SocialUser } from "angularx-social-login";

@Component({
  selector: 'app-spotters',
  templateUrl: './spotters.component.html',
  styleUrls: ['./spotters.component.css']
})
export class SpottersComponent implements OnInit {

  user: SocialUser;
  loggedIn: boolean;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.authState.subscribe((user) => {
    this.user = user;
    this.loggedIn = (user != null);
    });
  }

}
