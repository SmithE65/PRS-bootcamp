// required models
import { User } from './user';
import { Status } from './status';

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
  Status: Status;
  Total: number;
  SubmittedDate: Date;
  ReasonForRejection: string;
}
