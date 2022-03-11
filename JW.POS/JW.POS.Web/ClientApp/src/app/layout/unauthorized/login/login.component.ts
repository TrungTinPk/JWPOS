import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validator, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthenticateService, UserService} from "@app/shared/services";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private userService: UserService,
    private authService: AuthenticateService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initForm()
  }

  initForm(): void {
    this.form = this.fb.group({
      username: ['',[Validators.required]],
      password: ['',[Validators.required]]
    })
  }

  submit(): void {
    if (!this.form.valid) {
      return;
    }
    const username = this.form.get('username')?.value;
    const pw = this.form.get('password')?.value;;

    this.userService.login(username,pw).subscribe({
      next: token => {
        if (token?.length) {
          this.authService.persistToken(token)
          this.router.navigate(['/'])
        }
      }
    })
  }

}
