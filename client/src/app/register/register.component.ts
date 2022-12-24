import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
model:any={};
users:any;

@Output() cancelRegister=new EventEmitter();

  constructor(private accountService:AccountService,private toaster:ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.model).subscribe(res=>{
      console.log(res);
      this.cancel();
    },error=>{
      console.log(error);
      this.toaster.error(error.error);

    })

  }
  cancel(){
    this.cancelRegister.emit(false);

  }
}
