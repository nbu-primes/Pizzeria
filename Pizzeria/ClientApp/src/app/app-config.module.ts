import { NgModule, InjectionToken } from "@angular/core";
import { environment } from 'src/environments/environment';

export class AppConfig {
  apiEndpoint: string;
  jwtKey: string
}

export let APP_CONFIG = new InjectionToken<AppConfig>('app.config');
export const APP_DI_CONFIG: 
AppConfig = {
  apiEndpoint: environment.apiEndpoint,
  jwtKey: environment.jwtKey
};

@NgModule({
    providers: [{
        provide: APP_CONFIG,
        useValue: APP_DI_CONFIG
    }]
})
export class AppConfigModule{}