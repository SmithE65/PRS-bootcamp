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

  constructor (
    id: number,
    userId: number,
    description: string,
    justification: string,
    dateNeeded: Date,
    delivery: string,
    total: number,
    statusId: number,
    submittedDate: Date
  ) {
    this.Id = id;
    this.UserId = userId;
    this.Description = description;
    this.Justification = justification;
    this.DateNeeded = dateNeeded;
    this.DeliveryMode = delivery;
    this.Total = total;
    this.StatusId = statusId;
    this.SubmittedDate = submittedDate;
  }
}
