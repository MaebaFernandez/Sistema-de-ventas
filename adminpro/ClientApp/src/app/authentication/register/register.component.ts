import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {
  register: FormGroup;
  lastname$: Observable<any>;

  constructor(private fb: FormBuilder) {
    this.createForm();
  }


  ngOnInit() {
    let a = {
      firtName: 'asdasd',
      lastName: 'asdasd',
      email: 'asdasd',
      password: 'asdasd'
    };
    this.register.patchValue(a);
    this.lastname$ = this.register.controls['lastName'].valueChanges;
    this.lastname$.subscribe(data => {
      console.log(data);
    });
  }

  public createForm(): void {
    this.register = this.fb.group({
      firtName: ['Maeba', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5)]],
      password: ['', [Validators.required]],
    });
  }

  registerForm(value: any) {
    console.log('form', value);
  }
}
