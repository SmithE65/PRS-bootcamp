import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs';

import { Vendor } from '../models/vendor';

const urlBase: string = "http://localhost:51910";

@Injectable()
export class VendorService {

  constructor(private http: Http) { }

}
