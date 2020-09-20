import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-values',
  templateUrl: './values.component.html',
  styleUrls: ['./values.component.css']
})
export class ValuesComponent implements OnInit {
values: any;
  constructor(private http: HttpClient ) {
    console.log('Hello From Angular 123');
   }
  ngOnInit(){
    this.getvalues();
  }
  getvalues(){
    debugger;
    this.http.get('https://localhost:44393/api/valuescd..').subscribe(response => {
this.values = response; 
console.log('Hello From Angular');
},
error => { console.log('error in component');
    });
  }

}
