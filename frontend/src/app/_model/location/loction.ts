export class City {
    constructor(
      public city_Name?: string,
      public city_Id?: number,
      public country_Id?: number,
      ){}
  }

  export class Country {
    constructor(
      public country_id?: number ,
      public sort_Name?: string ,
      public country_Name?: string ,
      public phone_Code?:number) { }
  }
  