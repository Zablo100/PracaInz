import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

@Injectable()
export class adminGuard implements CanActivate {
    constructor(private router: Router, private notification: ToastrService) {}

    canActivate() {
        if (this.isAdmin()){
          return true
        }
        return false;
      }

      isLoggedIn(){
        if (window.sessionStorage.getItem("login") == "true"){
            return true
        }

        return false
      }

      isAdmin(){
        const role = window.sessionStorage.getItem("role");
        if(this.isLoggedIn()){
            if (role == "Admin"){
                return true
            }

          return false
        }

        this.notification.error("Nie masz uprawnień do tej witryny")
        this.router.navigateByUrl("/")
        return false
    }
}