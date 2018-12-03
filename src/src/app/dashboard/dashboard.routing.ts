import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { RootComponent }    from './root/root.component';
import { HomeComponent }    from './home/home.component'; 
import { SettingsComponent }    from './settings/settings.component';
import { ClientListComponent } from './clients/client-list/client-list.component';
import { ClientCreateComponent } from './clients/client-create/client-create.component';
import { ClientUpdateComponent } from './clients/client-update/client-update.component';
import { PolicyListComponent } from './insurance/policy-list/policy-list.component';

import { AuthGuard } from '../auth.guard';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
      path: 'dashboard',
      component: RootComponent, canActivate: [AuthGuard],

      children: [      
       { path: '', component: HomeComponent },
       { path: 'home',  component: HomeComponent },
       { path: 'settings',  component: SettingsComponent },
       { path: 'client-list',  component: ClientListComponent },
       { path: 'client-create',  component: ClientCreateComponent },
       { path: 'client-create',  component: ClientCreateComponent },
       { path: 'client-create',  component: ClientCreateComponent },
       { path: 'client-update',  component: ClientUpdateComponent },
       { path: 'policy-list',  component: PolicyListComponent },
       
       
      
       
      ]       
    }  
]);

