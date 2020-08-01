import { PastoralsState } from './store/states/pastorals/pastorals.state';
import { StudyHistoriesState } from './store/states/studyHistories/studyHistories.state';
import { ReligousLivesState } from './store/states/religousLives/religousLives.state';
import { MonksState } from './store/states/monks/monks.state';
import { CoreModule } from '@abp/ng.core';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxsModule } from '@ngxs/store';
import { AccountConfigModule } from '@volo/abp.ng.account/config';
import { AuditLoggingConfigModule } from '@volo/abp.ng.audit-logging/config';
import { IdentityServerConfigModule } from '@volo/abp.ng.identity-server/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { LanguageManagementConfigModule } from '@volo/abp.ng.language-management/config';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { TextTemplateManagementConfigModule } from '@volo/abp.ng.text-template-management/config';
import { HttpErrorComponent, ThemeLeptonModule } from '@volo/abp.ng.theme.lepton';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ThemeSharedModule.forRoot({
      httpErrorConfig: {
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      },
    }),
    CoreModule.forRoot({
      environment,
    }),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    LanguageManagementConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    AuditLoggingConfigModule.forRoot(),
    IdentityServerConfigModule.forRoot(),
    TextTemplateManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    NgxsModule.forRoot([PastoralsState, StudyHistoriesState, ReligousLivesState, MonksState, ]),
    ThemeLeptonModule.forRoot(),
  ],
  providers: [APP_ROUTE_PROVIDER],
  bootstrap: [AppComponent],
})
export class AppModule {}
