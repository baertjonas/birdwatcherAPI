import { Component, OnInit } from '@angular/core';
import { HttpClient , HttpHeaders, HttpClientModule } from '@angular/common/http';
import { AppModule } from '../app.module';

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

  constructor(private http: HttpClient) {
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
    this.http.get("https://localhost:5001/api/waarnemingen?VogelNaam="+this.vogel
        +"&SpotterVoornaam="+this.voornaam
        +"&SpotterAchternaam="+this.achternaam
        +"&page="+this.page)
      .subscribe((data: Array<IWaarneming>) => {
        this.waarnemingen = data;
        console.log(data);
        console.log("GET");
      }, error => {
        console.log("ERROR");
      });
  }

  ngOnInit() {
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

