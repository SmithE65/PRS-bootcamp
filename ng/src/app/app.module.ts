// import external modules
import { BrowserModule }          from '@angular/platform-browser';
import { NgModule }               from '@angular/core';
import { FormsModule }            from '@angular/forms';
import { HttpModule }             from '@angular/http';
//import { MatAutocompleteModule }  from '@angular/material';

// import project components and modules
import { AppRoutingModule }       from './app-routing.module';
import { AppComponent }           from './app.component';

// front-page components
import { MenuComponent } from './menu/menu.component';
import { HeaderComponent }        from './header/header.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent }         from './login/login.component';

// user-related components
import { UserComponent }          from './user/user.component';
import { UserAddComponent }       from './user/user-add/user-add.component';
import { UserDetailComponent }    from './user/user-detail/user-detail.component';
import { UserEditComponent }      from './user/user-edit/user-edit.component';
import { UserListComponent }      from './user/user-list/user-list.component';

// vendor-related components
import { VendorAddComponent }     from './vendor/vendor-add/vendor-add.component';
import { VendorDetailComponent }  from './vendor/vendor-detail/vendor-detail.component';
import { VendorEditComponent }    from './vendor/vendor-edit/vendor-edit.component';
import { VendorListComponent }    from './vendor/vendor-list/vendor-list.component';

// product-related components
import { ProductAddComponent }    from './product/product-add/product-add.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductEditComponent }   from './product/product-edit/product-edit.component';
import { ProductListComponent }   from './product/product-list/product-list.component';

// purchase request related components
import { PurchaserequestAddComponent }    from './purchaserequest/purchaserequest-add/purchaserequest-add.component';
import { PurchaserequestDetailComponent } from './purchaserequest/purchaserequest-detail/purchaserequest-detail.component';
import { PurchaserequestEditComponent }   from './purchaserequest/purchaserequest-edit/purchaserequest-edit.component';
import { PurchaserequestListComponent }   from './purchaserequest/purchaserequest-list/purchaserequest-list.component';

// status related components
import { StatusAddComponent }     from './status/status-add/status-add.component';
import { StatusDetailComponent }  from './status/status-detail/status-detail.component';
import { StatusEditComponent }    from './status/status-edit/status-edit.component';
import { StatusListComponent }    from './status/status-list/status-list.component';

// purchase request line item related components
import { PrLineItemAddComponent }     from './lineitem/pr-line-item-add/pr-line-item-add.component';
import { PrLineItemDetailComponent }  from './lineitem/pr-line-item-detail/pr-line-item-detail.component';
import { PrLineItemEditComponent }    from './lineitem/pr-line-item-edit/pr-line-item-edit.component';
import { PrLineItemListComponent }    from './lineitem/pr-line-item-list/pr-line-item-list.component';

// browse compent
import { BrowseComponent } from './browse/browse.component';

// shopping cart component
import { CartComponent } from './cart/cart.component';

// review component
import { ReviewComponent } from './review/review.component';
import { ReviewDetailComponent } from './review/review-detail/review-detail.component';

// import services
import { PrLineItemService }      from './services/pr-line-item.service';
import { ProductService }         from './services/product.service';
import { PurchaseRequestService } from './services/purchaserequest.service';
import { ShoppingCartService }    from './services/shopping-cart.service';
import { StatusService }          from './services/status.service';
import { SystemService }          from './services/system.service';
import { UserService }            from './services/user.service';
import { VendorService }          from './services/vendor.service';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HeaderComponent,
    HomeComponent,  // home page
    AboutComponent, // page about
    LoginComponent,
    // status components
    StatusAddComponent,
    StatusDetailComponent,
    StatusEditComponent,
    StatusListComponent,
    // line item components for purchase requests
    PrLineItemAddComponent,
    PrLineItemDetailComponent,
    PrLineItemEditComponent,
    PrLineItemListComponent,
    // product components
    ProductAddComponent,
    ProductDetailComponent,
    ProductEditComponent,
    ProductListComponent,
    // purchase request components
    PurchaserequestAddComponent,
    PurchaserequestDetailComponent,
    PurchaserequestEditComponent,
    PurchaserequestListComponent,
    // user components
    UserComponent,
    UserListComponent,
    UserDetailComponent,
    UserEditComponent,
    UserAddComponent,
    // vendor components
    VendorListComponent,
    VendorEditComponent,
    VendorDetailComponent,
    VendorAddComponent,
    // Components for browsing products and filling out purchase requests
    BrowseComponent,
    CartComponent,
    // Components for reviewing requests
    ReviewComponent,
    ReviewDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
    //MatAutocompleteModule
  ],
  providers: [
    PrLineItemService,
    ProductService,
    PurchaseRequestService,
    ShoppingCartService,
    StatusService,
    SystemService,
    UserService,
    VendorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
