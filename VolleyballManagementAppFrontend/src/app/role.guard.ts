// role.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { JwtDecoderService } from './services/jwt-decoder.service';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate  {
  constructor(private auth: JwtDecoderService, private router: Router) {}

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
    console.log("Entering canActivate");
    const expectedRoles = route.data['expectedRoles'] as string[] || [];
    // const expectedRoles = routeRoles.includes('basic_user') ? routeRoles : [...routeRoles, 'basic_user'];
    
    console.log("expectedRoles:", expectedRoles);
    
    try{
      const userRoles = await this.auth.getUserRoles();
      console.log("userRoles", userRoles);

      const hasRole = userRoles.some(role => expectedRoles.includes(role));
      if (hasRole) {
        return true;
      } else {
        console.warn("User does not have the required roles.");
        this.router.navigate(['/home']);
        return false;
      }
    } catch (error) {
      console.error("Error in roles", error);
      this.router.navigate(['/home']);
      return false;
    }
  }
}
