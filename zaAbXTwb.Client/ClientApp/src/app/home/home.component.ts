import { Component } from '@angular/core';
import { DataService } from '../models/generated/DataService';
import { LoginViewModel } from '../models/generated/LoginViewModel';
import { RegisterViewModel } from '../models/generated';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private dataService: DataService) {
    this.dataService.accountApi.register(new RegisterViewModel({Email:"marbletravis@gmail.com", Password:"Password123!", ConfirmPassword: "Password123!"})).subscribe((x) => {
      console.log("Success", x);
    }, (x)=>{
      console.log("Error", x);      
    });
    this.dataService.accountApi.login(new LoginViewModel({Email:"marbletravis@gmail.com", Password:"Password123!"})).subscribe(x => x);
  }
}
