import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MsalGuard, MsalRedirectComponent } from '@azure/msal-angular';
import { BrowserUtils } from '@azure/msal-browser';
import { ExpenseGroupDetailsComponent } from './components/ExpenseGroups/expense-group-details/expense-group-details.component';
import { ExpenseGroupListComponent } from './components/ExpenseGroups/expense-group-list/expense-group-list.component';
import { InvitationsListComponent } from './components/Invitations/invitations-list/invitations-list.component';
import { HomeComponent } from './home/home.component';

/**
 * MSAL Angular can protect routes in your application using MsalGuard. For more info, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-angular/docs/v2-docs/initialization.md#secure-the-routes-in-your-application
 */
const routes: Routes = [
    {
        path: 'expensegroup/:id',
        component: ExpenseGroupDetailsComponent,
        canActivate: [
            MsalGuard
        ]
    },
    {
        path: 'expensegroups',
        component: ExpenseGroupListComponent,
        canActivate: [
            MsalGuard
        ]
    },
    {
        path: 'invitations',
        component: InvitationsListComponent,
        canActivate: [
            MsalGuard
        ]
    },
    {
        // Needed for handling redirect after login
        path: 'auth',
        component: MsalRedirectComponent
    },
    {
        path: '',
        component: HomeComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, {
        // Don't perform initial navigation in iframes or popups
        initialNavigation: !BrowserUtils.isInIframe() && !BrowserUtils.isInPopup() ? 'enabledNonBlocking' : 'disabled' // Set to enabledBlocking to use Angular Universal
    })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
