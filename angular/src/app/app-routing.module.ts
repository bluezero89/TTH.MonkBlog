import { ApplicationLayoutComponent } from '@volo/abp.ng.theme.lepton';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
    canActivate: [AuthGuard, PermissionGuard],
    data: {
      requiredPolicy: 'MonkBlog.Dashboard.Host || AbpAccount.SettingManagement',
    },
  },
  {
    path: 'identity',
    loadChildren: () => import('@volo/abp.ng.identity').then((m) => m.IdentityModule.forLazy()),
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@volo/abp.ng.account').then((m) => m.AccountModule.forLazy({ redirectUrl: '/' })),
  },
  {
    path: 'language-management',
    loadChildren: () =>
      import('@volo/abp.ng.language-management').then((m) => m.LanguageManagementModule.forLazy()),
  },
  {
    path: 'saas',
    loadChildren: () => import('@volo/abp.ng.saas').then((m) => m.SaasModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () =>
      import('@volo/abp.ng.audit-logging').then((m) => m.AuditLoggingModule.forLazy()),
  },
  {
    path: 'identity-server',
    loadChildren: () =>
      import('@volo/abp.ng.identity-server').then((m) => m.IdentityServerModule.forLazy()),
  },
  {
    path: 'text-template-management',
    loadChildren: () =>
      import('@volo/abp.ng.text-template-management').then((m) =>
        m.TextTemplateManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then((m) => m.SettingManagementModule.forLazy()),
  },
  /*<Menu_Item_Monks>*/
  {
    path: 'monks',
    component: ApplicationLayoutComponent,
    loadChildren: () => import('./monks/monks.module').then(m => m.MonksModule),
    canActivate: [AuthGuard, PermissionGuard],
    data: {
      routes: {
        iconClass: 'fa fa-file-alt',
        name: '::Menu:Monks',
        requiredPolicy: 'MonkBlog.Monks'
      }
    }
  },
  /*</Menu_Item_Monks>*/
  /*<Menu_Item_ReligousLives>*/
  {
    path: 'religousLives',
    component: ApplicationLayoutComponent,
    loadChildren: () => import('./religousLives/religousLives.module').then(m => m.ReligousLivesModule),
    canActivate: [AuthGuard, PermissionGuard],
    data: {
      routes: {
        iconClass: 'fa fa-file-alt',
        name: '::Menu:ReligousLives',
        requiredPolicy: 'MonkBlog.ReligousLives'
      }
    }
  },
  /*</Menu_Item_ReligousLives>*/
  /*<Menu_Item_StudyHistories>*/
  {
    path: 'studyHistories',
    component: ApplicationLayoutComponent,
    loadChildren: () => import('./studyHistories/studyHistories.module').then(m => m.StudyHistoriesModule),
    canActivate: [AuthGuard, PermissionGuard],
    data: {
      routes: {
        iconClass: 'fa fa-file-alt',
        name: '::Menu:StudyHistories',
        requiredPolicy: 'MonkBlog.StudyHistories'
      }
    }
  },
  /*</Menu_Item_StudyHistories>*/
  /*<Menu_Item_Pastorals>*/
  {
    path: 'pastorals',
    component: ApplicationLayoutComponent,
    loadChildren: () => import('./pastorals/pastorals.module').then(m => m.PastoralsModule),
    canActivate: [AuthGuard, PermissionGuard],
    data: {
      routes: {
        iconClass: 'fa fa-file-alt',
        name: '::Menu:Pastorals',
        requiredPolicy: 'MonkBlog.Pastorals'
      }
    }
  },
  /*</Menu_Item_Pastorals>*/
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
