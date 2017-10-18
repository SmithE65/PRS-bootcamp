import { PurchaseRequestLineItem } from './lineitem';
import { PurchaseRequest } from './purchaserequest';

export class Cart
{
  request: PurchaseRequest;
  lineItems: PurchaseRequestLineItem[];

  constructor(request: PurchaseRequest, lineItems: PurchaseRequestLineItem[])
  {
    this.request = request;
    this.lineItems = lineItems;
  }
}
