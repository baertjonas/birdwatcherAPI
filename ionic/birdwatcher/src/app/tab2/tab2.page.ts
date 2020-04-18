import { Component, OnInit } from '@angular/core';
import { HttpClient , HttpHeaders, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  vogel: IVogel;
  jsonVogel: String;

  constructor(private http: HttpClient) {
    
  }
  
  ngOnInit() {
  }

  submit() {
    var vogel = { naam: "", latijns: "", frans: "", engels: "", duits: ""};
    vogel.naam = "Middelste bonte specht";
    vogel.latijns = "Dendrocopus medius";
    vogel.frans = "Pic mar";
    vogel.engels = "Middle Spotted Woodpecker";
    vogel.duits = "Mittelspecht";
    this.jsonVogel = JSON.stringify(vogel);  

    console.log(this.jsonVogel);

    var header = new HttpHeaders({"Content-Type":"application/json"});
    var options= {headers: header};
    this.http.post("https://localhost:5001/api/vogels", this.jsonVogel, options)
        .subscribe(data => {
            console.log("POST");
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
}