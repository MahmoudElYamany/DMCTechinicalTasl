import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { City, Country } from '../_model/location/loction';
import { Discount, Order } from '../_model/order/order';
import { Product } from '../_model/Product/product';
import { AuthService } from '../_service/auth/auth.service';
import { LocationService } from '../_service/location/loction.service';
import { ProductService } from '../_service/product/product.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ChartComponent implements OnInit {
  products: Product[];
  selectedproduct: Product[] = [];
  selectedquantit: any[] = [];
  
  cols: any[];
  displayModal: boolean = false;

  discount: Discount = new Discount();
  discountFlag: Boolean = false;
  btnflag: Boolean = true;
  oldtotal:number;

  countrylist: Country[] = [];
  SelectedCountry: Country = new Country();
  citylist: City[] = [];
  Data: Order = new Order();

  visibleSidebar5:boolean = false;

  constructor(
    private loginser: AuthService,
    private productser: ProductService,
    private locationser: LocationService,
    private confirmationService: ConfirmationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginser.navShow();
    this.Data.subtotal = 0;
    this.locationser.getAllCountries().subscribe((a) => {
      this.countrylist = a;
    });
    this.Data.countryid = 0;
    this.Data.cityid = 0;

    var cartItem = JSON.parse(localStorage.getItem('cart'));
    this.productser.getProducts().subscribe((res) => {
      this.products = res;
      this.products.forEach((e) => {
        if (cartItem.includes(e.id)) {
          this.selectedproduct.push(e);
          this.selectedquantit.push(1);
        }
      });
      this.Data.quantity = this.selectedquantit;
      this.Data.items = this.selectedproduct;
      this.selectedproduct.forEach((x, i) => {
        this.Data.subtotal += x.price * this.Data.quantity[i];
      });
      this.Data.total = Math.round(
        this.Data.subtotal + this.Data.subtotal * 0.14
      );
    });
  }

  selectChangeHandler(value: any) {
    if (value == 0) this.citylist = [];
    else
      this.locationser.getCitiesBYCountry(value).subscribe((data) => {
        this.citylist = data;
      });
  }

  showModalDialog() {
    this.displayModal = true;
  }

  deleteProduct(event: Event, Ques: Product) {
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to proceed?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.Data.items = this.Data.items.filter((val) => val.id !== Ques.id);
        let x = JSON.parse(localStorage.getItem('cart')) as number[];
        let y = x.indexOf(Ques.id);
        x = x.filter((x) => x != Ques.id);
        this.Data.quantity = this.Data.quantity.filter((x) => x != y);
        localStorage.setItem('cart', JSON.stringify(x));
        this.Data.subtotal = 0;
        this.Data.items.forEach((e) => {
          this.Data.subtotal += e.price;
        });
      },
      reject: () => {
        //reject action
      },
    });
  }

  CheckDiscount(){
    if(this.btnflag){
      if(this.discount.taxCode ){
        this.productser.getValueDiscount(this.discount.taxCode).subscribe(res=>{
          this.discount.value = res.value;
          if(this.discount.value == 0){
            this.discount.value = res.value;
            this.discountFlag = true;
            this.btnflag = true;
            
          }
          else{
            this.Data.discount = res.taxCode;
            this.discount.value = res.value;
            this.discountFlag = false;
            this.btnflag = false;
            this.oldtotal = Math.round(this.Data.subtotal + (this.Data.subtotal * 0.14));
            this.Data.subtotal =Math.round(this.Data.subtotal - (this.Data.subtotal * (this.discount.value/100)));
            this.Data.total = Math.round(this.Data.subtotal + (this.Data.subtotal * 0.14));
          }
        })
        
      }
      else{
        this.discount.value = 0;
        this.discountFlag = true;
        this.btnflag = true;
        
      }
      
    }   
  }

  RefrshOrder() {
    this.Data.subtotal = 0;
    this.selectedproduct.forEach((x, i) => {
      this.Data.subtotal += x.price * this.Data.quantity[i];
    });
    this.oldtotal = Math.round(this.Data.subtotal + (this.Data.subtotal * 0.14));
    if(this.discount.value){
      this.Data.total = Math.round(this.Data.subtotal + (this.Data.subtotal * 0.14) - (this.Data.subtotal * (this.discount.value/100)));
    }
    else{
      this.Data.total = Math.round(this.Data.subtotal + (this.Data.subtotal * 0.14));
    }
  }

  AcceptOrder() { 
    if(this.Data.countryid != 0 && this.Data.cityid != 0 && this.Data.paymenttype != undefined && this.Data.address != undefined){
      this.confirmationService.confirm({
        message: 'Are you sure that you want to perform this action?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.Data.orderId = (Math.random() + 1).toString(36).substring(7);
          this.Data.username = sessionStorage.getItem("user");
          // if(this.Data.discount == undefined){this.Data.discount = "";}
          this.productser.checkout(this.Data).subscribe(res=>{
            if(res == 'done'){
              this.router.navigateByUrl(`/Receipt/${this.Data.orderId}`);
              localStorage.clear();
            }
          });
        }
    });
     
      
    }
    else{
      this.visibleSidebar5 = true;
    }
    }
}
