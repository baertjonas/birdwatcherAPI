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

  constructor(private http: HttpClient) {
    this.vogel = { id: 0, naam: "", latijns: "", frans: "", engels: "", duits: ""};
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
    this.http.post("https://localhost:5001/api/vogels", this.jsonVogel, options)
      .subscribe((data: IVogel) => {
        this.vogel = data;
        console.log("POST");
      }, error => {
        console.log("ERROR");
      });
  }

  getById() {
    this.http.get("https://localhost:5001/api/vogels/"+this.vogel.id)
      .subscribe((data: IVogel) => {
        this.vogel = data;
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
    this.http.put("https://localhost:5001/api/vogels", this.jsonVogel, options)
      .subscribe((data: IVogel) => {
        this.vogel = data;
        console.log(data);
        console.log("GET");
      }, error => {
        console.log("ERROR");
      });
  }

  delete() {
    this.http.delete("https://localhost:5001/api/vogels/"+this.vogel.id)
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
  }

}

export interface IVogel {
  id: number;
  naam: String;
  latijns: String;
  frans: String;
  engels: String;
  duits: String;
}
