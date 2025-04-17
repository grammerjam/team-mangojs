import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

// import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  fb = inject(FormBuilder);

  form = this.fb.nonNullable.group({
    Username: ['', Validators.required],
    Password: ['', Validators.required],
  });


  http = inject(HttpClient);
  router = inject(Router);

  // encriptData(data: any) {
  //   return CryptoJS.AES.encrypt(data, Constant.EN_KEY).toString();
  // }

  onLogin() {
    this.http.post("http://localhost:5100/api/Users/authenticate", this.form.getRawValue()).subscribe((res: any) => {
      if (res.Token) {
        alert("Login Success");
        const enrUserName = (this.form.getRawValue().Username);
        localStorage.setItem("uName", enrUserName);
        localStorage.setItem('angular18Token', res.Token);
        this.router.navigateByUrl('/home')
      } else {
        console.log(res)
        alert(res.message)
      }
    })
  }
}