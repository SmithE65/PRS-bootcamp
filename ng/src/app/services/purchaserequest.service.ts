import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../models/purchaserequest';

@Injectable()
export class PurchaseRequestService {

  constructor(private http: Http) { }

}
