import { Vendor } from './vendor';

export class Product
{
  Id: number;
  VendorId: number;
  Vendor: Vendor;
  VendorPartNumber: string;
  Name: string;
  Description: string;
  Price: number;
  Unit: string;
  Photopath: string;

  constructor(
    Id: number,
    VendorId: number,
    Vendor: Vendor,
    VendorPartNumber: string,
    Name: string,
    Description: string,
    Price: number,
    Unit: string,
    Photopath: string)
  {
    this.Id = Id;
    this.VendorId = VendorId;
    this.Vendor = Vendor;
    this.VendorPartNumber = VendorPartNumber;
    this.Name = Name;
    this.Description = Description;
    this.Price = Price;
    this.Unit = Unit;
    this.Photopath = Photopath;
  }
}
