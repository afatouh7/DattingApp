
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Member } from '../_model/member';

const httpOptions={
  headers:new HttpHeaders({
 Authorization:'Bearer' + JSON.parse(localStorage.getItem('user'))?.token
  })
}
@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl=environment.apiUrl;

  constructor(private http:HttpClient) { }
  getMembers(){
    return this.http.get<Member[]>(this.baseUrl+'USers');
  }
  getMmber(username:string){
    return this.http.get<Member>(this.baseUrl+ 'USers/'+username);
  }
}
