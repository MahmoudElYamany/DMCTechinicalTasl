import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Invoice, status } from '../_model/order/order';
import { AuthService } from '../_service/auth/auth.service';
import { ProductService } from '../_service/product/product.service';
@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css'],
})
export class ReceiptComponent implements OnInit {
  constructor(public loginser: AuthService,private ac: ActivatedRoute, private productser: ProductService) {}
 
  loading:boolean=false;

  invoiceId: string;
  invoiceDetial: Invoice = new Invoice();
  subTotal: number = 0;

  status: status[] = []
  selectedStatus: string;

  ngOnInit() {
      this.loginser.footerHide();
      this.loginser.navShow();
    this.ac.params.subscribe((a) => {
      this.invoiceId = a.id;
      this.productser.InvoiceDetial(a.id).subscribe((res) => {
        console.log(res);
        this.invoiceDetial = res;
        this.subTotal = 0;
        res.items.forEach(e => {
            this.subTotal += e.price;
        });
        this.selectedStatus = this.status.find(x=>x.id == this.invoiceDetial.status ).state
      });
    });

    this.productser.GetAllStatus().subscribe(res=>{
        this.status = res
    })
    

  }

  exportPdf() {
    this.loading= true;
    setTimeout(() => {this.loading = false;window.print();}, 1000);
    
  }
}
