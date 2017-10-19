import { Product } from './product';
import { PurchaseRequest } from './purchaserequest';

export class PurchaseRequestLineItem
{
  Id: number;
  PurchaseRequestId: number;
  Request: PurchaseRequest;
  ProductId: number;
  Product: Product;
  Quantity: number;
  IsFulfilled: boolean;

  constructor(
    id: number,
    requestId: number,
    productId: number,
    quantity: number,
    fulfilled: boolean
  ) {
    this.Id = id;
    this.PurchaseRequestId = requestId;
    this.ProductId = productId;
    this.Quantity = quantity;
    this.IsFulfilled = fulfilled;
  }
}
