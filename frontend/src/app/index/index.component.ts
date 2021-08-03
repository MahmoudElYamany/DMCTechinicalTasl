import { Component, OnInit } from '@angular/core';
import { Product } from '../_model/Product/product';
import { AuthService } from '../_service/auth/auth.service';
import { ProductService } from '../_service/product/product.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
})
export class IndexComponent implements OnInit {
  products: Product[];

  sortOptions: any[];

  sortOrder: number;

  sortField: string;

  visibleSidebar4: boolean = false;

  displayModal: boolean = false;
  constructor(private loginser: AuthService, private productser: ProductService) {}

  ngOnInit(): void {
    this.loginser.navShow();
    this.productser.getProducts().subscribe((res) => {
      this.products = res;
    });
    this.sortOptions = [
      { label: 'Price High to Low', value: '!price' },
      { label: 'Price Low to High', value: 'price' },
    ];
  }

  showModalDialog() {
    this.displayModal = true;
  }

  onSortChange(event) {
    let value = event.value;

    if (value.indexOf('!') === 0) {
      this.sortOrder = -1;
      this.sortField = value.substring(1, value.length);
    } else {
      this.sortOrder = 1;
      this.sortField = value;
    }
  }

  obj = [];
  Shopping(value: number) {
    var userID = sessionStorage.getItem('user');
    if (userID != null) {
      var x = this.obj.includes(value);
      if (!x) {
        this.obj.push(value);
        localStorage.setItem('cart', JSON.stringify(this.obj));
      }
      console.log(x, this.obj);
    } else {
      this.visibleSidebar4 = true;
    }
  }
}
