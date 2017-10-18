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

  constructor(
    id: number,
    requestId: number,
    productId: number,
    quantity: number
  ) {
    this.Id = id;
    this.PurchaseRequestId = requestId;
    this.ProductId = productId;
    this.Quantity = quantity;
  }
}
