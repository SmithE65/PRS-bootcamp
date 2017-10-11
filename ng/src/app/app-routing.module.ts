import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

// user imports
import { UserAddComponent } from './user/user-add/user-add.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserListComponent } from './user/user-list/user-list.component';

// vendor imports
import { VendorAddComponent } from './vendor/vendor-add/vendor-add.component';
import { VendorDetailComponent } from './vendor/vendor-detail/vendor-detail.component';
import { VendorEditComponent } from './vendor/vendor-edit/vendor-edit.component';
import { VendorListComponent } from './vendor/vendor-list/vendor-list.component';

const routes: Routes = [
    { path: "", redirectTo: "/home", pathMatch: "full" },
    { path: "home", component: HomeComponent },
    { path: "login", component: LoginComponent },
    // users-related routes
    { path: "users", component: UserListComponent },
    { path: "users/add", component: UserAddComponent },
    { path: "users/detail/:id", component: UserDetailComponent },
    { path: "users/edit/:id", component: UserEditComponent },
    // vendors-related routes
    { path: "vendors", component: VendorListComponent },
    { path: "vendors/add", component: VendorAddComponent },
    { path: "vendors/detail/:id", component: VendorDetailComponent },
    { path: "vendors/edit/:id", component: VendorEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
