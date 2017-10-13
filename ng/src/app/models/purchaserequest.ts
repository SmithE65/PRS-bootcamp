// user
import { User } from './user';

export class PurchaseRequest
{
  Id: number;
  UserId: number;
  User: User;
  Description: string;
  Justification: string;
  DateNeeded: Date;
  DeliveryMode: string;
  StatusId: number;
  Total: number;
  SubmittedDate: Date;
  ReasonForRejection: string;
}
