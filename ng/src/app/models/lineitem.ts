import { Product } from './product';
import { PurchaseRequest } from './purchaserequest';

export class LineItem
{
  Id: number;
  RequestId: number;
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
    this.RequestId = requestId;
    this.ProductId = productId;
    this.Quantity = quantity;
  }
}
