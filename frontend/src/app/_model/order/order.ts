import { Product } from "../Product/product";

export class Order {
    constructor(
        public orderId?: string,
        public countryid?:number,
        public cityid ?:number,
        public address ?:string,
        public quantity ?:any[],
        public discount?:string,
        public total?:number,
        public subtotal?:number,
        public paymenttype?:string,
        public items?:any[],
        public username?:string,
    ){}
}

export class Discount{
    constructor(
        public taxCode?:string,
        public value?:number,
    ){}
}

export class status{
    constructor(
        public id?:number,
        public state?:string,
    ){}
}



export class Invoice {
    constructor(
        public orderDate?:Date,
        public dueDate?:Date,
        public status?:number,
        public totalValue?:number,
        public discountCode?:string,
        public discountvalue?:number,
        public tax?:number,
        public paymentType?:string,
        public items?:Product[],
        public quantity?:any[],
        public userName?:string,
        public address?:string,
        public country?:string,
        public city?:string,
        public anotherCountry?:boolean
    ){}
}
