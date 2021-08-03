import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { login, signup } from 'src/app/_model/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  visible: boolean = false;
  footerVisible: boolean = false;

  constructor(private http: HttpClient) {}

  logIn(lg: login) {
    return this.http.post<login>(
      'https://localhost:44372/api/Authentication/LogIn',
      lg
    );
  }

  Registor(rg: signup) {
    return this.http.post<signup>(
      'https://localhost:44372/api/Authentication/SignUp',
      rg
    );
  }

  navcheck() {
    const username = sessionStorage.getItem('user');

    if (username == null) {
      return (this.visible = false);
    } else return (this.visible = true);
  }
  navShow() {
    this.visible = true;
  }
  navHide() {
    this.visible = false;
  }
  footerHide(){
    this.footerVisible = false;
  }
  footerShow(){
    this.footerVisible = true;
  }
}
