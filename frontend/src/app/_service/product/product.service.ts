import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Discount, Invoice, Order, status } from 'src/app/_model/order/order';
import { headerCustomer, Product } from 'src/app/_model/Product/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) {}
  getProducts() {
    return this.http.get<Product[]>('https://localhost:44372/api/Product/getProducts');
  }
  GetAllStatus(){
    return this.http.get<status[]>(`https://localhost:44372/api/Cart/Status`)
  }
  getValueDiscount(id:string){
    return this.http.get<Discount>(`https://localhost:44372/api/Cart/Discount/${id}`)
  }
  checkout(order:Order){
    return this.http.post('https://localhost:44372/api/Cart/checkout',order,{responseType: 'text'})
  }
  GetInvoice(id:string){
    return this.http.get<headerCustomer[]>(`https://localhost:44372/api/Cart/noInvoice/${id}`)
  }  

  InvoiceDetial(id:string){
    return this.http.get<Invoice>(`https://localhost:44372/api/Cart/Invoice/${id}`)
  }

}
