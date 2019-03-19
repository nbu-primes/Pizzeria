import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig, APP_CONFIG } from '../app-config.module';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  constructor(private httpClient: HttpClient,
    @Inject(APP_CONFIG) private config: AppConfig) { }

  ngOnInit() {
  }

  testApi(){
    this.httpClient
          .get(`${this.config.apiEndpoint}/values`)
          .subscribe((result)=>{
            console.log(result);
          })
  }
}
