export class Product {
    constructor(
        public id?:number,
        public category?:string ,
        public avaiable?:string ,
        public image?:string ,
        public name?:string ,
        public description?:string ,
        public price?:number,
        public size?:number,
        public uom?:string,
        public color?:string){}
}

export class headerCustomer{
    constructor(
        public id?:number,
        public orderHeaderID?:string
    ){}
}
