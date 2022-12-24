import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_model/user';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any={};

currentUser$: Observable<User>;

  constructor(public accountService:AccountService,private router:Router,
    private toaster:ToastrService) { }

  ngOnInit(): void {

  }


login(){
  this.accountService.login(this.model).subscribe(res=>{
    console.log(res);


  },error=>{
    console.log(error);
    this.toaster.error(error.error);

  })
}
logout(){
  this.accountService.logout();
  this.router.navigateByUrl('/');

}

}
