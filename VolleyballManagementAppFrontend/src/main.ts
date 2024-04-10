import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideAuth0 } from '@auth0/auth0-angular';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, {
  providers: [
    provideAuth0({
      // The domain and clientId were configured in the previous chapter
      domain: 'muerapp.eu.auth0.com',
      clientId: 'oAjuMaAoZnzewmiyYch4IrraASQRlUPS',
    
      authorizationParams: {
        redirect_uri: window.location.origin,
        
        // Request this audience at user authentication time
        audience: 'https://muerapp.eu.auth0.com/api/v2/',
    
        // Request this scope at user authentication time
        scope: 'read:current_user',
      },
    
      // Specify configuration for the interceptor              
      httpInterceptor: {
        allowedList: [
          {
            // Match any request that starts 'https://muerapp.eu.auth0.com/api/v2/' (note the asterisk)
            uri: 'https://muerapp.eu.auth0.com/api/v2/*',
            tokenOptions: {
              authorizationParams: {
                // The attached token should target this audience
                audience: 'https://muerapp.eu.auth0.com/api/v2/',
    
                // The attached token should have these scopes
                scope: 'read:current_user'
              }
            }
          }
        ]
      }
    })
  ]
});
platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
