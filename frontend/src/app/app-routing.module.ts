import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { ResgisterComponent } from './auth/resgister/resgister.component';
import { ChartComponent } from './chart/chart.component';
import { IndexComponent } from './index/index.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ReceiptComponent } from './receipt/receipt.component';
import { LoginGuard } from './_guard/login/login.guard';

const routes: Routes = [
  {path :"home" , component:IndexComponent },
  {path:"" , component:IndexComponent},
  {path :"login" , component:LoginComponent},
  {path :"signup" , component:ResgisterComponent},
  {path :"charts" , component:ChartComponent,canActivate:[LoginGuard]},
  {path :"Receipt/:id" , component:ReceiptComponent,canActivate:[LoginGuard]},
  {path :"**" , component:NotfoundComponent},
];
const routerOptions: ExtraOptions = {
  useHash: false,
  anchorScrolling: 'enabled',
  // ...any other options you'd like to use
};
@NgModule({
  imports: [RouterModule.forRoot(routes,routerOptions)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
