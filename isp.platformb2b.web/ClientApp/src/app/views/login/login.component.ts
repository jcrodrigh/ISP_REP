import { Component } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthEnterpriceService } from 'src/app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html',
  styleUrls:['login.component.css']
})
export class LoginComponent { 
  loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    error = '';
    
  
    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,        
        private router: Router,
        private authEnterpriceService: AuthEnterpriceService
    ) { 
        // redirect to home if already logged in
        if (this.authEnterpriceService.currentUserValue) { 
            
            this.router.navigate(['/']);
        }
    }
  
    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
  
        //get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || 'dashboard';
    }
  
    // convenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }
  
    onSubmit() {
        
        this.submitted = true;
  
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
  
        this.loading = true;
        this.authEnterpriceService.login(this.f.username.value, this.f.password.value)
            .pipe(first())
            .subscribe(
                data => {
                                      
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    console.log(error);
                    this.error = error.error.message;
                    this.loading = false;
                });
    }
}