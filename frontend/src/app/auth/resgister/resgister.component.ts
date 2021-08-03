import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { signup } from 'src/app/_model/auth';
import { City, Country } from 'src/app/_model/location/loction';
import { AuthService } from 'src/app/_service/auth/auth.service';
import { LocationService } from 'src/app/_service/location/loction.service';

@Component({
  selector: 'app-resgister',
  templateUrl: './resgister.component.html',
  styleUrls: ['./resgister.component.css'],
})
export class ResgisterComponent implements OnInit {
  countrylist: Country[] = [];
  SelectedCountry: Country = new Country();
  citylist: City[] = [];
  Data: signup = new signup();
  invalidregister: boolean = false;
  mobNumberPattern = '^((\\+91-?)|0)?[0-9]{11}$';
  returnUrl!: string;
  url: any;

  constructor(
    private loginser: AuthService,
    private locationser: LocationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.locationser.getAllCountries().subscribe((a) => {
      this.countrylist = a;
    });
    this.Data.countryid = 0;
    this.Data.cityid = 0;
  }

  selectChangeHandler(value: any) {
    // console.log(value);
    if (value == 0) this.citylist = [];
    else
      this.locationser.getCitiesBYCountry(value).subscribe((data) => {
        this.citylist = data;
      });
    //console.log(this.citylist);
  }

  BackToLogIn() {
    this.router.navigateByUrl('/login');
  }

  SignUp() {
    this.url = window.location.href;
     //console.log(this.Data);
    if (this.url == 'http://localhost:4200/signup') {
      this.loginser.Registor(this.Data).subscribe(
        (response) => {
          console.log("succ rgist");
          const user = this.Data.userName;

          sessionStorage.setItem('user', user);

          this.invalidregister = false;
          this.loginser.navShow();
          this.router.navigateByUrl('/home');
        },
        (err) => {
          this.invalidregister = true;
          console.log("error rgist");
          
        }
      );
    } 
  }
}
