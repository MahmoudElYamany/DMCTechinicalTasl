export class login {
    constructor(
        public userName?:string ,
        public password ?:string){}
}

export class signup{
    constructor(
        public firstName?:string ,
        public lastName?:string ,
        public userName?:string ,
        public Email?:string ,
        public password?:string ,
        public cpassword?:string ,
        public countryid ?: number ,
        public phone ?: string,
        public gender? : string,
        public birthdate? : Date,
        public cityid ?:number){}
}

