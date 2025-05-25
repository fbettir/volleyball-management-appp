import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { JwtDecoderService } from './services/jwt-decoder.service';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {
  constructor(private auth: JwtDecoderService, private router: Router) {}

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
    const expectedRoles = route.data['expectedRoles'] as string[] || [];

    try {
      const userRoles = await this.auth.getUserRoles();

      if (!userRoles || userRoles.length === 0) {
        console.warn('No roles found for user');
        this.router.navigate(['/home']);
        return false;
      }

      const hasRequiredRole = userRoles.some(role => expectedRoles.includes(role));

      if (!hasRequiredRole) {
        console.warn('User lacks required roles:', expectedRoles);
        this.router.navigate(['/home']);
        return false;
      }

      return true;
    } catch (error) {
      console.error('RoleGuard error:', error);
      this.router.navigate(['/home']);
      return false;
    }
  }
}
