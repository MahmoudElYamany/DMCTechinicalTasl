import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_service/auth/auth.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(public loginser: AuthService) { }

  ngOnInit(): void {
    this.loginser.footerShow();
  }

}
