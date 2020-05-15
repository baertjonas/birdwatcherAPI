import { Component, OnInit } from '@angular/core';
import { HttpClient , HttpHeaders, HttpClientModule } from '@angular/common/http';
import { AppModule } from '../app.module';

@Component({
  selector: 'app-vogels',
  templateUrl: './vogels.component.html',
  styleUrls: ['./vogels.component.css']
})
export class VogelsComponent implements OnInit {

  vogel: IVogel;
  id: number;
  //naam: String;
  jsonVogel: String;
  imgURL: String;
  errorResponse: IErrorResponse;

  URL: String = "https://birdwatchertest-277214.ew.r.appspot.com/api"

  constructor(private http: HttpClient) {
    this.vogel = { id: 0, naam: "", latijns: "", frans: "", engels: "", duits: "", familieID: 0};
  }

  ngOnInit() {
  }

  post() {
    delete this.vogel.id; //er moet een nieuwe ID worden aangemaakt
    this.jsonVogel = JSON.stringify(this.vogel);
    //moet object zonder ID zijn
    //this.jsonVogel = "{\"naam\":\""+this.vogel.naam+"\",\"latijns\":\""+this.vogel.latijns+"\",\"frans\":\""+this.vogel.frans+"\",\"engels\":\""+this.vogel.engels+"\",\"duits\":\""+this.vogel.duits+"\"}";
    console.log(this.jsonVogel);

    var header = new HttpHeaders({"Content-Type":"application/json"});
    var options= {headers: header};
    this.http.post(this.URL+"/vogels", this.jsonVogel, options)
      .subscribe((data: IVogel) => {
        this.vogel = data;
        this.getPictureFromApi(this.vogel.latijns);
        console.log("POST");
      }, error => {
        console.log("ERROR");
        if (error.status == 400) {
          this.errorResponse = error.error;
          alert(this.errorResponse.Naam[0]);
        }
      });
  }

  getById() {
    this.http.get(this.URL+"/vogels/"+this.vogel.id)
      .subscribe((data: IVogel) => {
        this.vogel = data;
        this.getPictureFromApi(this.vogel.latijns);
        console.log(data);
        console.log("GET");
      }, error => {
        console.log("ERROR");
      });
  }

  put() {
    this.jsonVogel = JSON.stringify(this.vogel);
    var header = new HttpHeaders({"Content-Type":"application/json"});
    var options= {headers: header};
    this.http.put(this.URL+"/vogels", this.jsonVogel, options)
      .subscribe((data: IVogel) => {
        this.vogel = data;
        this.getPictureFromApi(this.vogel.latijns);
        console.log(data);
        console.log("PUT");
      }, error => {
        console.log("ERROR");
        if (error.status == 400) {
          this.errorResponse = error.error;
          alert(this.errorResponse.Naam[0]);
        }
      });
  }

  delete() {
    this.http.delete(this.URL+"/vogels/"+this.vogel.id)
      .subscribe((data: IVogel) => {
        this.reset();
        console.log("DELETE");
      }, error => {
        console.log("ERROR");
      });
  }

  reset() {
    delete this.vogel.id;
    delete this.vogel.naam;
    delete this.vogel.latijns;
    delete this.vogel.frans;
    delete this.vogel.engels;
    delete this.vogel.duits;
    delete this.vogel.familieID;
  }

  getPictureFromApi(query: String) {
    this.http.get("https://pixabay.com/api?key=16476956-43b3b977cd0b754554994b778&q="+query)
    .subscribe((data: IAPIResult) => {
      if (data.total > 0) {
        this.imgURL = data.hits[0].webformatURL;
      } else {
        this.imgURL = "";
      };  
      console.log(data);
      console.log("GET");
    }, error => {
      console.log("ERROR");
    });
  }

}
export interface IVogel {
  id: number;
  naam: String;
  latijns: String;
  frans: String;
  engels: String;
  duits: String;
  familieID: number;
}

export interface IFamilie {
  id: number;
  naam: string;
}

export interface Hit {
  id: number;
  pageURL: string;
  type: string;
  tags: string;
  previewURL: string;
  previewWidth: number;
  previewHeight: number;
  webformatURL: string;
  webformatWidth: number;
  webformatHeight: number;
  largeImageURL: string;
  imageWidth: number;
  imageHeight: number;
  imageSize: number;
  views: number;
  downloads: number;
  favorites: number;
  likes: number;
  comments: number;
  user_id: number;
  user: string;
  userImageURL: string;
}

export interface IAPIResult {
  total: number;
  totalHits: number;
  hits: Hit[];
}

export interface IErrorResponse {
  Naam: string[];
}
