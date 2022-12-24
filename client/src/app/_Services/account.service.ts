import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_model/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl = 'https://localhost:7123/api/';
private currentUserSorce= new ReplaySubject<User>(1);

currentUser$ =this.currentUserSorce.asObservable();

  constructor(private http : HttpClient) { }
  login(model: any){
    return this.http.post(this.baseUrl+ 'Acount/login',model).pipe(
      map((response:User)=>{
        const user=response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSorce.next(user);
        }

      })
    )
  }
  register(model:any){
    return this.http.post(this.baseUrl+'Acount/register',model).pipe(
      map((user: User)=>{
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSorce.next(user);
        }

      })
    )
  }
  setCurrentUser(user:User){
    this.currentUserSorce.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSorce.next(null);
  }
}
