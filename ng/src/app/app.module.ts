// import external modules
import { BrowserModule }          from '@angular/platform-browser';
import { NgModule }               from '@angular/core';
import { FormsModule }            from '@angular/forms';
import { HttpModule }             from '@angular/http';
//import { MatAutocompleteModule }  from '@angular/material';

// import project components and modules
import { AppRoutingModule }       from './app-routing.module';
import { AppComponent }           from './app.component';
import { MenuComponent }          from './menu/menu.component';
import { HeaderComponent }        from './header/header.component';
import { HomeComponent }          from './home/home.component';
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

// import services
import { ProductService }         from './services/product.service';
import { PurchaseRequestService } from './services/purchaserequest.service';
import { SystemService }          from './services/system.service';
import { UserService }            from './services/user.service';
import { VendorService }          from './services/vendor.service';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
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
    VendorAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
    //MatAutocompleteModule
  ],
  providers: [
    ProductService,
    PurchaseRequestService,
      UserService,
    SystemService,
      VendorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
