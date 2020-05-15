import { Component, OnInit } from '@angular/core';
import { HttpClient , HttpHeaders, HttpClientModule } from '@angular/common/http';
import { AppModule } from '../app.module';
import { AuthService } from "angularx-social-login";
import { SocialUser } from "angularx-social-login";

@Component({
  selector: 'app-waarnemingen',
  templateUrl: './waarnemingen.component.html',
  styleUrls: ['./waarnemingen.component.css']
})
export class WaarnemingenComponent implements OnInit {

  waarnemingen: Array<IWaarneming>;
  voornaam: String = "";
  achternaam: String = "";
  vogel: String = "";
  page: number = 0;
  //sort: Array<String> = ["", "VogelNaam", "SpotterAchternaam", "SpotterVoornaam", "DatumTijd"];
  sort: String = "";

  user: SocialUser;
  loggedIn: boolean;

  URL: String = "https://birdwatchertest-277214.ew.r.appspot.com/api"

  constructor(private http: HttpClient, private authService: AuthService) {
  }

  previousPage() {
    this.page -= 1;
    this.page = Math.max(this.page, 0);
    this.get();
  }

  nextPage() {
    this.page += 1;
    this.get();
  }

  dataChange(getValue) {
    this.get();
  }

  get() {
    var header = new HttpHeaders({"Authorization":"Bearer " +this.user.idToken});
    var options= {headers: header};

    this.http.get(this.URL+"/waarnemingen?VogelNaam="+this.vogel
        +"&SpotterVoornaam="+this.voornaam
        +"&SpotterAchternaam="+this.achternaam
        +"&page="+this.page
        +"&sort="+this.sort, options)
      .subscribe((data: Array<IWaarneming>) => {
        this.waarnemingen = data;
        console.log(data);
        console.log("GET");
      }, error => {
        console.log("ERROR");
      });
  }

  ngOnInit() {
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
    });

    this.get();
  }

  

}

export interface IFamilie {
  id: number;
  naam: string;
}

export interface IVogel {
  id: number;
  naam: string;
  latijns: string;
  frans: string;
  engels: string;
  duits: string;
  familieID: number;
  familie: IFamilie;
}

export interface ISpotter {
  id: number;
  voornaam: string;
  achternaam: string;
  straat: string;
  nummer: number;
  postcode: number;
  gemeente: string;
  email: string;
}

export interface IWaarneming {
  id: number;
  datumTijd: Date;
  geslacht: number;
  geoBreedte: number;
  geoLengte: number;
  vogelID: number;
  vogel: IVogel;
  spotterID: number;
  spotter: ISpotter;
}

