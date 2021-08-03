import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { headerCustomer } from '../_model/Product/product';
import { AuthService } from '../_service/auth/auth.service';
import { ProductService } from '../_service/product/product.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public loginser:AuthService,private router:Router,private productser:ProductService) { }
  isLoggedIn:any;
  noCart:any;
  noInvoice:any;
  Invoice: headerCustomer[] = []
  ngOnInit(): void {
    this.loginser.navShow()
    this.isLoggedIn = this.loginser.navcheck();
    //console.log(this.isLoggedIn);
    let v = JSON.parse(localStorage.getItem("cart"));
    if(v==null){
      this.noCart = 0;
    }
    else{
      this.noCart = v.length;
    }
    
    let user = sessionStorage.getItem('user');
    if(user != null){
      this.productser.GetInvoice(user).subscribe(res=>{
        this.noInvoice = res.length;
        this.Invoice = res;      
      });
    }
    
    
  }

  logout(){
    sessionStorage.clear();
    localStorage.clear();
    location.reload();
    this.router.navigateByUrl("/login");
  }

  login(){
    this.router.navigateByUrl("/login");
  }
  signup(){
    this.router.navigateByUrl("/signup");
  }
  

}
