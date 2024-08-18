import { PurchaseRequestLineItem } from './lineitem';
import { PurchaseRequest } from './purchaserequest';

export class Cart
{
  request: PurchaseRequest;
  lineitems: PurchaseRequestLineItem[];

  constructor(request: PurchaseRequest, lineItems: PurchaseRequestLineItem[])
  {
    this.request = request;
    this.lineitems = lineItems;
  }
}
