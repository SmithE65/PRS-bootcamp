import { NgModule }               from '@angular/core';
import { Routes, RouterModule }   from '@angular/router';
import { HomeComponent }          from './home/home.component';
import { LoginComponent }         from './login/login.component';

// user imports
import { UserAddComponent }       from './user/user-add/user-add.component';
import { UserDetailComponent }    from './user/user-detail/user-detail.component';
import { UserEditComponent }      from './user/user-edit/user-edit.component';
import { UserListComponent }      from './user/user-list/user-list.component';

// vendor imports
import { VendorAddComponent }     from './vendor/vendor-add/vendor-add.component';
import { VendorDetailComponent }  from './vendor/vendor-detail/vendor-detail.component';
import { VendorEditComponent }    from './vendor/vendor-edit/vendor-edit.component';
import { VendorListComponent }    from './vendor/vendor-list/vendor-list.component';

// product imports
import { ProductAddComponent }    from './product/product-add/product-add.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductEditComponent }   from './product/product-edit/product-edit.component';
import { ProductListComponent }   from './product/product-list/product-list.component';

// purchase request imports
import { PurchaserequestAddComponent }    from './purchaserequest/purchaserequest-add/purchaserequest-add.component';
import { PurchaserequestDetailComponent } from './purchaserequest/purchaserequest-detail/purchaserequest-detail.component';
import { PurchaserequestEditComponent }   from './purchaserequest/purchaserequest-edit/purchaserequest-edit.component';
import { PurchaserequestListComponent } from './purchaserequest/purchaserequest-list/purchaserequest-list.component';

// status related components
import { StatusAddComponent } from './status/status-add/status-add.component';
import { StatusDetailComponent } from './status/status-detail/status-detail.component';
import { StatusEditComponent } from './status/status-edit/status-edit.component';
import { StatusListComponent } from './status/status-list/status-list.component';

// purchase request line item related components
import { PrLineItemAddComponent } from './lineitem/pr-line-item-add/pr-line-item-add.component';
import { PrLineItemDetailComponent } from './lineitem/pr-line-item-detail/pr-line-item-detail.component';
import { PrLineItemEditComponent } from './lineitem/pr-line-item-edit/pr-line-item-edit.component';
import { PrLineItemListComponent } from './lineitem/pr-line-item-list/pr-line-item-list.component';

// browse compent
import { BrowseComponent } from './browse/browse.component';

// shopping car component
import { CartComponent } from './cart/cart.component';

// request review component
import { ReviewComponent } from './review/review.component';


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
    { path: "vendors/edit/:id", component: VendorEditComponent },
    // products-related routes
    { path: "products", component: ProductListComponent },
    { path: "products/add", component: ProductAddComponent },
    { path: "products/detail/:id", component: ProductDetailComponent },
    { path: "products/edit/:id", component: ProductEditComponent },
    // purchase request related routes
    { path: "requests", component: PurchaserequestListComponent },
    { path: "requests/add", component: PurchaserequestAddComponent },
    { path: "requests/detail/:id", component: PurchaserequestDetailComponent },
    { path: "requests/edit/:id", component: PurchaserequestEditComponent },
    // status related routes
    { path: "status", component: StatusListComponent },
    { path: "status/add", component: StatusAddComponent },
    { path: "status/detail/:id", component: StatusDetailComponent },
    { path: "status/edit/:id", component: StatusEditComponent },
    // line item related routes
    { path: "lineitems", component: PrLineItemListComponent },
    { path: "lineitems/add", component: PrLineItemAddComponent },
    { path: "lineitems/detail/:id", component: PrLineItemDetailComponent },
    { path: "lineitems/edit/:id", component: PrLineItemEditComponent },
    // browsing related routes
    { path: "browse", component: BrowseComponent },
    // shopping cart related routes
    { path: "cart", component: CartComponent },
    // request review related routes
    { path: "review", component: ReviewComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
