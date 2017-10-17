import { LineItem } from './lineitem';
import { PurchaseRequest } from './purchaserequest';

export class Cart
{
  request: PurchaseRequest;
  lineItems: LineItem[];

  constructor(request: PurchaseRequest, lineItems: LineItem[])
  {
    this.request = request;
    this.lineItems = lineItems;
  }
}
