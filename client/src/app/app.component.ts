import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Datting App';
  users:any;
  constructor(private http:HttpClient){}

  ngOnInit() {
   this.getUsers();
  }
  getUsers(){
    this.http.get('https://localhost:7123/api/USers').subscribe(res=>{
      this.users=res;
    },error=>{
      console.log(error);
    });
  }

}
