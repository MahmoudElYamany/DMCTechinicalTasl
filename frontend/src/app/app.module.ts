import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { IndexComponent } from './index/index.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { LoginComponent } from './auth/login/login.component';
import { ResgisterComponent } from './auth/resgister/resgister.component';
import { ConfirmationService, MessageService } from 'primeng/api';
import { PrimengComponentsModule } from './-primeng-components/-primeng-components.module';
import { ChartComponent } from './chart/chart.component';
import { ReceiptComponent } from './receipt/receipt.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavbarComponent,
    IndexComponent,
    NotfoundComponent,
    LoginComponent,
    ResgisterComponent,
    ChartComponent,
    ReceiptComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    PrimengComponentsModule,
  ],
  providers: [MessageService,ConfirmationService],//* for the toast tool in primeng lib.
  bootstrap: [AppComponent]
})
export class AppModule { }
