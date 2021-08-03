import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { login } from 'src/app/_model/auth';
import { AuthService } from 'src/app/_service/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginser:AuthService ,private router:Router, ) { }

  Data:login=new login();
  ngOnInit(): void {
  }

  login(){
    this.loginser.logIn(this.Data).subscribe(res=>{
      const user = (<any>res).userName;
      sessionStorage.setItem("user" ,user);
      
      this.loginser.navShow();
      window.location.href="/home";
    })
  }

}
